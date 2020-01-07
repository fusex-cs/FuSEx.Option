# FuSEx.Option

[![NuGet](https://img.shields.io/nuget/v/FuSEx.Option.svg?style=flat)](https://www.nuget.org/packages/FuSEx.Option)
[![license](https://img.shields.io/github/license/fusex-cs/Option.svg?style=flat)](https://github.com/fusex-cs/Option/blob/master/LICENSE.txt)

## A simple generic type to wrap and encapsulate a function that may or may not return a value

Option is a functional programming structure that's purpose is to safely wrap the return value of a function in the case where returning nothing or something are both valid outputs of the function.

## Purpose

Option provides a way to codeify the intent of whether function will return a value or not. In C# without an Option type we do one of two things:
1. Implement the method with an out param and return bool to indicate success or failure.
2. Return `null` when we have no value.

The problem with bool and out parameters is firstly that the return type of the function hasn't been truly encapsulated but, from a debugging point of view, more importantly, there are no checks to ensure that the bool is handled correctly before accessing the out variable.

There are many problems caused by returning null from a function but the heart of the issue is that at compile time, an instance of `T` is equatable to a null reference of `T`. Put simply, the compiler (and programmer, without backtracing the program) can't know AT ANY POINT if that instance of `T` is valid or not.

Option helps you deal with these issues by forcing you to unwrap the value before you can use it, and once you've unwrapped it, you can safely assume that you have a valid value.

## Option, Some and None

There are four main types exposed by this library,  
### `Option<T>`

The abstract base class that the other types inherit from. This will always be the return type in the function in questions signature.

### `Some<T>`

The type that represents a result containing a value.

### `None<T>`

The type that represents no value.
Note that there's also a `None` type to provide the instance that all `None<T>` instances use.

## Installation

Add the package [FuSEx.Option](https://www.nuget.org/packages/FuSEx.Option) using nuget package manager or via dotnet cli i.e: `dotnet add package FuSEx.Option`.

## Usage

The library is split into two namespaces both supplied in the one nuget package. `FuSEx.Option` which provides the core three types, allowing basic usage of creating and returning Option, Some and None. And `FuSEx.Option.Extensions` which provides a set of extension methods for common tasks such as parsing objects and transforming lists.


### Basic Usage

```csharp
public Option<string> GetSessionToken(User user)
{
    return user.IsLoggedIn ? user.SessionToken.ToOption() : None.Value;
}

public void DoSessionAction(User user)
{
    var tokenOption = GetSessionToken(user);

    // With C# 8 pattern matching
    tokenOption switch
    {
        Some<string> { Content: string token } => DoSessionActionWithToken(token),
        None<string> _ => RedirectToLogin()
    };

    // With C# 7
    switch (tokenOption)
    {
        case Some<string> tokenSome:
            DoSessionActionWithToken(tokenSome.Content);
        case None<string> _:
            RedirectToLogin()
    };
}
```

### Implicit Casting
Option defines some implicit converters to make using Option a breeze. The cast operators defined in [Option.cs](https://github.com/fusex-cs/Option/blob/master/FuSEx.Option/Option.cs) to convert `None` to `None<T>` and `T` to `Some<T>`. This makes the following two code blocks functionally equivalent.

Without implicit casting:
```csharp
public Option<string> GetSessionToken(User user)
{
    if (user.IsLoggedIn)
        return new Some<string>(user.SessionToken); //  A bit too verbose
                                                    //  |
    return new None<string>();                      //  |
}
```
With implicit casting:
```csharp
public Option<string> GetSessionToken(User user)
{
    if (user.IsLoggedIn)
        return user.SessionToken; // Implicitly converted due to the return requirement of Option<string>
                                  // |
    return None.Value;            // |
}
```

Unfortunately the ternary operator isn't quite smart enough to work out the it needs to derive an `Option<T>` from `condition ? T : None.Value`. Luckily we've got a simple extension method: `object.ToOption()` that will create a `Some<T>` if the item is not `null` or a `None<T>` if the item is `null`.

### Transforming Options

There are a few methods provided by Option to help unwrap and utilise the results fast and effectively.

#### Reduce
Provides a way to supply a default value to return. Reduce will always return an instance of `T`, if the Option is a `Some<T>`, `o.Reduce(x)` will return `o.Content`, if the Option is a `None<T>`, `o.Reduce(x)` will return `x`. A function that returns a `T` can also be supplied which will only evaluate if the Option is a `None<T>`.

#### Map
Transforms an Option from `Option<T>` to `Option<U>` using the supplied map function parameter `Func<T, U>`. The supplied function will only be evaluated if the Option is `Some<T>`. A `None<T>` will simply be transformed into a `None<U>`.

#### MapOptional
Sometimes the function you want to pass into Map may return an `Option<T>` instead of a `T`, in this case, you'll end up with an `Option<Option<T>>` which is probably not what you want. This is what MapOptional is for, it'll stop the extra wrapping of the `Option<T>`. 

### Extension Methods

#### IEnumerable Extensions

##### FirstOrNone
An effective replacement of FirstOrDefault that returns an `Option<T>` instead of a nullable `T`. The return value will be `Some<T>` containing the first item matched in the list, or `None<T>` if a value is not found.

##### LastOrNone
A replacement of LastOrDefault that returns an `Option<T>` instead of a nullable `T`. The return value will be `Some<T>` containing the last item matched in the list, or `None<T>` if a value is not found.

#### Object Extensions

##### NoneIfNull
Wraps a value in a `Some<T>` or a `None<T>` if the value is `null`.

##### ToOption
An alias for `NoneIfNull`.

##### When
Returns `Some<T>` when the predicate/condition is true, otherwise `None<T>`.

#### Dictionary Extensions

##### TryGetValue
Gets the value out of a dictionaty with the supplied key. Returns `Some<T>` containing the value if it exists or `None<T>` if it does not.

#### String Parse Extensions
A set of parse methods on string to safely parse commonly parsed types from a string, returning `Some<T>` when a successful parse has occurred and `None<T>` when a parse has failed.


## Credits
This repository is a barely tweaked fork off of Zoran Horvats([Github](https://github.com/zoran-horvat), [Blog](http://www.codinghelmet.com)) Option type which he wrote a fantastic article on here: [Custom Implementation of the Option Maybe Type in C#](http://www.codinghelmet.com/articles/custom-implementation-of-the-option-maybe-type-in-cs). All Credits to him.
