using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 最後の牌でツモ和了した場合に成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class HaiteiResolver : SituationResolver, NormalYakuResolver
    {
        public HaiteiResolver(GeneralSituation generalSituation, PersonalSituation personalSituation) : base(generalSituation, personalSituation)
        {

        }


        public NormalYaku getNormalYaku()
        {
            return NormalYaku.HAITEI;
        }


        public bool isMatch()
        {
            if (isSituationsNull())
            {
                return false;
            }

            return generalSituation.isHoutei() && personalSituation.isTsumo();
        }
    }
}
