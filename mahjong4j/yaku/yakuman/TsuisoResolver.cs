using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 字一色判定クラス
 * 字牌のみで構成された場合に成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.yakuman
{
    public class TsuisoResolver: YakumanResolver
    {
        private Yakuman yakuman = Yakuman.TSUISO;

        private Toitsu janto;
        private List<Shuntsu> shuntsuList;
        private List<Toitsu> toitsuList;
        private List<Kotsu> kotsuList;

        public TsuisoResolver(MentsuComp comp)
        {
            janto = comp.getJanto();
            shuntsuList = comp.getShuntsuList();
            toitsuList = comp.getToitsuList();
            kotsuList = comp.getKotsuKantsu();
        }

        public Yakuman getYakuman()
        {
            return yakuman;
        }

        public bool isMatch()
        {
            if (shuntsuList.Count() > 0)
            {
                return false;
            }
            if (janto == null)
            {
                foreach (Toitsu toitsu in toitsuList)
                {
                    if (toitsu.getTile().getNumber() != 0)
                    {
                        return false;
                    }
                }
                return true;
            }

            if (janto.getTile().getNumber() != 0)
            {
                return false;
            }

            foreach (Kotsu kotsu in kotsuList)
            {
                if (kotsu.getTile().getNumber() != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
