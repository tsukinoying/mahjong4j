using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * @author tsukinoying
 */
namespace mahjong4j.yaku.yakuman
{
    public class RenhoResolver : YakumanResolver
    {
        private GeneralSituation generalSituation;
        private PersonalSituation personalSituation;

        public RenhoResolver(GeneralSituation generalSituation, PersonalSituation personalSituation)
        {
            this.generalSituation = generalSituation;
            this.personalSituation = personalSituation;
        }


        public Yakuman getYakuman()
        {
            return Yakuman.RENHO;
        }


        public bool isMatch()
        {
            // avoid NullPointerException
            if (generalSituation == null || personalSituation == null) return false;
            return generalSituation.isFirstRound() && !personalSituation.isTsumo() && !personalSituation.isParent();
        }
    }
}
