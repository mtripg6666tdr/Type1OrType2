# Type1OrType2
Provides you with the class which can be substituded two optional types.
This class is usable on .NET environment.
This class may work on not-.NET environment.

# Install
You can install this repo as Nuget package via Nuget package manager in Visual Studio, or command:
```bash
nuget install Type1OrType2 -OutputDirectory packages
```
# How to use
## Declare namespace
```csharp
using mtripg6666tdr.Type1OrType2;
```
## Quick examples
```csharp
NumType1OrNumType2<bool, Point> hoge = false;
Console.WriteLine(hoge.Data.GetType().toString()); // Will print "System.Object"
Console.WriteLine((bool)hoge); // Will print "false"
Console.WriteLine((Point)hoge); // Will throw InvalidCastException
Console.WriteLine(hoge.Type.toString()); // Will print "Type1"
                                         // If inner object of hoge is `Point` (specified in seconde generic declare), this line will print "Type2"
bool InnerVal = (bool)hoge;
Console.WriteLine(InnerVal); // Will print "false"
```

# Reference
One type that is appropriate to your context is depend on each two types you want to bundle.
- Struct and struct
If you want to bundle two different structs, you can use `NumType1OrNumType2<T1, T2>`.
- Struct and class
If you want to bundle a struct and a class, you can use `NumType1OrRefType2<T1,T2>`.
- Class and Class
If you want to bundle two different classes, you can use `RefType1OrRefType2<T1,T2>`.

**If you have more question, please feel free to contact with me.** or you can refer to Visual Studio Intellisense or [Source code](Type1OrType2/Type1OrType2.cs)

# License
MIT License

# Dependencies
.NET Standard 2.0

# Author
mtripg6666tdr

# Copyright
Copyright (c) 2016-2020 mtripg6666tdr All Rights Reserved.
