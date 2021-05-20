using NUnit.Framework;

namespace Emmersion.Testing.UnitTests
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
            var stringValue = RandomString();

            ClassUnderTest.ReceiveStringValue(stringValue);

            GetMock<ITestInterface>().Verify(x => x.ReceiveStringValue(stringValue));
        }
    }

    public class With_an_automocked_class_with_constructor_dependencies : With_an_automocked<ClassWithConstructorDependencies>
    {
        [Test]
        public void Should_be_able_to_mock_things_before_constructing()
        {
            GetMock<ITestInterface>().Setup(x => x.GetIntValue()).Returns(42);
            var result = ClassUnderTest.Value;
            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void Should_get_a_new_mock_every_time()
        {
            var result = ClassUnderTest.Value;
            Assert.That(result, Is.EqualTo(0));
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

    public class ClassWithConstructorDependencies
    {
        public ClassWithConstructorDependencies(ITestInterface testInterface)
        {
            Value = testInterface.GetIntValue();
        }

        public int Value { get; private set; }
    }
}
