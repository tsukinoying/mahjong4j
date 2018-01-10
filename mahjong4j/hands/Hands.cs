using mahjong4j.tile;
using mahjong4j.yaku.yakuman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 手牌に関する操作全般を扱います
 * このクラスのインスタンスをMahjongクラスに投げると
 * 点数が返ってくるようにしたいと考えています
 * TODO: ツモって牌を捨てるオペレーションメソッド
 *
 * @author tsukinoying
 */
namespace mahjong4j.hands
{
    public class Hands
    {
        // -------------------------確定系-----------------------

        //確定した上がりの形のリスト
        private HashSet<MentsuComp> mentsuCompSet = new HashSet<MentsuComp>();

        //確定した各牌の数一覧
        private int[] handsComp = new int[34];

        //最後の牌
        private Tile last;

        //あがれるか
        private bool canWin = false;

        //食い下がりかどうか
        private bool isOpen_b = false;

        // ------------------------ストック系----------------------

        // コンストラクタで入力された面子リスト
        private List<Mentsu> inputtedMentsuList = new List<Mentsu>();

        // 操作する用のストック
        private int[] handStocks = new int[34];

        // コンストラクタで入力された各牌の数の配列
        private int[] inputtedTiles;
        private bool isKokushimuso = false;

        /**
         * @param otherTiles
         * @param last
         * @param mentsuList
         * @throws MahjongTileOverFlowException
         */
        public Hands(int[] otherTiles, Tile last, List<Mentsu> mentsuList)
        {
            inputtedTiles = otherTiles;
            this.last = last;
            inputtedMentsuList = mentsuList;
            setHandsComp(otherTiles, mentsuList);
            findMentsu();
        }
        /**
     * @param allTiles lastの牌も含めて下さい合計14になるはずです
     * @param last     この牌もotherTilesに含めてください
     */
        public Hands(int[] allTiles, Tile last)
        {
            inputtedTiles = allTiles;
            this.last = last;

            //整合性をチェック
            checkTiles(allTiles);

            handsComp = allTiles;

            findMentsu();
        }

        /**
         * コンストラクタで面子を入力した場合に
         * 面子を各牌の数に変換します
         *
         * @param otherTiles 各牌の数
         * @param mentsuList 面子のリスト
         */
        private void setHandsComp(int[] otherTiles, List<Mentsu> mentsuList)
        {
            Array.Copy(otherTiles, 0, handsComp, 0, otherTiles.Length);
            foreach (Mentsu mentsu in mentsuList)
            {
                int code = mentsu.getTile().getCode();

                if (mentsu.isOpen())
                {
                    isOpen_b = true;
                }

                if (mentsu is Shuntsu)
                {
                    handsComp[code - 1] += 1;
                    handsComp[code] += 1;
                    handsComp[code + 1] += 1;
                }
                else if (mentsu is Kotsu)
                {
                    handsComp[code] += 3;
                }
                else if (mentsu is Kantsu)
                {
                    handsComp[code] += 4;
                }
                else if (mentsu is Toitsu)
                {
                    handsComp[code] += 2;
                }
            }
        }
        public HashSet<MentsuComp> getMentsuCompSet()
        {
            return mentsuCompSet;
        }

        public bool getCanWin()
        {
            return canWin;
        }

        public Tile getLast()
        {
            return last;
        }

        public int[] getHandsComp()
        {
            return handsComp;
        }

        public bool getIsKokushimuso()
        {
            return isKokushimuso;
        }

        public bool isOpen()
        {
            return isOpen_b;
        }

        private void checkTiles(int[] allTiles)
        {
            int num = 0;
            foreach (int tileNum in allTiles)
            {
                num += tileNum;
                if (num > 14)
                {
                    throw new HandsOverFlowException();
                }
            }
        }

        public void initStock()
        {
            Array.Copy(inputtedTiles, 0, handStocks, 0, inputtedTiles.Length);
        }

        /**
         * 槓子は見つけません
         */
        public void findMentsu()
        {
            checkTileOverFlow();

            // 国士無双型の判定
            initStock();
            KokushimusoResolver kokushimuso = new KokushimusoResolver(handStocks);
            if (kokushimuso.isMatch())
            {
                isKokushimuso = true;
                canWin = true;
                return;
            }

            // 雀頭の候補を探してストックしておく
            initStock();
            List<Toitsu> toitsuList = Toitsu.findJantoCandidate(handStocks);

            // 雀頭が一つも見つからなければfalse
            if (toitsuList.Count() == 0)
            {
                canWin = false;
                return;
            }

            //七対子なら保存しておく
            if (toitsuList.Count() == 7)
            {
                canWin = true;
                List<Mentsu> mentsuList = new List<Mentsu>(7);
                mentsuList.AddRange(toitsuList);
                MentsuComp comp = new MentsuComp(mentsuList, last);
                mentsuCompSet.Add(comp);
            }

            // その他の判定
            //雀頭候補から探す
            List<Mentsu> winCandidate = new List<Mentsu>(4);
            foreach (Toitsu toitsu in toitsuList)
            {
                // 操作変数を初期化
                init(winCandidate, toitsu);

                //刻子優先検索
                //検索
                winCandidate.AddRange(findKotsuCandidate());
                winCandidate.AddRange(findShuntsuCandidate());
                //全て0かチェック
                convertToMentsuComp(winCandidate);

                init(winCandidate, toitsu);
                //順子優先検索
                winCandidate.AddRange(findShuntsuCandidate());
                winCandidate.AddRange(findKotsuCandidate());
                convertToMentsuComp(winCandidate);
            }

        }

        /**
         * 同じ牌が5個以上はありえないので、Exception をthrow
         *
         * @throws MahjongTileOverFlowException
         */
        private void checkTileOverFlow()
        {
            //
            for (int i = 0; i < handsComp.Length; i++)
            {
                int hand = handsComp[i];
                if (hand > 4)
                {
                    canWin = false;
                    throw new MahjongTileOverFlowException(i, hand);
                }
            }
        }

        /**
         * 操作変数・面子の候補を初期化し
         * 雀頭の分をストックから減らします
         *
         * @param winCandidate 面子の候補
         * @param toitsu       この検索サイクルの雀頭候補
         */
        private void init(List<Mentsu> winCandidate, Toitsu toitsu)
        {
            // 操作変数を初期化
            initStock();
            winCandidate.Clear();
            //ストックから雀頭を減らす
            handStocks[toitsu.getTile().getCode()] -= 2;
            winCandidate.Add(toitsu);
        }

        /**
         * handsStockが全て0の場合
         * winCandidateは完成しているので
         * mentsuCompに代入します
         *
         * @param winCandidate mentsuCompに代入するかもしれない
         */
        private void convertToMentsuComp(List<Mentsu> winCandidate)
        {
            //全て0かチェック
            if (isAllZero(handStocks))
            {
                canWin = true;
                winCandidate.AddRange(inputtedMentsuList);
                MentsuComp mentsuComp = new MentsuComp(winCandidate, last);
                if (!mentsuCompSet.Contains(mentsuComp))
                {
                    mentsuCompSet.Add(mentsuComp);
                }
            }
        }

        /**
         * 入力の配列が全て0かを調べます
         *
         * @param stocks 調べたい配列
         * @return すべて0ならtrue ひとつでも0でなければfalse
         */
        private bool isAllZero(int[] stocks)
        {
            foreach (int i in stocks)
            {
                if (i != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private List<Mentsu> findShuntsuCandidate()
        {
            List<Mentsu> resultList = new List<Mentsu>(4);
            //字牌などはチェックしないので26まで
            for (int j = 1; j < 26; j++)
            {
                // whileにしたのは一盃口などがあるから
                while (handStocks[j - 1] > 0 && handStocks[j] > 0 && handStocks[j + 1] > 0)
                {
                    Shuntsu shuntsu = new Shuntsu(
                        false,
                        Tile.valueOf(j - 1),
                        Tile.valueOf(j),
                        Tile.valueOf(j + 1)
                    );

                    //3つ並んでいても順子であるとは限らないので調べる
                    if (shuntsu.isMentsu())
                    {
                        resultList.Add(shuntsu);
                        handStocks[j - 1]--;
                        handStocks[j]--;
                        handStocks[j + 1]--;
                    }
                }
            }
            return resultList;
        }

        private List<Mentsu> findKotsuCandidate()
        {
            List<Mentsu> resultList = new List<Mentsu>(4);
            for (int i = 0; i < handStocks.Length; i++)
            {
                if (handStocks[i] >= 3)
                {
                    resultList.Add(new Kotsu(false, Tile.valueOf(i)));
                    handStocks[i] -= 3;
                }
            }
            return resultList;
        }
    }


}

