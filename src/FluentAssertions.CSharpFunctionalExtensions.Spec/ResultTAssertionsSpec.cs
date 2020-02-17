using CSharpFunctionalExtensions;
using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.CSharpFunctionalExtensions.Spec
{
    public class ResultTAssertionsSpec
    {
        private const string DummyFailureMessage = "Any";

        [Fact]
        public void When_result_is_expected_to_be_success_and_it_is_should_not_throw()
        {
            // Arrange
            var result = Result.Success(1);

            // Act / Assert
            result.Should().BeSuccess();
        }

        [Fact]
        public void When_result_is_expected_to_be_success_and_it_is_not_should_throw()
        {
            // Arrange
            var subject = Result.Failure<int>(DummyFailureMessage);

            // Act
            Action act = () => subject.Should().BeSuccess("Success means {0}", "it works");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                $"Expected subject to be Success because Success means it works, but it is failure with error '{DummyFailureMessage}'");
        }

        [Fact]
        public void When_result_is_expected_to_be_failure_and_it_is_should_not_throw()
        {
            // Arrange
            var result = Result.Failure<int>(DummyFailureMessage);

            // Act / Assert
            result.Should().BeFailure();
        }

        [Fact]
        public void When_result_is_expected_to_be_failure_and_it_is_not_should_throw()
        {
            // Arrange
            var subject = Result.Success(1);

            // Act
            Action act = () => subject.Should().BeFailure("this operation {0}", "should not work");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                $"Expected subject to be Failure because this operation should not work, but it is Success");
        }
    }
}
