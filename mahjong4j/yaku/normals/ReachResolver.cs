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
    public class ReachResolver : SituationResolver,NormalYakuResolver
    {
        public ReachResolver(GeneralSituation generalSituation, PersonalSituation personalSituation):base(generalSituation, personalSituation)
        {
            
        }

        
        public NormalYaku getNormalYaku()
        {
            return NormalYaku.REACH;
        }

        
        public bool isMatch()
        {
            if (isSituationsNull())
            {
                return false;
            }
            return personalSituation.isReach();
        }
    }
}
