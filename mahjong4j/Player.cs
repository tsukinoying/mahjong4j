﻿using mahjong4j.hands;
using mahjong4j.yaku.normals;
using static mahjong4j.yaku.normals.NormalYaku;
using mahjong4j.yaku.yakuman;
using static mahjong4j.Score;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mahjong4j.tile;

/**
 * 和了判定に関するクラスです。
 * 役の判定は別のクラスで行うがここから呼び出します
 *
 * @author tsukinoying
 */
namespace mahjong4j
{
    public class Player
    {
        //付いた役満リスト
        private List<Yakuman> yakumanList = new List<Yakuman>(1);

        //付いた通常役リスト
        private List<NormalYaku> normalYakuList = new List<NormalYaku>(0);

        //その時の面子の組
        private MentsuComp comp;

        // 翻
        private int han = 0;
        // 符
        private int fu = 0;
        // 点数
        private Score score = SCORE0;
        
        private Hands hands;
        private GeneralSituation generalSituation;
        private PersonalSituation personalSituation;


        public Player(Hands hands)
        {
            this.hands = hands;
        }

        public Player(Hands hands, GeneralSituation generalSituation, PersonalSituation personalSituation)
        {
            this.hands = hands;
            this.generalSituation = generalSituation;
            this.personalSituation = personalSituation;
        }


        public List<Yakuman> getYakumanList()
        {
            return yakumanList;
        }

        public List<NormalYaku> getNormalYakuList()
        {
            return normalYakuList;
        }

        public int getFu()
        {
            return fu;
        }

        public Score getScore()
        {
            return score;
        }

        public int getHan()
        {
            return han;
        }

        public void calculate()
        {
            //和了れない場合は即座に終了
            if (!hands.getCanWin()) return;

            //国士無双の場合はそれ以外ありえないので保存して即座に終了
            if (hands.getIsKokushimuso())
            {
                yakumanList.Add(Yakuman.KOKUSHIMUSO);
                return;
            }

            //役満を探し見つかれば通常役は調べずに終了
            if (findYakuman())
            {
                if (personalSituation == null)
                {
                    score = SCORE0;
                    return;
                }
                score = Score.calculateYakumanScore(personalSituation.isParent(), yakumanList.Count());
                return;
            }

            findNormalYaku();
        }

        /**
         * @return 役満が見つかったか
         */
        private bool findYakuman()
        {
            //役満をストックしておき、見つかったら先にこちらに保存する
            List<Yakuman> yakumanStock = new List<Yakuman>(4);

            //それぞれの面子の完成形で判定する
            foreach (MentsuComp comp in hands.getMentsuCompSet())
            {
                HashSet<YakumanResolver> yakumanResolverSet
                    = Mahjong4jYakuConfig.getYakumanResolverSet(comp, generalSituation, personalSituation);

                foreach (YakumanResolver resolver in yakumanResolverSet)
                {
                    if (resolver.isMatch())
                    {
                        yakumanStock.Add(resolver.getYakuman());
                    }
                }

                //ストックと保存する役満リストと比較し大きい方を保存する
                if (yakumanList.Count() < yakumanStock.Count())
                {
                    yakumanList = yakumanStock;
                    this.comp = comp;
                }
            }

            return yakumanList.Count() > 0;
        }

        private void findNormalYaku()
        {
            //それぞれの面子の完成形で判定する
            foreach (MentsuComp comp in hands.getMentsuCompSet())
            {
                //役をストックしておく
                List<NormalYaku> yakuStock = new List<NormalYaku>(7);
                HashSet<NormalYakuResolver> resolverSet
                    = Mahjong4jYakuConfig.getNormalYakuResolverSet(comp, generalSituation, personalSituation);
                foreach (NormalYakuResolver resolver in resolverSet)
                {
                    if (resolver.isMatch())
                    {
                        yakuStock.Add(resolver.getNormalYaku());
                    }
                }

                int hanSum = calcHanSum(yakuStock);
                if (hanSum > this.han)
                {
                    han = hanSum;
                    normalYakuList = yakuStock;
                    this.comp = comp;
                }
            }

            if (han > 0)
            {
                calcDora(hands.getHandsComp(), generalSituation, normalYakuList.Contains(NormalYaku.REACH));
            }
            calcScore();
        }

        private void calcScore()
        {
            fu = calcFu();
            if (personalSituation == null)
            {
                return;
            }
            score = Score.calculateScore(personalSituation.isParent(), han, fu);
        }

        /**
         * 符計算をします
         * 役なしの場合は0
         * Situationが無い場合は一律で20
         */
        private int calcFu()
        {
            if (normalYakuList.Count() == 0)
            {
                return 0;
            }
            if (personalSituation == null || generalSituation == null)
            {
                return 20;
            }
            // 特例の平和ツモと七対子の符
            if (normalYakuList.Contains(PINFU) && normalYakuList.Contains(TSUMO))
            {
                return 20;
            }
            if (normalYakuList.Contains(CHITOITSU))
            {
                return 25;
            }

            int tmpFu = 20;
            // 門前ロンなら+10
            tmpFu += calcFuByAgari();

            // 各メンツの種類による加符
            foreach (Mentsu mentsu in comp.getAllMentsu())
            {
                tmpFu += mentsu.getFu();
            }

            tmpFu += calcFuByWait(comp, hands.getLast());
            tmpFu += calcFuByJanto();

            return tmpFu;
        }

        /**
         * 雀頭の種類による加符
         * 連風牌の場合は+4とします
         *
         * @return
         */
        private int calcFuByJanto()
        {
            Tile jantoTile = comp.getJanto().getTile();
            int tmp = 0;
            if (jantoTile == generalSituation.getBakaze())
            {
                tmp += 2;
            }
            if (jantoTile == personalSituation.getJikaze())
            {
                tmp += 2;
            }
            if (jantoTile.getType() == TileType.SANGEN)
            {
                tmp += 2;
            }
            return tmp;
        }

        private int calcFuByAgari()
        {
            // ツモ
            if (personalSituation.isTsumo())
            {
                return 2;
            }
            // 門前ロン
            if (!hands.isOpen())
            {
                return 10;
            }
            return 0;
        }

        /**
         * 待ちの種類による可符
         *
         * @param comp
         * @param last
         * @return
         */
        private int calcFuByWait(MentsuComp comp, Tile last)
        {
            if (comp.isKanchan(last) || comp.isPenchan(last) || comp.isTanki(last))
            {
                return 2;
            }

            return 0;
        }

        private void calcDora(int[] handsComp, GeneralSituation generalSituation, bool isReach)
        {
            if (generalSituation == null)
            {
                return;
            }
            int dora = 0;
            foreach (Tile tile in generalSituation.getDora())
            {
                dora += handsComp[tile.getCode()];
            }
            for (int i = 0; i < dora; i++)
            {
                normalYakuList.Add(DORA);
                han += DORA.getHan();
            }

            if (isReach)
            {
                int uradora = 0;
                foreach (Tile tile in generalSituation.getUradora())
                {
                    uradora += handsComp[tile.getCode()];
                }
                for (int i = 0; i < uradora; i++)
                {
                    normalYakuList.Add(URADORA);
                    han += URADORA.getHan();
                }
            }
        }

        /**
         * 手牌が食い下がる形かも判定し、翻の合計を計算し、返します
         *
         * @param yakuStock 役のストック
         * @return 翻数の合計
         */
        private int calcHanSum(List<NormalYaku> yakuStock)
        {
            int hanSum = 0;
            if (hands.isOpen())
            {
                foreach (NormalYaku yaku in yakuStock)
                {
                    hanSum += yaku.getKuisagari();
                }
            }
            else
            {
                foreach (NormalYaku yaku in yakuStock)
                {
                    hanSum += yaku.getHan();
                }
            }
            return hanSum;
        }
    }
}
