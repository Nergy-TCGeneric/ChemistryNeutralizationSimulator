using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySimulator
{
    public class Beaker : Reaction
    {
        // H+, Cl-, K+, Na+, OH-, H2O, respectively.
        // All components will be initialized with default value 0
        private float[] beakerComponents = new float[6] { 0, 0, 0, 0, 0, 0 };
		private int maxVolume = 100;
		private int standardVolume = 1;

		// TODO: Add arguments into initalizer, make it enable to create instances
        public Beaker()
        {

        }

        public float getTotalBeakerVolume()
        {
            return beakerComponents[ChemNotation.ion_Cl]
                + beakerComponents[ChemNotation.ion_K]
                + beakerComponents[ChemNotation.ion_Na];
        }

        public float getComponentVolume(int component)
        {
            return beakerComponents[component];
        }

        public void addBeakerComponent(int component, float amount)
		{ 
            if (amount > 0 && getTotalBeakerVolume() < maxVolume)
            {
                switch (component)
                {
                    // Assuming that if Cl is added, and H is also added, too.
                    // Same on other chemicals.
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

                    case ChemNotation.ion_H:
                        beakerComponents[ChemNotation.ion_H] += amount;
                        break;

                    case ChemNotation.ion_OH:
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
            if (getComponentVolume(component) >= amount)
            {
                switch (component)
                {
                    case ChemNotation.ion_Cl:
                        beakerComponents[ChemNotation.ion_H] -= amount;
                        beakerComponents[ChemNotation.ion_Cl] -= amount;
                        break;

                    case ChemNotation.ion_K:
                        beakerComponents[ChemNotation.ion_K] -= amount;
                        beakerComponents[ChemNotation.ion_OH] -= amount;
                        break;

                    case ChemNotation.ion_Na:
                        beakerComponents[ChemNotation.ion_Na] -= amount;
                        beakerComponents[ChemNotation.ion_OH] -= amount;
                        break;

                    case ChemNotation.ion_OH:
                        beakerComponents[ChemNotation.ion_OH] -= amount;
                        break;

                    case ChemNotation.ion_H:
                        beakerComponents[ChemNotation.ion_H] -= amount;
                        break;
                }
            }
        }

		public void setMaxVolume(int newVolume)
		{
			if (newVolume > 0)
				maxVolume = newVolume;
		}

		public int getMaxVolume()
		{
			return maxVolume;
		}

		public void setStandardVolume(int newVolume)
		{
			if (newVolume > 0)
				standardVolume = newVolume;
		}

		public int getStandardVolume()
		{
			return standardVolume;
		}
    }
}