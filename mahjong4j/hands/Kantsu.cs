using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 槓子に関するクラスです
 * 暗槓と明槓の両方を扱います
 *
 * @author tsukinoying
 */
namespace mahjong4j.hands
{
    public class Kantsu : Mentsu
    {
        /**
     * 槓子が完成していることを前提にしているため
     * 槓子であるかのチェックは伴いません。
     *
     * @param isOpen         暗槓の場合false, 明槓の場合はtrueを入れて下さい
     * @param identifierTile どの牌の槓子なのか
     */
        public Kantsu(bool isOpen, Tile identifierTile)
        {
            this.isOpen_b = isOpen;
            this.identifierTile = identifierTile;
            this.isMentsu_b = true;
        }

        /**
         * 槓子であるかのチェックも伴います
         * すべての牌(tile1~4)が同じ場合にisMentsuがtrueになります
         *
         * @param isOpen 暗槓の場合false, 明槓の場合はtrueを入れて下さい
         * @param tile1  1枚目
         * @param tile2  2枚目
         * @param tile3  3枚目
         * @param tile4  4枚目
         */
        public Kantsu(bool isOpen, Tile tile1, Tile tile2, Tile tile3, Tile tile4)
        {
            this.isOpen_b = isOpen;
            if (this.isMentsu_b = check(tile1, tile2, tile3, tile4))
            {
                identifierTile = tile1;
            }
        }

        /**
         * tile1~4が同一の牌かを調べます
         *
         * @param tile1 1枚目
         * @param tile2 2枚目
         * @param tile3 3枚目
         * @param tile4 4枚目
         * @return 槓子の場合true 槓子でない場合false
         */
        public static bool check(Tile tile1, Tile tile2, Tile tile3, Tile tile4)
        {
            return tile1 == tile2 && tile2 == tile3 && tile3 == tile4;
        }
        public override int getFu()
        {
            int mentsuFu = 8;
            if (!isOpen_b)
            {
                mentsuFu *= 2;
            }
            if (identifierTile.isYaochu())
            {
                mentsuFu *= 2;
            }
            return mentsuFu;
        }
        public bool equals(Object o)
        {
            if (this == o) return true;
            if (!(o is Kantsu)) return false;

            Kantsu kantsu = (Kantsu)o;

            if (isMentsu_b != kantsu.isMentsu_b) return false;
            if (isOpen_b != kantsu.isOpen_b) return false;
            return identifierTile == kantsu.identifierTile;

        }
        public override int GetHashCode()
        {
            int result = identifierTile != null ? identifierTile.GetHashCode() : 0;
            result = 31 * result + (isMentsu_b ? 1 : 0);
            result = 31 * result + (isOpen_b ? 1 : 0);
            return result;
        }
    }
}
