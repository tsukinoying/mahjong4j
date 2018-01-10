using mahjong4j.hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahjong4j
{
    class IllegalMentsuSizeException:Mahjong4jException
    {
        private List<Mentsu> mentsuList;

        public IllegalMentsuSizeException(List<Mentsu> mentsuList):base("面子の組が和了の形になっていません")
        {
            
            this.mentsuList = mentsuList;
        }

        public String getAdvice()
        {
            return "面子の数は合計で5個もしくは七対子の場合のみ7個でなければなりませんが" + mentsuList.Count() + "個の面子が見つかりました";
        }

        /**
         * @return 誤っていると判定されている面子の組を返します
         */
        public List<Mentsu> getMentsuList()
        {
            return mentsuList;
        }
    }
}
