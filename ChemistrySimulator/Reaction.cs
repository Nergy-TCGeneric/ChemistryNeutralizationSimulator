using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySimulator
{
    public class Reaction
    {
        // Each value for HCl, KOH, NaOH, respectively.
        private int[] concentrationRatio = new int[3] { 1, 1, 1 };

        public void neutralize(Beaker beaker)
        {
            float H = beaker.getComponentVolume(ChemNotation.ion_H);
            float OH = beaker.getComponentVolume(ChemNotation.ion_OH);

            if(H > 0 && OH > 0)
            {
				int[] reactionRatio = densityToReactionRatio();

				// Because without reaction, amount of positive ion : negative ion = 1 : 1
				float OH_by_K = beaker.getComponentVolume(ChemNotation.ion_K);
				float OH_by_Na = OH - OH_by_K;
				
				// Need to optimize those algorithms..
                if(H/reactionRatio[0] > OH_by_K/reactionRatio[1] + OH_by_K/reactionRatio[2])
                {
                    beaker.removeBeakerComponent(ChemNotation.ion_H, H - H / reactionRatio[0]);
                    beaker.removeBeakerComponent(ChemNotation.ion_OH, OH);
                    beaker.addBeakerComponent(ChemNotation.H2O, OH);
                }
                else
                {
                    beaker.removeBeakerComponent(ChemNotation.ion_H, H);
                    beaker.removeBeakerComponent(ChemNotation.ion_OH, OH - (OH_by_K / reactionRatio[1] + OH_by_Na / reactionRatio[2]));
                    beaker.addBeakerComponent(ChemNotation.H2O, H);
                }
            }
        }

		public void setConcentrationRatio(int[] ratio) {

			for (int i = 0; i < concentrationRatio.Length; i++) {
				if (ratio[i] == 0)
					ratio[i] = 1;
				concentrationRatio[i] = ratio[i];
			}
		}

		public int[] getConcentrationRatio() {
			return concentrationRatio;
		}

		private int[] densityToReactionRatio() {
			return new int[3] { concentrationRatio[1] * concentrationRatio[2],
								concentrationRatio[0] * concentrationRatio[2],
								concentrationRatio[0] * concentrationRatio[1] };
		}
    }
}
