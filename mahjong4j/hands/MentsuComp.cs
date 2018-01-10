using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 上がれる面子を整理したクラスです
 *
 * @author tsukinoying
 */
namespace mahjong4j.hands
{
    public class MentsuComp
    {
        private List<Toitsu> toitsuList = new List<Toitsu>(7);
        private List<Shuntsu> shuntsuList = new List<Shuntsu>(4);
        private List<Kotsu> kotsuList = new List<Kotsu>(4);
        private List<Kantsu> kantsuList = new List<Kantsu>(4);
        private Tile last;
        /**
         * @param mentsuList 上がりとなった面子のリスト
         * @param last
         * @throws IllegalMentsuSizeException 和了れる形になっていなければthrow
         */
        public MentsuComp(List<Mentsu> mentsuList, Tile last)
        {
            this.last = last;
            
            foreach(Mentsu mentsu in mentsuList)
            {
                setMentsu(mentsu);
            }
            //整合性を確認する
            int checkSum = shuntsuList.Count() + kotsuList.Count() + kantsuList.Count();
            bool isNormal = checkSum == 4 && toitsuList.Count() == 1;
            bool isChitoitsu = toitsuList.Count() == 7 && checkSum == 0;
            if (!isNormal && !isChitoitsu)
            {
                throw new IllegalMentsuSizeException(mentsuList);
            }
        }
        /**
         * どの面子が入っても対応可能なセッター
         *
         * @param mentsu 入力したい面子
         */
        private void setMentsu(Mentsu mentsu)
        {
            if (mentsu is Toitsu)
            {
                toitsuList.Add((Toitsu)mentsu);
            }
            else if (mentsu is Shuntsu)
            {
                shuntsuList.Add((Shuntsu)mentsu);
            }
            else if (mentsu is Kotsu)
            {
                kotsuList.Add((Kotsu)mentsu);
            }
            else if (mentsu is Kantsu)
            {
                kantsuList.Add((Kantsu)mentsu);
            }
        }
        /**
         * 七対子の場合はnullを返します
         *
         * @return 雀頭を返します
         */
        public Toitsu getJanto()
        {
            if (getToitsuCount() == 1)
            {
                return toitsuList[0];
            }
            return null;
        }
        public List<Toitsu> getToitsuList()
        {
            return toitsuList;
        }

        /**
         * 対子の数を返します
         * 1もしくは7以外を返すことはありません
         *
         * @return 通常の型の場合1 七対子の型の場合7
         */
        public int getToitsuCount()
        {
            return toitsuList.Count();
        }

        public List<Shuntsu> getShuntsuList()
        {
            return shuntsuList;
        }

        /**
         * 順子の数を返します
         * 0~4のどれかです
         *
         * @return 順子の数
         */
        public int getShuntsuCount()
        {
            return shuntsuList.Count();
        }

        public List<Kotsu> getKotsuList()
        {
            return kotsuList;
        }

        /**
         * 刻子でも槓子でも役の判定に影響しない場合に利用します
         * 刻子と槓子をまとめて返します。
         * TODO:good name
         *
         * @return 刻子と槓子をまとめたリスト
         */
        public List<Kotsu> getKotsuKantsu()
        {
            List<Kotsu> kotsuList = new List<Kotsu>(this.kotsuList);
            foreach (Kantsu kantsu in kantsuList)
            {
                kotsuList.Add(new Kotsu(kantsu.isOpen(), kantsu.getTile()));
            }
            return kotsuList;
        }

        /**
         * 刻子の数を返します
         * 0~4のどれかです
         *
         * @return 刻子の数
         */
        public int getKotsuCount()
        {
            return kotsuList.Count();
        }

        public List<Kantsu> getKantsuList()
        {
            return kantsuList;
        }

        /**
         * 槓子の数を返します
         * 0~4のどれかです
         *
         * @return 槓子の数
         */
        public int getKantsuCount()
        {
            return kantsuList.Count();
        }

        /**
         * 対子も含めて全ての面子をリストにして返します
         *
         * @return 構成する全ての面子のリスト
         */
        public List<Mentsu> getAllMentsu()
        {
            List<Mentsu> allMentsu = new List<Mentsu>(7);
           
            allMentsu.AddRange(getToitsuList());
            allMentsu.AddRange(getShuntsuList());
            allMentsu.AddRange(getKotsuList());
            allMentsu.AddRange(getKantsuList());

            return allMentsu;
        }

        public Tile getLast()
        {
            return last;
        }

        public bool isRyanmen(Tile last)
        {
            foreach (Shuntsu shuntsu in shuntsuList)
            {
                if (shuntsu.isOpen())
                {
                    continue;
                }
                if (shuntsu.getTile().getType() != last.getType())
                {
                    continue;
                }

                int number = shuntsu.getTile().getNumber();
                if (number == 8 || number == 2)
                {
                    continue;
                }

                if (number - 1 == last.getNumber() || number + 1 == last.getNumber())
                {
                    return true;
                }
            }

            return false;
        }

        public bool isTanki(Tile last)
        {
            return getJanto().getTile() == last;
        }

        public bool isKanchan(Tile last)
        {
            if (isRyanmen(last))
            {
                return false;
            }
            foreach (Shuntsu shuntsu in shuntsuList)
            {
                if (shuntsu.isOpen() || shuntsu.getTile().getType() != last.getType())
                {
                    continue;
                }
                if (shuntsu.getTile().getNumber() == last.getNumber())
                {
                    return true;
                }
            }
            return false;
        }

        public bool isPenchan(Tile last)
        {
            if (isRyanmen(last))
            {
                return false;
            }
            foreach (Shuntsu shuntsu in shuntsuList)
            {
                if (shuntsu.isOpen() || shuntsu.getTile().getType() != last.getType())
                {
                    continue;
                }
                int number = shuntsu.getTile().getNumber();
                if (number == 8 && last.getNumber() == 7)
                {
                    return true;
                }
                if (number == 2 && last.getNumber() == 3)
                {
                    return true;
                }
            }
            return false;
        }
        /**
     * 各面子のリストの順番は関係ないので、
     * 面子の順番が違っていてもtrueになります
     *
     * @param o
     * @return
     */
        
    public bool equals(Object o)
        {
            if (this == o) return true;
            if (!(o is MentsuComp)) return false;

            MentsuComp that = (MentsuComp)o;

            if (last != that.last) return false;
            if (toitsuList.Count() != that.toitsuList.Count()) return false;
            if (shuntsuList.Count() != that.shuntsuList.Count()) return false;
            if (kotsuList.Count() != that.kotsuList.Count()) return false;
            if (kantsuList.Count() != that.kantsuList.Count()) return false;
            foreach (Toitsu toitsu in toitsuList)
            {
                if (!that.toitsuList.Contains(toitsu)) return false;
            }
            foreach (Shuntsu shuntsu in shuntsuList)
            {
                if (!that.shuntsuList.Contains(shuntsu)) return false;
            }
            foreach (Kotsu kotsu in kotsuList)
            {
                if (!that.kotsuList.Contains(kotsu)) return false;
            }
            foreach (Kantsu kantsu in kantsuList)
            {
                if (!that.kantsuList.Contains(kantsu)) return false;
            }

            return true;
        }

 
        public int hashCode()
        {
            int tmp = 0;
            int result;

            result = last.GetHashCode();
            

            if (toitsuList != null)
            {
                foreach (Toitsu toitsu in toitsuList)
                {
                    tmp += toitsu.GetHashCode();
                }
            }
            result = 31 * result + tmp;

            tmp = 0;
            if (shuntsuList != null)
            {
                foreach (Shuntsu shuntsu in shuntsuList)
                {
                    tmp += shuntsu.GetHashCode();
                }
            }

            result = 31 * result + tmp;

            tmp = 0;
            if (kotsuList != null)
            {
                foreach (Kotsu kotsu in kotsuList)
                {
                    tmp += kotsu.GetHashCode();
                }
            }

            result = 31 * result + tmp;

            tmp = 0;
            if (kantsuList != null)
            {
                foreach (Kantsu kantsu in kantsuList)
                {
                    tmp += kantsu.GetHashCode();
                }
            }

            return 31 * result + tmp;
        }

    }
}
