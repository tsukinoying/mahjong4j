using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 七対子判定クラス
 * 対子のみで構成された場合成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class ChitoitsuResolver:NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.CHITOITSU;
        private int toitsuCount;

        public ChitoitsuResolver(MentsuComp comp)
        {
            toitsuCount = comp.getToitsuCount();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            return toitsuCount == 7;
        }
    }
}
