using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 九蓮宝燈判定クラス
 * 門前で「1112345678999+X」の形をあがった場合に成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.yakuman
{
    public class ChurenpohtohResolver : YakumanResolver
    {
        private int[] churenManzu = { 3, 1, 1, 1, 1, 1, 1, 1, 3 };

        private Yakuman yakuman = Yakuman.CHURENPOHTO;
        private Toitsu janto;
        private List<Shuntsu> shuntsuList;
        private List<Kotsu> kotsuList;

        public ChurenpohtohResolver(MentsuComp comp)
        {
            janto = comp.getJanto();
            shuntsuList = comp.getShuntsuList();
            kotsuList = comp.getKotsuList();
        }

        public Yakuman getYakuman()
        {
            return yakuman;
        }

        public bool isMatch()
        {
            if (janto == null)
            {
                return false;
            }
            if (janto.getTile().getNumber() == 0)
            {
                return false;
            }
            TileType type = janto.getTile().getType();

            int[] churen = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            churen[janto.getTile().getNumber() - 1] = 2;

            foreach (Shuntsu shuntsu in shuntsuList)
            {
                if (shuntsu.getTile().getType() != type)
                {
                    return false;
                }
                churen[shuntsu.getTile().getNumber() - 2]++;
                churen[shuntsu.getTile().getNumber() - 1]++;
                churen[shuntsu.getTile().getNumber()]++;
            }

            foreach (Kotsu kotsu in kotsuList)
            {
                if (kotsu.getTile().getType() != type)
                {
                    return false;
                }
                churen[kotsu.getTile().getNumber() - 1] += 3;
            }

            bool restOne = false;
            for (int i = 0; i < churen.Length; i++)
            {
                int num = churen[i] - churenManzu[i];
                if (num == 1 && !restOne)
                {
                    restOne = true;
                    continue;
                }

                if (num == 1)
                {
                    return false;
                }

                if (num < 0 || num > 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
