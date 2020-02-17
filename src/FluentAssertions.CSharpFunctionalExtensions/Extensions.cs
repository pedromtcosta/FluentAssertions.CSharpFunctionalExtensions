using CSharpFunctionalExtensions;

namespace FluentAssertions.CSharpFunctionalExtensions
{
    public static class Extensions
    {
        public static ResultAssertions Should(this Result subject)
        {
            return new ResultAssertions(subject);
        }

        public static ResultTAssertions<T> Should<T>(this Result<T> subject)
        {
            return new ResultTAssertions<T>(subject);
        }

        public static ResultTEAssertions<T, E> Should<T, E>(this Result<T, E> subject)
        {
            return new ResultTEAssertions<T, E>(subject);
        }
    }
}
