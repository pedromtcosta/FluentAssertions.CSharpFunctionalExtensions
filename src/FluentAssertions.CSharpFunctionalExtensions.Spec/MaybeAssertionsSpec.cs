using System;
using CSharpFunctionalExtensions;
using Xunit;

namespace FluentAssertions.CSharpFunctionalExtensions.Spec
{
    public class MaybeAssertionsSpec
    {
        [Fact]
        public void When_maybe_is_expected_to_have_value_and_it_does_should_not_throw()
        {
            Maybe<string> x = "test";

            x.Should().HaveValue("test");
        }

        [Fact]
        public void When_maybe_is_expected_to_have_value_and_it_has_wrong_value_should_throw()
        {
            Maybe<string> x = "oops";

            Action act = () => x.Should().HaveValue("test", "it is test");

            act.Should().Throw<Exception>().WithMessage($"*value \"test\" because it is test, but with value \"oops\" it*");
        }

        [Fact]
        public void When_maybe_is_expected_to_have_value_and_it_does_not_should_throw()
        {
            Maybe<string> x = null;

            Action act = () => x.Should().HaveValue("test", "it is not None");

            act.Should().Throw<Exception>().WithMessage($"*value \"test\" because it is not None*");
        }

        [Fact]
        public void When_maybe_is_expected_to_have_no_value_and_it_has_none_should_not_throw()
        {
            Maybe<string> x = null;

            x.Should().HaveNoValue();
        }

        [Fact]
        public void When_maybe_is_expected_to_have_no_value_and_it_has_one_should_throw()
        {
            Maybe<string> x = "test";

            Action act = () => x.Should().HaveNoValue("it is None");

            act.Should().Throw<Exception>().WithMessage($"*maybe to have no value because it is None, but with value \"test\" it*");
        }
    }
}