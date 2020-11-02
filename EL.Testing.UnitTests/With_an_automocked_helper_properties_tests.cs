using NUnit.Framework;

namespace EL.Testing.UnitTests
{
    public class With_an_automocked_helper_properties_tests : With_an_automocked<With_an_automocked_helper_properties_tests>
    {
        [Test]
        public void When_generating_multiple_random_strings()
        {
            var firstRandomString = RandomString;
            var secondRandomString = RandomString;

            Assert.That(firstRandomString, Is.Not.EqualTo(secondRandomString));
        }

        [Test]
        public void When_generating_multiple_guids()
        {
            var firstGuid = NewGuid;
            var secondGuid = NewGuid;

            Assert.That(firstGuid, Is.Not.EqualTo(secondGuid));
        }
    }
}