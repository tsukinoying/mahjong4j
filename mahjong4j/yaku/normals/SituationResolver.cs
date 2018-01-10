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
    public abstract class SituationResolver
    {
        protected GeneralSituation generalSituation;
        protected PersonalSituation personalSituation;

        protected SituationResolver(GeneralSituation generalSituation, PersonalSituation personalSituation)
        {
            this.generalSituation = generalSituation;
            this.personalSituation = personalSituation;
        }

        protected bool isSituationsNull()
        {
            return personalSituation == null || generalSituation == null;
        }

    }
}
