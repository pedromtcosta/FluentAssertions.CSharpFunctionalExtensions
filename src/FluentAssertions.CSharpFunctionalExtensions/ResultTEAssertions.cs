using CSharpFunctionalExtensions;
using FluentAssertions.Execution;
using System;

namespace FluentAssertions.CSharpFunctionalExtensions
{
    public class ResultTEAssertions<T, E> : BaseResultAssertions<Result<T, E>>
    {
        public ResultTEAssertions(Result<T, E> subject) : base(subject)
        {
        }

        protected override Func<FailReason> GetErrorMessageFromSubject()
        {
            return () => new FailReason($"Expected {{context:result}} to be Success{{reason}}, but it is failure with error {{0}}", Subject.Error);
        }
    }
}
