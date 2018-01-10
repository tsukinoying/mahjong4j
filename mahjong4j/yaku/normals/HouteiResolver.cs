using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 最後の牌でロン和了した場合に成立
 *
 * @author yu1ro
 */
namespace mahjong4j.yaku.normals
{
    public class HouteiResolver : SituationResolver, NormalYakuResolver
    {
        public HouteiResolver(GeneralSituation generalSituation, PersonalSituation personalSituation) : base(generalSituation, personalSituation)
        {

        }


        public NormalYaku getNormalYaku()
        {
            return NormalYaku.HOUTEI;
        }


        public bool isMatch()
        {
            if (isSituationsNull())
            {
                return false;
            }
            return generalSituation.isHoutei() && !personalSituation.isTsumo();
        }
    }
}
