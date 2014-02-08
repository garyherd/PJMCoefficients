using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormualSpecs
{
    public class RequestedCoefficient
    {
        private decimal _temp;
        private IntervalModel _model;

        public decimal ProfileValue { get; private set; }

        public RequestedCoefficient(IntervalModel model, decimal temp)
        {
            _temp = temp;
            _model = model;
            CalculateProfileValue();
        }

        private void CalculateProfileValue()
        {
            decimal coefficientSum;

            if (_temp < _model.UpperLimits[1])
            {
                ProfileValue = _model.Coefficients[1] * _temp + _model.RegressionConstant;
            }
            else
            {
                coefficientSum = 0;
                int maxTempRangeInterval = GetMaxTempRangeInterval();
                for (int i = 2; i <= maxTempRangeInterval; i++)
                {
                    coefficientSum = coefficientSum + _model.Coefficients[i - 1] * (_model.UpperLimits[i - 1] - _model.UpperLimits[i - 2]);
                }
                ProfileValue = coefficientSum + _model.Coefficients[maxTempRangeInterval] * (_temp - _model.UpperLimits[maxTempRangeInterval - 1]) + _model.RegressionConstant;
            }
        }

        private int GetMaxTempRangeInterval()
        {
            int maxRangeInterval = _model.UpperLimits.Count();
            for (int i = 1; i < _model.UpperLimits.Count(); i++)
            {
                if (_temp < _model.UpperLimits[i])
                {
                    maxRangeInterval = i;
                    break;
                }  
            }
            return maxRangeInterval;
        }       
    }
}
