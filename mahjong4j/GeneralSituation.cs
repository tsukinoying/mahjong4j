using mahjong4j.tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mahjong4j
{
    public class GeneralSituation
    {
        private bool isFirstRound_b;
        private bool isHoutei_b;
        private Tile bakaze;
        private List<Tile> dora;
        private List<Tile> uradora;
        GeneralSituation()
        {
            
        }
        public GeneralSituation(bool isFirstRound, bool isHoutei, Tile bakaze, List<Tile> dora, List<Tile> uradora)
        {
            this.isFirstRound_b = isFirstRound;
            this.isHoutei_b = isHoutei;
            this.bakaze = bakaze;
            this.dora = dora;
            this.uradora = uradora;
        }
        public bool isFirstRound()
        {

            return isFirstRound_b;
        }

        public void setFirstRound(bool firstRound)
        {
            isFirstRound_b = firstRound;
        }

        public bool isHoutei()
        {
            return isHoutei_b;
        }

        public void setHoutei(bool houtei)
        {
            isHoutei_b = houtei;
        }

        public Tile getBakaze()
        {
            return bakaze;
        }

        public void setBakaze(Tile bakaze)
        {
            this.bakaze = bakaze;
        }

        public List<Tile> getDora()
        {
            return dora;
        }

        public void setDora(List<Tile> dora)
        {
            this.dora = dora;
        }

        public List<Tile> getUradora()
        {
            return uradora;
        }

        public void setUradora(List<Tile> uradora)
        {
            this.uradora = uradora;
        }
    }
}
