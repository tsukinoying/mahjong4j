using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 四暗刻判定クラス
 * 暗刻を4つ作って和了した場合成立
 * 暗槓が含まれても良い
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.yakuman
{
    public class SuankoResolver: YakumanResolver
    {
        private int count;
        private List<Kotsu> kotsuList;
        private Yakuman yakuman = Yakuman.SUANKO;

        public SuankoResolver(MentsuComp comp)
        {
            kotsuList = comp.getKotsuKantsu();
            count = comp.getKotsuCount() + comp.getKantsuCount();
        }

        public Yakuman getYakuman()
        {
            return yakuman;
        }

        public bool isMatch()
        {
            if (count < 4)
            {
                return false;
            }
            foreach (Kotsu kotsu in kotsuList)
            {
                if (kotsu.isOpen())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
