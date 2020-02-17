using CSharpFunctionalExtensions;
using FluentAssertions.Execution;
using System;

namespace FluentAssertions.CSharpFunctionalExtensions
{
    public class ResultTAssertions<T> : BaseResultAssertions<Result<T>>
    {
        public ResultTAssertions(Result<T> subject) : base(subject)
        {
        }

        protected override Func<FailReason> GetErrorMessageFromSubject()
        {
            return () => new FailReason($"Expected {{context:result}} to be Success{{reason}}, but it is failure with error '{Subject.Error}'");
        }
    }
}
