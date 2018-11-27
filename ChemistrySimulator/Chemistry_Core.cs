using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySimulator
{
    public class Chemistry_Core
    {

    }

    class ChemNotation
    {
        public const int ion_H = 0;
        public const int ion_Cl = 1;
        public const int ion_K = 2;
        public const int ion_Na = 3;
        public const int ion_OH = 4;
        public const int H2O = 5;
    }

    class Beaker
    {
        // H+, Cl-, K+, Na+, OH-, H2O, respectively.
        // All components will be initialized with default value 0
        private float[] beakerComponents = new float[6] { 0, 0, 0, 0, 0, 0 };

        public float getTotalBeakerVolume()
        {
            return beakerComponents[ChemNotation.ion_Cl]
                + beakerComponents[ChemNotation.ion_Na]
                + beakerComponents[ChemNotation.ion_K];
        } 

        public float getComponentVolume(int component) {
            return beakerComponents[component];
        }

        // You'll know why i did this when you learn about neutralization reaction...
        public void addBeakerComponent(int component, float amount)
        {
            if (amount > 0)
            {
                switch (component)
                {
                    case ChemNotation.ion_Cl:
                        beakerComponents[ChemNotation.ion_H] += amount;
                        beakerComponents[ChemNotation.ion_Cl] += amount;
                        break;

                    case ChemNotation.ion_K:
                        beakerComponents[ChemNotation.ion_K] += amount;
                        beakerComponents[ChemNotation.ion_OH] += amount;
                        break;

                    case ChemNotation.ion_Na:
                        beakerComponents[ChemNotation.ion_Na] += amount;
                        beakerComponents[ChemNotation.ion_OH] += amount;
                        break;

                    case ChemNotation.H2O:
                        beakerComponents[ChemNotation.H2O] += amount;
                        break;
                }
            }
        }

        public void removeBeakerComponent(int component, float amount)
        {
            if(getComponentVolume(component) >= amount)
            {
                switch (component)
                {
                    case ChemNotation.ion_Cl:
                        beakerComponents[ChemNotation.ion_H] -=
                            Math.Min(beakerComponents[ChemNotation.ion_Cl], beakerComponents[ChemNotation.ion_H]);
                        beakerComponents[ChemNotation.ion_Cl] -=
                            Math.Min(beakerComponents[ChemNotation.ion_Cl], beakerComponents[ChemNotation.ion_H]);
                        break;

                    case ChemNotation.ion_K:
                        beakerComponents[ChemNotation.ion_K] -=
                            Math.Min(beakerComponents[ChemNotation.ion_K], beakerComponents[ChemNotation.ion_OH]);
                        beakerComponents[ChemNotation.ion_OH] -=
                            Math.Min(beakerComponents[ChemNotation.ion_K], beakerComponents[ChemNotation.ion_OH]);
                        break;

                    case ChemNotation.ion_Na:
                        beakerComponents[ChemNotation.ion_Na] -=
                            Math.Min(beakerComponents[ChemNotation.ion_Na], beakerComponents[ChemNotation.ion_OH]);
                        beakerComponents[ChemNotation.ion_OH] -=
                            Math.Min(beakerComponents[ChemNotation.ion_Na], beakerComponents[ChemNotation.ion_OH]);
                        break;
                }
            }
        }
    }

    class Reaction
    {
        public void neutralize(Beaker beaker)
        {
            float H = beaker.getComponentVolume(ChemNotation.ion_H);
            float OH = beaker.getComponentVolume(ChemNotation.ion_OH);

            if(H > 0 && OH > 0)
            {
                float Min = Math.Min(H, OH);
                beaker.removeBeakerComponent(ChemNotation.ion_H, Min);
                beaker.removeBeakerComponent(ChemNotation.ion_OH, Min);
                beaker.addBeakerComponent(ChemNotation.H2O, Min);
            }
        }
    }

}
