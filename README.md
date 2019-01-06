# Fractional.NET

[![Build Status](https://dev.azure.com/saifeddinemahjoub/saifeddinemahjoub/_apis/build/status/smahjoub.Fractional.NET)](https://dev.azure.com/saifeddinemahjoub/saifeddinemahjoub/_build/latest?definitionId=1) [![](https://img.shields.io/nuget/vpre/Fractional.NET.svg)](https://www.nuget.org/packages/Fractional.NET/1.0.0-alpha) [![](https://img.shields.io/github/license/smahjoub/Fractional.NET.svg)](https://github.com/smahjoub/Fractional.NET)

This is simple .NET Core library for parsing and working with fractinal expressions.

## Build

Run `dotnet build` to build the project. 

## Running unit tests

From *Fractional.Tests* directory, run `dotnet  test` to execute the unit tests.

# Usage guide

This is a basic guide to show you the main features of the library.

##  Conversion

Basic conversion operations

### Conversion to human readable fraction

Conversion of decimals with approximate guessing :

```csharp
var f1 = new Fractional(0.333333d, keepExcat: false);
var f2 = new Fractional(0.75d, keepExcat: false);

Console.WriteLine(f1.HumanRepresentation); // Output: 1/3
Console.WriteLine(f2.HumanRepresentation); // Output: 3/4
```

Conversion of decimals without approximate guessing :

```csharp
var f1 = new Fractional(0.333333d, keepExcat: true);
var f2 = new Fractional(0.75d, keepExcat: true);

Console.WriteLine(f1); // Output: 333333/1000000
Console.WriteLine(f2); // Output: 75/100
```

### Conversion to decimal

Conversion to human fractions to decimals

```csharp

var f1 = new Fractional("7 3/4");
var f2 = new Fractional("3/4");

Console.WriteLine(f1.Value); // Output: 7.75
Console.WriteLine(f2.Value); // Output: 0.75

```

### Arithmetic operations and Comparisons

The fraction instance work very well with math operators even with other numerics and string representations :

```csharp

var f1 = new Fractional("3/4");
var f2 = new Fractional("1/2");

Console.WriteLine(f1 + 0.5d);    // Output: 1 1/4
Console.WriteLine(f1 + f2);      // Output: 1 1/4
Console.WriteLine(f1 - 1.75d);   // Output: -1
Console.WriteLine(f1 - f2);      // Output: 1/4

```

It does the same work with Comparisons operators

```csharp

var f1 = new Fractional("5 3/2");
var f2 = new Fractional("3 3/2");

Console.WriteLine(f1 > f2);        // Output: true
Console.WriteLine(f1 < 7.0d);      // Output: true
Console.WriteLine(f2 > 5.0d);      // Output: false
```
