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
            /*
            float H = beaker.getComponentVolume(ChemNotation.ion_H);
            float OH = beaker.getComponentVolume(ChemNotation.ion_OH);

            if(H > 0 && OH > 0)
            {
                float Min = Math.Min(H, OH);

                // 1 : 1 Concentration (H+ : OH-)
                beaker.removeBeakerComponent(ChemNotation.ion_H, Min);
                beaker.removeBeakerComponent(ChemNotation.ion_OH, Min);
                beaker.addBeakerComponent(ChemNotation.H2O, Min);
            }
            */
        }

		public void setConcentrationRatio(int[] ratio) {

			for (int i = 0; i < concentrationRatio.Length; i++) {
				if (ratio[i] == 0)
					ratio[i] = 1;
				concentrationRatio[i] = ratio[i];
			}
		}

		public int[] getConcentrationRatio()
		{
			return concentrationRatio;
		}
    }
}
