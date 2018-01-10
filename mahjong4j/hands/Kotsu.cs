using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 刻子に関するクラスです
 * 暗刻と明刻の両方を扱います
 *
 * @author tsukinoying
 */
namespace mahjong4j.hands
{
    public class Kotsu : Mentsu
    {
        /**
         * 刻子であることがわかっている場合に利用します
         *
         * @param isOpen         暗刻ならばfalse 明刻ならばtrue
         * @param identifierTile どの牌の刻子なのか
         */
        public Kotsu(bool isOpen, Tile identifierTile)
        {
            this.identifierTile = identifierTile;
            this.isOpen_b = isOpen;
            this.isMentsu_b = true;
        }
        /**
         * 刻子であるかのチェックも伴います
         * すべての牌(tile1~3)が同じ場合にisMentsuがtrueになります
         *
         * @param isOpen 暗刻の場合false, 明刻の場合はtrueを入れて下さい
         * @param tile1  1枚目
         * @param tile2  2枚目
         * @param tile3  3枚目
         */
        public Kotsu(bool isOpen, Tile tile1, Tile tile2, Tile tile3)
        {
            this.isOpen_b = isOpen;
            if (this.isMentsu_b = check(tile1, tile2, tile3))
            {
                identifierTile = tile1;
            }
        }
        /**
         * 刻子であるかの判定を行ないます
         *
         * @param tile1 1枚目
         * @param tile2 2枚目
         * @param tile3 3枚目
         * @return 刻子であればtrue 刻子でなければfalse
         */
        public static bool check(Tile tile1, Tile tile2, Tile tile3)
        {
            return tile1 == tile2 && tile2 == tile3;
        }

        public override int getFu()
        {
            int mentsuFu = 2;
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
            if (!(o is Kotsu)) return false;

            Kotsu kotsu = (Kotsu)o;

            if (isMentsu_b != kotsu.isMentsu_b) return false;
            if (isOpen_b != kotsu.isOpen_b) return false;
            return identifierTile == kotsu.identifierTile;

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
