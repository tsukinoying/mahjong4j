using mahjong4j.hands;
using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 小三元判定クラス
 * 三元牌のいずれかを雀頭とし、残り2つを刻子もしくは槓子にすることで成立
 *
 * @author tsukinoying
 */
namespace mahjong4j.yaku.normals
{
    public class ShosangenResolver: NormalYakuResolver
    {
        private NormalYaku yakuEnum = NormalYaku.SHOSANGEN;

        private Toitsu janto;
        private List<Kotsu> kotsuList;

        public ShosangenResolver(MentsuComp comp)
        {
            janto = comp.getJanto();
            kotsuList = comp.getKotsuKantsu();
        }

        public NormalYaku getNormalYaku()
        {
            return yakuEnum;
        }

        public bool isMatch()
        {
            //七対子の場合はありえないのでfalse
            if (janto == null)
            {
                return false;
            }

            if (janto.getTile().getType() != TileType.SANGEN)
            {
                return false;
            }
            int count = 0;
            foreach (Kotsu kotsu in kotsuList)
            {
                if (kotsu.getTile().getType() == TileType.SANGEN)
                {
                    count++;
                }
                if (count == 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
