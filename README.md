# GildedRose-Refactoring-Kata-csharp

My solution for of [Gilded Rose Refactoring Kata](https://github.com/emilybache/GildedRose-Refactoring-Kata)

## BUILD AND RUN
Prerequisites for build from console:
   - [Net Framework 4.5.2](https://dotnet.microsoft.com/download/dotnet-framework/net452)
   - [nuget.exe](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe)
   
Prerequisites for build from VS:
   - [Net Framework 4.5.2](https://dotnet.microsoft.com/download/dotnet-framework/net452)
   - [Visual Studio 2019](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)
   
Build from console:
 1. open console in the solution directory
 2. ```nuget restore GildedRoseKata.sln``` path to ```nuget.exe``` should be system known
 3. ```MSBuild.exe GildedRoseKata.sln``` path to ```MSBuild.exe``` should be system known
 
Build from VS2019:
 1. Open solution in VS and build rebuild solution

Run tests from console (after successfull build)
 1. install [nunit-console](https://github.com/nunit/nunit-console/releases/download/v3.10/NUnit.Console-3.10.0.msi)
 2. ```nunit3-console.exe .\tests\GildedRoseKata.Tests\GildedRoseKata.Tests.csproj``` path to ```nunit3-console.exe``` should be system known

Run program:
 1. After successfull buil, run ```.\src\GildedRoseKata\bin\Debug\GildedRoseKata.exe```

## Steps how it was done:
 1. Current implementation of Update method was covered with unit tests. The values for border edges was defined from the specification.
 2. Since this is crucial requirement to do not break anything, I decided to cover all possible values of sellIn and quality with tests. Those tests are some kind like text test, but doesn't depend on output. With this tests I tried to implement logic from requirements to predict the output values.
 3. After full cover was implemented, I was able safly refactor Update method.
 4. I decided to use OOP approach since it is quiet simple logic and there are not so many sellIn borders. In case of more different item types we can consider approach based on Rules where we define sellIn range in each rule and modifier for Quality.
 5. Interface [IUpdater](https://github.com/meshcheryakov83/GildedRose-Refactoring-Kata-csharp/blob/master/src/GildedRoseKata/Model/Updaters/IUpdater.cs) was added and logic of item updating should be placed in a class that implements this interface.
 6. Class [DefaultUpdater](https://github.com/meshcheryakov83/GildedRose-Refactoring-Kata-csharp/blob/master/src/GildedRoseKata/Model/Updaters/DefaultUpdater.cs) was added with default update logic. So some items can use it (like [Dexterity](https://github.com/meshcheryakov83/GildedRose-Refactoring-Kata-csharp/blob/master/src/GildedRoseKata/Model/Item.cs#L9), [Elixir](https://github.com/meshcheryakov83/GildedRose-Refactoring-Kata-csharp/blob/master/src/GildedRoseKata/Model/Item.cs#L7) or even 'foo') and some can be inhereted to override quality update logic but still keep the same the quality restriction policies.
 7. After refactoring of Update logic (and fixing all broken tests) I was able to add tests for new [Conjured item type](https://github.com/meshcheryakov83/GildedRose-Refactoring-Kata-csharp/blob/master/src/GildedRoseKata/Model/Item.cs#L10)
 8. After the tests were ready I was able to add this new item itself. Here I required to change the approved text from text test to keep proper values of Conjured quality and sellIn.

[![BCH compliance](https://bettercodehub.com/edge/badge/meshcheryakov83/GildedRose-Refactoring-Kata-csharp?branch=master)](https://bettercodehub.com/)
