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
    public class SukantsuResolver: YakumanResolver
    {
        private int kantsuCount;
        private Yakuman yakuman = Yakuman.SUKANTSU;

        public SukantsuResolver(MentsuComp comp)
        {
            kantsuCount = comp.getKantsuCount();
        }

        public Yakuman getYakuman()
        {
            return yakuman;
        }

        public bool isMatch()
        {
            return kantsuCount == 4;
        }
    }
}
