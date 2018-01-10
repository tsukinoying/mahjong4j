using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 三槓子判定クラス
 * 槓子が３つ存在する場合に成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class SankantsuResolver:NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.SANKANTSU;
        private int kantsuCount;

        public SankantsuResolver(MentsuComp comp)
        {
            kantsuCount = comp.getKantsuCount();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            return kantsuCount == 3;
        }
    }
}
