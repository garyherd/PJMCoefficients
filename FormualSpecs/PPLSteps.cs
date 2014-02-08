using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace FormualSpecs
{
    [Binding]
    public class PPLSteps
    {
        [Given]
        public void Given_the_following_coefficients_and_constants(Table table)
        {
            IntervalModelDTO modelDto = table.CreateInstance<IntervalModelDTO>();
            ScenarioContext.Current.Set<IntervalModelDTO>(modelDto, "modelDto");
        }

        [Given]
        public void Given_the_temperature_is_TEMP_degF(decimal temp)
        {
            ScenarioContext.Current["temp"] = temp;  
        }

        [When]
        public void When_the_coefficient_request_is_made()
        {
            var modelDto = ScenarioContext.Current.Get<IntervalModelDTO>("modelDto");
            var temp = (decimal)ScenarioContext.Current["temp"];

            IntervalModel model = new IntervalModel(modelDto);
            RequestedCoefficient coefficient = new RequestedCoefficient(model, temp);
            ScenarioContext.Current["coefficient"] = coefficient;
        }

        [Then]
        public void Then_the_result_should_be_P0(Decimal p0)
        {
            var coefficient = ScenarioContext.Current.Get<RequestedCoefficient>("coefficient");
            Assert.Equal(p0, coefficient.ProfileValue,4);
        }
    }
}
