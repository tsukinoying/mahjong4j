using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 小四喜判定クラス
 * 4つの風牌東 南 西 北のうち3つを刻子1つを雀頭に含めて和了した時に成立
 * 4つのうち3つを刻子にし残る1つを雀頭にした場合
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.yakuman
{
    public class ShosushiResolver: YakumanResolver
    {
        private Yakuman yakuman = Yakuman.SHOSUSHI;
        private Toitsu janto;
        private List<Kotsu> kotsuList;
        private int kotsuCount;

        public ShosushiResolver(MentsuComp comp)
        {
            janto = comp.getJanto();
            kotsuList = comp.getKotsuKantsu();
            kotsuCount = comp.getKotsuCount() + comp.getKantsuCount();
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

            if (janto.getTile().getType() != tile.TileType.FONPAI)
            {
                return false;
            }
            if (kotsuCount < 3)
            {
                return false;
            }

            int shosushiCount = 0;
            foreach (Kotsu kotsu in kotsuList)
            {
                if (kotsu.getTile().getType() == tile.TileType.FONPAI)
                {
                    shosushiCount++;
                }
            }
            return shosushiCount == 3;
        }
    }
}
