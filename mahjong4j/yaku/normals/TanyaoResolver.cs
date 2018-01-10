using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 断么九判定クラス
 * 么九牌（一九字牌）を一切使わず、中張牌（数牌の2〜8）のみを使って手牌を完成させた場合に成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class TanyaoResolver:NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.TANYAO;
        private List<Mentsu> allMentsu;

        public TanyaoResolver(MentsuComp comp)
        {
            allMentsu = comp.getAllMentsu();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            foreach (Mentsu mentsu in allMentsu)
            {
                int number = mentsu.getTile().getNumber();
                if (number == 0 || number == 1 || number == 9)
                {
                    return false;
                }

                int shuntsuNum = mentsu.getTile().getNumber();
                bool isEdgeShuntsu = (shuntsuNum == 2 || shuntsuNum == 8);
                if (mentsu is Shuntsu && isEdgeShuntsu) {
                return false;
            }
        }

        return true;
    }
}
}
