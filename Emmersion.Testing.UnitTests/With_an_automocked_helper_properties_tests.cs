using System;
using NUnit.Framework;

namespace Emmersion.Testing.UnitTests
{
    public class With_an_automocked_helper_properties_tests : With_an_automocked<With_an_automocked_helper_properties_tests>
    {
        [Test]
        public void When_generating_multiple_random_strings()
        {
            var firstRandomString = RandomString();
            var secondRandomString = RandomString();

            Assert.That(firstRandomString, Is.Not.EqualTo(secondRandomString));
        }

        [Test]
        public void When_generating_multiple_guids()
        {
            var firstGuid = NewGuid();
            var secondGuid = NewGuid();

            Assert.That(firstGuid, Is.Not.EqualTo(secondGuid));
        }

        [Test]
        public void When_generating_timespan()
        {
            var timespan = Seconds(5);

            Assert.That(timespan, Is.EqualTo(TimeSpan.FromSeconds(5)));

            var date1 = DateTimeOffset.UtcNow;
            var date2 = DateTimeOffset.UtcNow.AddSeconds(1);
            Assert.That(date1, Is.EqualTo(date2).Within(Seconds(2)));
        }

        [Test]
        public void When_generating_past_date()
        {
            var pastDate = PastDate(1);
            
            Assert.That(pastDate, Is.EqualTo(DateTimeOffset.UtcNow.AddDays(-1)).Within(TimeSpan.FromSeconds(2)));
            
            var currentDate = DateTimeOffset.UtcNow;
            Assert.That(pastDate, Is.LessThan(currentDate));
        }

        [Test]
        public void When_generating_future_date()
        {
            var futureDate = FutureDate(1);
            
            Assert.That(futureDate, Is.EqualTo(DateTimeOffset.UtcNow.AddDays(1)).Within(TimeSpan.FromSeconds(2)));

            var currentDate = DateTimeOffset.UtcNow;
            Assert.That(futureDate, Is.GreaterThan(currentDate));
        }
    }
}
