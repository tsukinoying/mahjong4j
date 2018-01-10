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
    public class TsumoResolver: NormalYakuResolver
    {
        private MentsuComp comp;
        private GeneralSituation generalSituation;
        private PersonalSituation personalSituation;

        public TsumoResolver(MentsuComp comp, GeneralSituation generalSituation, PersonalSituation personalSituation)
        {
            this.comp = comp;
            this.generalSituation = generalSituation;
            this.personalSituation = personalSituation;
        }

        
        public NormalYaku getNormalYaku()
        {
            return NormalYaku.TSUMO;
        }

        
        public bool isMatch()
        {
            if (generalSituation == null || personalSituation == null)
            {
                return false;
            }
            bool isOpen = false;
            foreach (Mentsu mentsu in comp.getAllMentsu())
            {
                if (mentsu.isOpen())
                {
                    isOpen = true;
                }
            }
            return personalSituation.isTsumo() && !isOpen;
        }
    }
}
