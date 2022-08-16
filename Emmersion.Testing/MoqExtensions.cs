using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;

namespace Emmersion.Testing
{
    public static class MoqExtensions
    {
        public static void VerifyNever<T, TResult>(this Mock<T> mock, Expression<Func<T, TResult>> expression)
            where T : class
        {
            mock.Verify(expression, Times.Never);
        }

        public static void VerifyNever<T>(this Mock<T> mock, Expression<Action<T>> expression)
            where T : class
        {
            mock.Verify(expression, Times.Never);
        }
        
        public static IReturnsResult<TMock> ReturnsNull<TMock, TResult>(this ISetup<TMock, TResult> mock)
            where TMock : class
        {
            return mock.Returns<TResult>(null);   
        }

        public static IReturnsResult<TMock> ReturnsNullAsync<TMock, TResult>(this ISetup<TMock, Task<TResult>> mock)
            where TMock : class 
            where TResult: class
        {
            return mock.ReturnsAsync((TResult)null);
        }
    }
}
