using NUnit.Framework;

namespace EL.Testing.UnitTests
{
    public class With_an_automocked_basic_usage_tests : With_an_automocked<ClassWithDependencies>
    {
        [Test]
        public void When_setting_mock()
        {
            GetMock<ITestInterface>().Setup(x => x.GetIntValue()).Returns(42);

            var result = ClassUnderTest.GetValue();

            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void When_verifying_mock()
        {
            var stringValue = RandomString;

            ClassUnderTest.ReceiveStringValue(stringValue);

            GetMock<ITestInterface>().Verify(x => x.ReceiveStringValue(stringValue));
        }
    }

    public class ClassWithDependencies
    {
        private readonly ITestInterface testInterface;

        public ClassWithDependencies(ITestInterface testInterface)
        {
            this.testInterface = testInterface;
        }

        public int GetValue() => testInterface.GetIntValue();
        public void ReceiveStringValue(string stringValue) => testInterface.ReceiveStringValue(stringValue);
    }

    public interface ITestInterface
    {
        int GetIntValue();
        void ReceiveStringValue(string stringValue);
    }
}