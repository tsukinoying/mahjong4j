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
    public class BakazeResolver : SituationResolver,NormalYakuResolver
    {
        private MentsuComp comp;
        
        public BakazeResolver(MentsuComp comp, GeneralSituation generalSituation, PersonalSituation personalSituation):base(generalSituation, personalSituation)
        {
            
            this.comp = comp;
        }

        public NormalYaku getNormalYaku()
        {
            return NormalYaku.BAKAZE;
        }


        public bool isMatch()
        {
            if ((isSituationsNull()))
            {
                return false;
            }
            foreach (Kotsu kotsu in comp.getKotsuKantsu())
            {
                if (kotsu.getTile() == generalSituation.getBakaze())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
