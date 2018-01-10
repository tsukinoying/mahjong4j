using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class DoubleReachResolver:SituationResolver,NormalYakuResolver
    {
        public DoubleReachResolver(GeneralSituation generalSituation, PersonalSituation personalSituation):base(generalSituation, personalSituation)
        {
            
        }
        public NormalYaku getNormalYaku()
        {
            return NormalYaku.DOUBLE_REACH;
        }

       
        public bool isMatch()
        {
            if (isSituationsNull())
            {
                return false;
            }
            return personalSituation.isDoubleReach() && personalSituation.isReach();
        }
    }
}
