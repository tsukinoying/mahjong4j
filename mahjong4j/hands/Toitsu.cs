using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * @author tsukinoying
 */
namespace mahjong4j.hands
{
    public class Toitsu : Mentsu
    {
        /**
     * 対子であることがわかっている場合に使います
     *
     * @param identifierTile 対子の種類
     */
        public Toitsu(Tile identifierTile)
        {
            this.identifierTile = identifierTile;
            this.isMentsu_b = true;
        }

        /**
         * 対子であるかのチェックを伴います
         *
         * @param tile1 1枚目
         * @param tile2 2枚目
         */
        public Toitsu(Tile tile1, Tile tile2)
        {
            if (this.isMentsu_b = Toitsu.check(tile1, tile2))
            {
                this.identifierTile = tile1;
            }
        }

        /**
         * @param tile1 1枚目
         * @param tile2 2枚目
         * @return 2枚が一致すればtrue
         */
        public static bool check(Tile tile1, Tile tile2)
        {
            return tile1 == tile2;
        }

        /**
         * 対子になりうる牌をリストにして返す
         *
         * @param tiles 手牌
         * @return 雀頭候補の対子リスト
         */
        public static List<Toitsu> findJantoCandidate(int[] tiles)
        {
            List<Toitsu> result = new List<Toitsu>(7);
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i] > 4)
                {
                    throw new MahjongTileOverFlowException(i, tiles[i]);
                }
                if (tiles[i] >= 2)
                {
                    result.Add(new Toitsu(Tile.valueOf(i)));
                }
            }
            return result;
        }


        public override int getFu()
        {
            return 0;
        }


        public bool equals(Object o)
        {
            if (this == o) return true;
            if (!(o is Toitsu)) return false;

            Toitsu toitsu = (Toitsu)o;

            if (isMentsu_b != toitsu.isMentsu_b) return false;
            return identifierTile == toitsu.identifierTile;

        }


        public override int GetHashCode()
        {
            int result = identifierTile != null ? identifierTile.GetHashCode() : 0;
            result = 31 * result + (isMentsu_b ? 1 : 0);
            return result;
        }
    }
}
