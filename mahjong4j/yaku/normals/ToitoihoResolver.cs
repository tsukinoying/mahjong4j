using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 対々和判定クラス
 * 刻子を4つ作って和了した場合に成立（槓子が含まれていてもよい）
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class ToitoihoResolver:NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.TOITOIHO;
        private int kotsuCount;

        public ToitoihoResolver(MentsuComp comp)
        {
            kotsuCount = comp.getKantsuCount() + comp.getKotsuCount();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            return kotsuCount == 4;
        }
    }
}
