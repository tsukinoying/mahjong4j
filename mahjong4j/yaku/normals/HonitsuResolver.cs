using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 混一色判定クラス
 * 萬子、索子、筒子のどれか一種と、字牌のみで構成される場合成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class HonitsuResolver:NormalYakuResolver
    {
        private  NormalYaku yakuEnum = NormalYaku.HONITSU;

        private List<Mentsu> allMentsu;

        private bool hasJihai = false;
        private TileType type = TileType.Null;

        public HonitsuResolver(MentsuComp comp)
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
                if (!hasOnlyOneType(mentsu))
                {
                    return false;
                }
            }

            return hasJihai;
        }

        private bool hasOnlyOneType(Mentsu mentsu)
        {
            if (mentsu.getTile().getNumber() == 0)
            {
                hasJihai = true;
            }
            else if (type == TileType.Null)
            {
                type = mentsu.getTile().getType();
            }
            else if (type != mentsu.getTile().getType())
            {
                return false;
            }
            return true;
        }
    }
}
