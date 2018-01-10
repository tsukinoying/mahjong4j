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
    public class ChankanResolver : SituationResolver, NormalYakuResolver
    {
        public ChankanResolver(GeneralSituation generalSituation, PersonalSituation personalSituation):base(generalSituation, personalSituation)
        {
            
        }
        public NormalYaku getNormalYaku()
        {
            return NormalYaku.CHANKAN; 
        }

        public bool isMatch()
        {
            if (isSituationsNull())
            {
                return false;
            }
            return personalSituation.isChankan();
        }
    }
}
