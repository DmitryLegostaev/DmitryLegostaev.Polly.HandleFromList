[![Nuget](https://img.shields.io/nuget/v/DmitryLegostaev.Polly.HandleFromList.svg)](https://www.nuget.org/packages/DmitryLegostaev.Polly.HandleFromList)
[![Build](https://github.com/DmitryLegostaev/DmitryLegostaev.Polly.HandleFromList/actions/workflows/build.yml/badge.svg?branch=main)](https://github.com/DmitryLegostaev/DmitryLegostaev.Polly.HandleFromList/actions/workflows/build.yml)
![GitHub repo size](https://img.shields.io/github/repo-size/DmitryLegostaev/DmitryLegostaev.Polly.HandleFromList)

## DmitryLegostaev.Polly.HandleFromList

A small class library to expand Polly PolicyBuilder with handling exceptions list functionality.

### Usage

#### Create list of types with exceptions to handle
```csharp
var exceptionsToHandle = new List<Type>()
{
    typeof(InvalidOperationException),
    typeof(InvalidCastException)
};
```

#### Use static method directly to get a new PolicyBuilder object:
```csharp
var policyBuilder = PolicyBuilderUtilities
    .HandleFromList<T>(exceptionsToHandle);
```

#### Use extension method over existing PolicyBuilder:
```csharp
var policyBuilder = Policy<T>
    .Handle<InvalidOperationException>()
    .OrFromList(exceptionsToHandle);
```
