using mahjong4j.tile;
using static mahjong4j.tile.TileType;
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
    public abstract class SanshokuResolver:NormalYakuResolver
    {
        protected bool manzu = false;
        protected bool pinzu = false;
        protected bool sohzu = false;

        public abstract NormalYaku getNormalYaku();
        public abstract bool isMatch();

        protected void detectType(TileType shuntsuType)
        {
            if (shuntsuType == MANZU)
            {
                manzu = true;
            }
            else if (shuntsuType == PINZU)
            {
                pinzu = true;
            }
            else if (shuntsuType == SOHZU)
            {
                sohzu = true;
            }
        }
    }
}
