using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySimulator
{
    public class Reaction
    {
        // TODO: Hadn't considered concentration - rewrite it
        // Each value for HCl, KOH, NaOH, respectively.
        // Notice that every ratio eventually represented in simplest interger form.
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
    }
}
