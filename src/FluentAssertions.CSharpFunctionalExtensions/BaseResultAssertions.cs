using CSharpFunctionalExtensions;
using FluentAssertions.Execution;
using System;

namespace FluentAssertions.CSharpFunctionalExtensions
{
    public abstract class BaseResultAssertions<T> where T : IResult
    {
        public T Subject { get; set; }

        protected BaseResultAssertions(T subject)
        {
            Subject = subject;
        }

        /// <summary>
        /// Asserts that the <c>IsSuccess</c> property from the given <see cref="Result"/> is <c>true</c>.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        [CustomAssertion]
        public AndConstraint<BaseResultAssertions<T>> BeSuccess(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.IsSuccess)
                .FailWith(GetErrorMessageFromSubject());

            return new AndConstraint<BaseResultAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that the <c>IsFailure</c> property from the given <see cref="Result"/> is <c>true</c>.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        [CustomAssertion]
        public AndConstraint<BaseResultAssertions<T>> BeFailure(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.IsFailure)
                .FailWith("Expected {context:result} to be Failure{reason}, but it is Success");

            return new AndConstraint<BaseResultAssertions<T>>(this);
        }

        protected abstract Func<FailReason> GetErrorMessageFromSubject();
    }
}
