using System;
using TechTalk.SpecFlow;
using Xunit;

namespace FormualSpecs
{
    [Binding]
    public class PPLSteps
    {
        private Coefficient _coefficient;

        [Given]
        public void Given_the_following_coefficients_and_constants(Table table)
        {
            string[] header = {"HIGH_1", "HIGH_2",  "HIGH_3", "HIGH_4", "COEFF_1", "COEFF_2", "COEFF_3", "COEFF_4", "CONSTANT"};
            string[] row1 = { "50.4741", "64.5280", "77.3043", "99999", "-0.0204", "-0.0028", "0.0055", "0.0297", "2.5810" };
            var t = new Table(header);
            t.AddRow(row1);
        }

        [Given]
        public void Given_the_temperature_is_TEMP_degF(double temp)
        {
            _coefficient = new Coefficient(temp);
        }

        [When]
        public void When_the_coefficient_request_is_made()
        {
        }

        [Then]
        public void Then_the_result_should_be_FACTOR(double factor)
        {
            Assert.Equal(_coefficient.LoadProfileFactor, factor, 4);
        }
    }
}
