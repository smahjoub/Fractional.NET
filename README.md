# Fractional.NET

[![Build Status](https://dev.azure.com/saifeddinemahjoub/saifeddinemahjoub/_apis/build/status/smahjoub.Fractional.NET)](https://dev.azure.com/saifeddinemahjoub/saifeddinemahjoub/_build/latest?definitionId=1)

This is simple .NET Core library for parsing and working with fractinal expressions.

## Build

Run `dotnet build` to build the project. 

## Running unit tests

From *Fractional.Tests* directory, run `dotnet  test` to execute the unit tests.

# Usage guide

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

Console.WriteLine(f1.HumanRepresentation); // Output: 333333/1000000
Console.WriteLine(f2.HumanRepresentation); // Output: 75/100
```

### Conversion to decimal

Conversion to human fractions to decimals

```csharp

var f1 = new Fractional("7 3/4");
var f2 = new Fractional("3/4");

Console.WriteLine(f1.Value); // Output: 7.75
Console.WriteLine(f2.Value); // Output: 0.75

```