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
    public class JikazeResolver : SituationResolver, NormalYakuResolver
    {
        private MentsuComp comp;

        public JikazeResolver(MentsuComp comp, GeneralSituation generalSituation, PersonalSituation personalSituation) : base(generalSituation, personalSituation)
        {

            this.comp = comp;
        }


        public NormalYaku getNormalYaku()
        {
            return NormalYaku.JIKAZE;
        }


        public bool isMatch()
        {
            if (isSituationsNull())
            {
                return false;
            }
            foreach (Kotsu kotsu in comp.getKotsuKantsu())
            {
                if (kotsu.getTile() == personalSituation.getJikaze())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
