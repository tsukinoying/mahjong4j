using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 順子に関するクラスです
 * 暗順子と明順子の両方を扱います
 *
 * @author tsukinoying
 */
namespace mahjong4j.hands
{
    public class Shuntsu : Mentsu
    {
        /**
     * 順子であることがわかっている場合に利用します
     *
     * @param isOpen         明順子ならばtrue 暗順子ならばfalse
     * @param identifierTile 順子の組の二番目
     */
        public Shuntsu(bool isOpen, Tile identifierTile)
        {
            setIdentifierTile(identifierTile);
            this.isOpen_b = isOpen;
            this.isMentsu_b = true;
        }

        /**
         * 順子であるかの判定も伴います
         *
         * @param isOpen 明順子ならばtrue 暗順子ならばfalseを入力して下さい
         * @param tile1  1枚目
         * @param tile2  2枚目
         * @param tile3  3枚目
         */
        public Shuntsu(bool isOpen, Tile tile1, Tile tile2, Tile tile3)
        {
            this.isOpen_b = isOpen;

            // TODO: 共通化
            //ソートする
            Tile s;
            if (tile1.getNumber() > tile2.getNumber())
            {
                s = tile1;
                tile1 = tile2;
                tile2 = s;
            }
            if (tile1.getNumber() > tile3.getNumber())
            {
                s = tile1;
                tile1 = tile3;
                tile3 = s;
            }
            if (tile2.getNumber() > tile3.getNumber())
            {
                s = tile2;
                tile2 = tile3;
                tile3 = s;
            }
            if (this.isMentsu_b = check(tile1, tile2, tile3))
            {
                identifierTile = tile2;
            }
        }

        /**
         * 順子かどうかの判定を行ないます
         *
         * @param tile1 1枚目
         * @param tile2 2枚目
         * @param tile3 3枚目
         * @return 順子であればtrue 順子でなければfalse
         */
        public static bool check(Tile tile1, Tile tile2, Tile tile3)
        {

            //Typeが違う場合false
            if (tile1.getType() != tile2.getType() || tile2.getType() != tile3.getType())
            {
                return false;
            }

            //字牌だった場合false
            if (tile1.getNumber() == 0 || tile2.getNumber() == 0 || tile3.getNumber() == 0)
            {
                return false;
            }

            //ソートする
            Tile s;
            if (tile1.getNumber() > tile2.getNumber())
            {
                s = tile1;
                tile1 = tile2;
                tile2 = s;
            }
            if (tile1.getNumber() > tile3.getNumber())
            {
                s = tile1;
                tile1 = tile3;
                tile3 = s;
            }
            if (tile2.getNumber() > tile3.getNumber())
            {
                s = tile2;
                tile2 = tile3;
                tile3 = s;
            }

            //判定
            return tile1.getNumber() + 1 == tile2.getNumber() && tile2.getNumber() + 1 == tile3.getNumber();
        }

        private void setIdentifierTile(Tile identifierTile)
        {
            if (identifierTile.isYaochu())
            {
                throw new IllegalShuntsuIdentifierException(identifierTile);
            }
            this.identifierTile = identifierTile;
        }


        public override int getFu()
        {
            return 0;
        }


        public bool equals(Object o)
        {
            if (this == o) return true;
            if (!(o is Shuntsu)) return false;

            Shuntsu shuntsu = (Shuntsu)o;

            if (isMentsu_b != shuntsu.isMentsu_b) return false;
            if (isOpen_b != shuntsu.isOpen_b) return false;
            return identifierTile == shuntsu.identifierTile;

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
