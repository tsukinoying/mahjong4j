using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 大三元判定クラス
 * 白・發・中の3種類をすべて刻子または槓子にして和了した場合に成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.yakuman
{
    public class DaisangenResolver : YakumanResolver
    {
        private Yakuman yakuman = Yakuman.DAISANGEN;

        private List<Kotsu> kotsuList;

        public DaisangenResolver(MentsuComp comp)
        {
            kotsuList = comp.getKotsuKantsu();
        }

        public Yakuman getYakuman()
        {
            return yakuman;
        }

        public bool isMatch()
        {
            int sangenCount = 0;
            foreach (Kotsu kotsu in kotsuList)
            {
                if (kotsu.getTile().getType() == TileType.SANGEN)
                {
                    sangenCount++;
                }
            }

            return sangenCount == 3;
        }
    }
}
