using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoqCore;
using Moq;
using NUnit.Framework;

namespace EL.Testing
{
    public class With_an_automocked<T>
    {
        private AutoMoqer mocker;

        [SetUp]
        public void WithAnAutoMockedSetup()
        {
            mocker = new AutoMoqer();
            ClassUnderTest = mocker.Create<T>();
        }

        protected T ClassUnderTest { get; private set; }

        protected Mock<TMock> GetMock<TMock>() where TMock : class
        {
            return mocker.GetMock<TMock>();
        }

        protected TAny IsAny<TAny>()
        {
            return It.IsAny<TAny>();
        }

        protected List<TAny> IsSequenceEqual<TAny>(IEnumerable<TAny> collection)
        {
            return It.Is<List<TAny>>(x => x.SequenceEqual(collection));
        }

        protected Guid NewGuid => Guid.NewGuid();

        protected string RandomString => Guid.NewGuid().ToString();
    }
}
