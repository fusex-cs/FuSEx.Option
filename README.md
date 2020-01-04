# FuSEx.Option

[![NuGet](https://img.shields.io/nuget/v/FuSEx.Option.svg?style=flat)](https://www.nuget.org/packages/FuSEx.Option)
[![license](https://img.shields.io/github/license/fusex-cs/Option.svg)](https://github.com/fusex-cs/Option/blob/master/LICENSE)

## A simple generic type to wrap and encapsulate a function that may or may not return a value

Option is a functional programming structure that's purpose is to safely wrap the return value of a function in the case where returning nothing or something are both valid outputs of the function.

## Basic Usage

### Defining a Function

```csharp
public Option<string> GetSessionToken(User user)
{
    return user.IsLoggedIn ? user.SessionToken.ToOption() : None.Value;
}
```

### Handling an Option

```csharp
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

## Credits
This repository is a barely tweaked fork off of Zoran Horvats([Github](https://github.com/zoran-horvat), [Blog](http://www.codinghelmet.com)) Option type which he wrote a fantastic article on here: [Custom Implementation of the Option Maybe Type in C#](http://www.codinghelmet.com/articles/custom-implementation-of-the-option-maybe-type-in-cs). All Credits to him.
