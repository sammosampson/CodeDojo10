using System;
using TechTalk.SpecFlow;

namespace Gym.Specifications.Steps
{
    [Binding]
    public class DateSteps
    {
        readonly TestDateTimeProvider context;

        public DateSteps(TestDateTimeProvider context)
        {
            this.context = context;
        }

        [Given(@"the date is '(.*)'")]
        public void GivenTheDateIs(DateTime date)
        {
            context.SetDate(date);
        }
    }
}