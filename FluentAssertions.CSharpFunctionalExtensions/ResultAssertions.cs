using CSharpFunctionalExtensions;
using FluentAssertions.Execution;

namespace FluentAssertions.CSharpFunctionalExtensions
{
    public class ResultAssertions
    {
        public Result Subject { get; set; }

        public ResultAssertions(Result subject)
        {
            Subject = subject;
        }

        public AndConstraint<ResultAssertions> BeSuccess(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.IsSuccess)
                .FailWith("Expected {context:result} to be success, but it is failure. {0}", Subject);

            return new AndConstraint<ResultAssertions>(this);
        }
    }
}
