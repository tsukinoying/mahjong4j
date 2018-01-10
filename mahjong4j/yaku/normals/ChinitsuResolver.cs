using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 清一色判定クラス
 * 萬子、索子、筒子のどれか一種の牌だけで構成された場合成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class ChinitsuResolver : NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.CHINITSU;
        private MentsuComp comp;

        public ChinitsuResolver(MentsuComp comp)
        {
            this.comp = comp;
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            List<Mentsu> allMentsu = comp.getAllMentsu();
            TileType firstType = allMentsu[0].getTile().getType();

            if (firstType == TileType.FONPAI || firstType == TileType.SANGEN)
            {
                return false;
            }

            foreach (Mentsu mentsu in allMentsu)
            {
                TileType checkType = mentsu.getTile().getType();
                if (firstType != checkType)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
