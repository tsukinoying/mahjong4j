using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static mahjong4j.tile.TileType;

namespace mahjong4j.tile
{
    public class Tile
    {
        public static Tile M1 = new Tile(0, MANZU, 1);
        public static Tile M2 = new Tile(1, MANZU, 2);
        public static Tile M3 = new Tile(2, MANZU, 3);
        public static Tile M4 = new Tile(3, MANZU, 4);
        public static Tile M5 = new Tile(4, MANZU, 5);
        public static Tile M6 = new Tile(5, MANZU, 6);
        public static Tile M7 = new Tile(6, MANZU, 7);
        public static Tile M8 = new Tile(7, MANZU, 8);
        public static Tile M9 = new Tile(8, MANZU, 9);

        public static Tile P1 = new Tile(9, PINZU, 1);
        public static Tile P2 = new Tile(10, PINZU, 2);
        public static Tile P3 = new Tile(11, PINZU, 3);
        public static Tile P4 = new Tile(12, PINZU, 4);
        public static Tile P5 = new Tile(13, PINZU, 5);
        public static Tile P6 = new Tile(14, PINZU, 6);
        public static Tile P7 = new Tile(15, PINZU, 7);
        public static Tile P8 = new Tile(16, PINZU, 8);
        public static Tile P9 = new Tile(17, PINZU, 9);

        public static Tile S1 = new Tile(18, SOHZU, 1);
        public static Tile S2 = new Tile(19, SOHZU, 2);
        public static Tile S3 = new Tile(20, SOHZU, 3);
        public static Tile S4 = new Tile(21, SOHZU, 4);
        public static Tile S5 = new Tile(22, SOHZU, 5);
        public static Tile S6 = new Tile(23, SOHZU, 6);
        public static Tile S7 = new Tile(24, SOHZU, 7);
        public static Tile S8 = new Tile(25, SOHZU, 8);
        public static Tile S9 = new Tile(26, SOHZU, 9);

        public static Tile TON = new Tile(27, FONPAI, 0);//東
        public static Tile NAN = new Tile(28, FONPAI, 0);//南
        public static Tile SHA = new Tile(29, FONPAI, 0);//西
        public static Tile PEI = new Tile(30, FONPAI, 0);//北

        public static Tile HAK = new Tile(31, SANGEN, 0);//白
        public static Tile HAT = new Tile(32, SANGEN, 0);//発
        public static Tile CHN = new Tile(33, SANGEN, 0);//中

        private int code;
        private TileType type;
        private int number;


        Tile(int code, TileType type, int number)
        {
            this.code = code;
            this.type = type;
            this.number = number;
        }

        
        public static Tile valueOf(int c)
        {
            switch (c)
            {
                case 0:
                    return Tile.M1;
                case 1:
                    return Tile.M2;
                case 2:
                    return Tile.M3;
                case 3:
                    return Tile.M4;
                case 4:
                    return Tile.M5;
                case 5:
                    return Tile.M6;
                case 6:
                    return Tile.M7;
                case 7:
                    return Tile.M8;
                case 8:
                    return Tile.M9;
                case 9:
                    return Tile.P1;
                case 10:
                    return Tile.P2;
                case 11:
                    return Tile.P3;
                case 12:
                    return Tile.P4;
                case 13:
                    return Tile.P5;
                case 14:
                    return Tile.P6;
                case 15:
                    return Tile.P7;
                case 16:
                    return Tile.P8;
                case 17:
                    return Tile.P9;
                case 18:
                    return Tile.S1;
                case 19:
                    return Tile.S2;
                case 20:
                    return Tile.S3;
                case 21:
                    return Tile.S4;
                case 22:
                    return Tile.S5;
                case 23:
                    return Tile.S6;
                case 24:
                    return Tile.S7;
                case 25:
                    return Tile.S8;
                case 26:
                    return Tile.S9;
                case 27:
                    return Tile.TON;
                case 28:
                    return Tile.NAN;
                case 29:
                    return Tile.SHA;
                case 30:
                    return Tile.PEI;
                case 31:
                    return Tile.HAK;
                case 32:
                    return Tile.HAT;
                case 33:
                    return Tile.CHN;
                default:
                    return null;
                   
            }
            //return Tile.()[c];
        }
        public int getCode()
        {
            return code;
        }

        public TileType getType()
        {
            return type;
        }

        public int getNumber()
        {
            return number;
        }

        public bool isYaochu()
        {
            return number == 0 || number == 1 || number == 9;
        }
    }
    
}
