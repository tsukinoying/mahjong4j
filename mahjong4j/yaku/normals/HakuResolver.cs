using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 白判定クラス
 * 白の刻子もしくは槓子が含まれる場合成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class HakuResolver:NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.HAKU;
        private List<Kotsu> kotsuList;

        public HakuResolver(MentsuComp comp)
        {
            kotsuList = comp.getKotsuKantsu();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            foreach (Kotsu kotsu in kotsuList)
            {
                if (kotsu.getTile() == Tile.HAK)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
