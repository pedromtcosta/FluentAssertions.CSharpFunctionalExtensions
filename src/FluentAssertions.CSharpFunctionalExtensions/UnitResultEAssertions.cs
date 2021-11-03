using CSharpFunctionalExtensions;
using FluentAssertions.Execution;
using System;

namespace FluentAssertions.CSharpFunctionalExtensions
{
    public class UnitResultEAssertions<E> : BaseResultAssertions<UnitResult<E>>
    {
        public UnitResultEAssertions(UnitResult<E> subject) : base(subject)
        {
        }

        protected override Func<FailReason> GetErrorMessageFromSubject()
        {
            return () => new FailReason($"Expected {{context:result}} to be Success{{reason}}, but it is failure with error {{0}}", Subject.Error);
        }
    }
}
