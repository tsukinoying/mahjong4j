using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 平和判定クラス
 * 面子が全て順子で、雀頭が役牌でなく、待ちが両面待ちになっている場合に成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class PinfuResolver:SituationResolver,NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.PINFU;

        private Toitsu janto;
        private int shuntsuCount;
        private List<Shuntsu> shuntsuList;
        private Tile last;


        public PinfuResolver(MentsuComp comp, GeneralSituation generalSituation, PersonalSituation personalSituation):base(generalSituation, personalSituation)
        {
           
            janto = comp.getJanto();
            shuntsuCount = comp.getShuntsuCount();
            shuntsuList = comp.getShuntsuList();
            last = comp.getLast();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            if (shuntsuCount < 4)
            {
                return false;
            }
            //雀頭が三元牌の場合はfalse
            Tile janto = this.janto.getTile();
            if (janto.getType() == TileType. SANGEN)
            {
                return false;
            }

            if (!isSituationsNull())
            {
                if (janto == generalSituation.getBakaze())
                {
                    return false;
                }
                if (janto == personalSituation.getJikaze())
                {
                    return false;
                }
            }

            bool isRyanmen_b = false;
            foreach (Shuntsu shuntsu in shuntsuList)
            {
                //鳴いていた場合もfalse
                if (shuntsu.isOpen())
                {
                    return false;
                }

                //両面待ちならそれを保存しておく
                if (isRyanmen(shuntsu, last))
                {
                    isRyanmen_b = true;
                }
            }

            return isRyanmen_b;
        }

        /**
         * 両面待ちだったかを判定するため
         * 一つ一つの順子と最後の牌について判定する
         *
         * @param shuntsu 判定したい順子
         * @param last    最後の牌
         * @return 両面待ちだったか
         */
        private bool isRyanmen(Shuntsu shuntsu, Tile last)
        {
            //ラスト牌と判定したい順子のtypeが違う場合はfalse
            if (shuntsu.getTile().getType() != last.getType())
            {
                return false;
            }

            int shuntsuNum = shuntsu.getTile().getNumber();
            int lastNum = last.getNumber();
            if (shuntsuNum == 2 && lastNum == 1)
            {
                return true;
            }

            if (shuntsuNum == 8 && lastNum == 9)
            {
                return true;
            }

            int i = shuntsuNum - lastNum;
            if (i == 1 || i == -1)
            {
                return true;
            }

            return false;
        }
    }
}
