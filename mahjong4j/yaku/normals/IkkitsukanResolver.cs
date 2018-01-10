using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 一気通貫判定クラス
 * 同種の数牌で123・456・789と揃えると成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class IkkitsukanResolver:NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.IKKITSUKAN;

        private List<Shuntsu> shuntsuList;
        private int shuntsuCount;

        public IkkitsukanResolver(MentsuComp comp)
        {
            shuntsuList = comp.getShuntsuList();
            shuntsuCount = comp.getShuntsuCount();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            if (shuntsuCount < 3)
            {
                return false;
            }

            List<Shuntsu> manzu = new List<Shuntsu>(4);
            List<Shuntsu> sohzu = new List<Shuntsu>(4);
            List<Shuntsu> pinzu = new List<Shuntsu>(4);

            //各タイプに振り分ける
            foreach (Shuntsu shuntsu in shuntsuList)
            {
                TileType type = shuntsu.getTile().getType();
                if (type == TileType.MANZU)
                {
                    manzu.Add(shuntsu);
                }
                else if (type == TileType.SOHZU)
                {
                    sohzu.Add(shuntsu);
                }
                else if (type == TileType.PINZU)
                {
                    pinzu.Add(shuntsu);
                }
            }

            if (manzu.Count() >= 3)
            {
                return isIkkitsukan(manzu);
            }
            if (sohzu.Count() >= 3)
            {
                return isIkkitsukan(sohzu);
            }
            if (pinzu.Count() >= 3)
            {
                return isIkkitsukan(pinzu);
            }
            return false;
        }

        /**
         * 123 456 789が全て含まれるかを判定します
         * 例えば萬子の順子のみが含まれる場合に正しく動作します
         * 逆に、萬子123 筒子 456 789の場合もtrueになってしまいます
         *
         * @param oneTypeShuntsuList 単一のタイプの順子リスト
         * @return 123 456 789が全て含まれるか
         */
        private bool isIkkitsukan(List<Shuntsu> oneTypeShuntsuList)
        {
            //この3つが全てtrueになれば一気通貫
            bool number2 = false;
            bool number5 = false;
            bool number8 = false;

            foreach (Shuntsu shuntsu in oneTypeShuntsuList)
            {
                int num = shuntsu.getTile().getNumber();
                if (num == 2)
                {
                    number2 = true;
                }
                else if (num == 5)
                {
                    number5 = true;
                }
                else if (num == 8)
                {
                    number8 = true;
                }
            }
            return number2 && number5 && number8;
        }
    }
}
