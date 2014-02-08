using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormualSpecs
{
    public class Coefficient
    {
        private double temp;

        public Coefficient(double temp)
        {
            CalculateFactor(temp);
        }

        private void CalculateFactor(double temp)
        {
            LoadProfileFactor = 0;
        }
        public double LoadProfileFactor { get; private set; }
    }
}
