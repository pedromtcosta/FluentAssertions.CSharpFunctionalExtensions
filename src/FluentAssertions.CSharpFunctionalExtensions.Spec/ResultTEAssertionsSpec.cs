using CSharpFunctionalExtensions;
using System;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.CSharpFunctionalExtensions.Spec
{
    public class ResultTEAssertionsSpec
    {
        private readonly DummyError _dummyError = new DummyError
        {
            TheError = "This is the error"
        };

        [Fact]
        public void When_result_is_expected_to_be_success_and_it_is_should_not_throw()
        {
            // Arrange
            var subject = Result.Success<int, DummyError>(1);

            // Act / Assert
            subject.Should().BeSuccess();
        }

        [Fact]
        public void When_result_is_expected_to_be_success_and_it_is_not_should_throw()
        {
            // Arrange
            var subject = Result.Failure<int, DummyError>(_dummyError);

            // Act
            Action act = () => subject.Should().BeSuccess("Success means {0}", "it works");

            // Assert
            var expectedErrorMessageBuilder = new StringBuilder();
            expectedErrorMessageBuilder.AppendLine(
                "Expected subject to be Success because Success means it works, but it is failure with error ");
            expectedErrorMessageBuilder.AppendLine();
            expectedErrorMessageBuilder.AppendLine(typeof(DummyError).FullName);
            expectedErrorMessageBuilder.AppendLine("{");
            expectedErrorMessageBuilder.AppendLine("   TheError = \"This is the error\"");
            expectedErrorMessageBuilder.Append("}");

            var expectedErrorMessage = expectedErrorMessageBuilder.ToString();
            act.Should().Throw<XunitException>().WithMessage(expectedErrorMessage);
        }

        [Fact]
        public void When_result_is_expected_to_be_failure_and_it_is_should_not_throw()
        {
            // Arrange
            var subject = Result.Failure<int, DummyError>(_dummyError);

            // Act / Assert
            subject.Should().BeFailure();
        }

        [Fact]
        public void When_result_is_expected_to_be_failure_and_it_is_not_should_throw()
        {
            // Arrange
            var subject = Result.Success<int, DummyError>(1);

            // Act
            Action act = () => subject.Should().BeFailure("this operation {0}", "should not work");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                $"Expected subject to be Failure because this operation should not work, but it is Success");
        }
    }
}
