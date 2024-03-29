﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoqCore;
using Moq;
using NUnit.Framework;

namespace Emmersion.Testing
{
    public class With_an_automocked<T>
    {
        private AutoMoqer mocker;

        [SetUp]
        public void WithAnAutoMockedSetup()
        {
            mocker = new AutoMoqer();
        }

        [TearDown]
        public void TearDown()
        {
            classUnderTest = default;
        }

        private T classUnderTest;
        protected T ClassUnderTest => classUnderTest ??= mocker.Create<T>();

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

        protected Guid NewGuid() => Guid.NewGuid();

        protected string RandomString() => Guid.NewGuid().ToString();

        protected TimeSpan Seconds(int seconds) => TimeSpan.FromSeconds(seconds);
        
        protected DateTimeOffset PastDate(int daysInPast) => DateTimeOffset.UtcNow.AddDays(-daysInPast);
        
        protected DateTimeOffset FutureDate(int daysInFuture) => DateTimeOffset.UtcNow.AddDays(daysInFuture);
    }
}
