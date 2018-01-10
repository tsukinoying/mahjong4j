using mahjong4j.hands;
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
    public class RinshankaihohResolver:NormalYakuResolver
    {
        private  MentsuComp comp;
        private  PersonalSituation personalSituation;

        public RinshankaihohResolver(MentsuComp comp, PersonalSituation personalSituation)
        {
            this.comp = comp;
            this.personalSituation = personalSituation;
        }

        
        public NormalYaku getNormalYaku()
        {
            return NormalYaku.RINSHANKAIHOH;
        }

        
        public bool isMatch()
        {
            if (personalSituation == null)
            {
                return false;
            }

            if (comp.getKantsuCount() == 0)
            {
                return false;
            }

            return personalSituation.isRinshankaihoh();
        }
    }
}
