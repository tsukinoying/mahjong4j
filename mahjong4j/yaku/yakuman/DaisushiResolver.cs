using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 大四喜判定クラス
 * 東・南・西・北の四種類をすべて刻子または槓子にして和了した場合に成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.yakuman
{
    public class DaisushiResolver:YakumanResolver
    {
        private Yakuman yakuman = Yakuman.DAISUSHI;

        private List<Kotsu> kotsuList;

        public DaisushiResolver(MentsuComp comp)
        {
            kotsuList = comp.getKotsuKantsu();
        }

        public Yakuman getYakuman()
        {
            return yakuman;
        }

        public bool isMatch()
        {
            int fonpaiCount = 0;
            foreach (Kotsu kotsu in kotsuList)
            {
                if (kotsu.getTile().getType() == TileType.FONPAI)
                {
                    fonpaiCount++;
                }
            }

            return fonpaiCount == 4;
        }
    }
}
