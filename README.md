[![Build Status](https://dev.azure.com/pedrotimoteocosta/FluentAssertions.CSharpFunctionalExtensions/_apis/build/status/pedromtcosta.FluentAssertions.CSharpFunctionalExtensions?branchName=master)](https://dev.azure.com/pedrotimoteocosta/FluentAssertions.CSharpFunctionalExtensions/_build/latest?definitionId=1&branchName=master)
[![NuGet](https://buildstats.info/nuget/FluentAssertions.CSharpFunctionalExtensions)](http://www.nuget.org/packages/FluentAssertions.CSharpFunctionalExtensions)

# FluentAssertions.CSharpFunctionalExtensions

This is a small library for using [FluentAssertions](https://github.com/fluentassertions/fluentassertions) on the types provided on the [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions) library.

In other words, you will only need this library if you already use and like the two libraries above - which I imagine you do since you're here, or would if you try them out :D

### What is actually included in this library?

Simply the appropriate methods and classes for asserting the types that come from the [CSharpFunctionalExtensions](https://github.com/vkhorikov/CSharpFunctionalExtensions) library:

```csharp
// Arrange
var myClass = new MyClass();

// Act
Result result = myClass.TheMethod();

// Assert
result.Should().BeSuccess();
```

