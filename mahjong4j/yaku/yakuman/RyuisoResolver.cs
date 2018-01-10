using mahjong4j.hands;
using mahjong4j.tile;
using static mahjong4j.tile.Tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 緑一色判定クラス
 * 全ての牌が緑色の場合成立
 * すなわち索子の23468 發のみの場合成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.yakuman
{
    public class RyuisoResolver: YakumanResolver
    {
        private Yakuman yakuman = Yakuman.RYUISO;
        private List<Toitsu> toitsuList;
        private List<Shuntsu> shuntsuList;
        private List<Kotsu> kotsuList;

        public RyuisoResolver(MentsuComp hands)
        {
            toitsuList = hands.getToitsuList();
            shuntsuList = hands.getShuntsuList();
            kotsuList = hands.getKotsuKantsu();
        }

        public Yakuman getYakuman()
        {
            return yakuman;
        }

        public bool isMatch()
        {
            foreach (Toitsu toitsu in toitsuList)
            {
                if (!isGreen(toitsu.getTile()))
                {
                    return false;
                }
            }
            foreach (Kotsu kotsu in kotsuList)
            {
                if (!isGreen(kotsu.getTile()))
                {
                    return false;
                }
            }

            foreach (Shuntsu shuntsu in shuntsuList)
            {
                if (shuntsu.getTile() != S3)
                {
                    return false;
                }
            }

            return true;
        }

        /**
         * @param tile 評価する牌
         * @return 緑の牌かどうか
         */
        private bool isGreen(Tile tile)
        {
            return tile == HAT
                || tile == S2
                || tile == S3
                || tile == S4
                || tile == S6
                || tile == S8;
        }
    }
}
