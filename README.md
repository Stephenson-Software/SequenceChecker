# Problem Statement
Given two non-empty arrays of integers, write a function that determines whether the second array is a subsequence of the first one.

# Subsequence Definition
A subsequence of an array is a set of numbers that aren’t necessarily adjacent in the array but that are in the same order as they appear in the array. Ex. [1, 3, 4] form a subsequence of the array [1, 2, 3, 4]

# Requirements
A .NET SDK able to target `netcoreapp3.1`, which is the `<TargetFramework>` declared in `Hacker-Challenge-6-17-21.csproj`. That framework is out of support, so a current SDK may need the .NET Core 3.1 targeting pack installed alongside it. See issue #5.

Note that the solution and the project are named after the original challenge (`Hacker-Challenge-6-17-21`) rather than after this repository. See issue #6.

# Build
```
dotnet build Hacker-Challenge-6-17-21.sln
```

# Run
```
dotnet run --project Hacker-Challenge-6-17-21.csproj
```

The bundled `Driver` checks the hardcoded arrays `{ 1, 2, 3, 4 }` and `{ 1, 3, 4 }` — the example from the definition above — and prints:

```
First Array: 1, 2, 3, 4
Second Array: 1, 3, 4
Is the second array a subsequence of the first array? True
```

# Usage
The `SequenceChecker` class lives in the `Hacker_Challenge_6_17_21` namespace and exposes three methods, which are intended to be called in this order:

| Method | Description |
|--------|-------------|
| `Initialize(int[] first, int[] second, bool d = false)` | Stores the two arrays to be compared. The optional third argument enables debug output, which is written to the console. |
| `PerformCheck()` | Prints both arrays, runs the check, and stores the outcome. |
| `GetResult()` | Returns the outcome of the last check as a `bool`. |

```csharp
SequenceChecker checker = new SequenceChecker();
checker.Initialize(new int[] { 1, 2, 3, 4 }, new int[] { 1, 3, 4 });
checker.PerformCheck();
bool result = checker.GetResult();
```

The call order is not enforced. `GetResult()` returns `false` when `PerformCheck()` has not been called, which is indistinguishable from a completed check that found no subsequence (see issue #4), and `PerformCheck()` throws when `Initialize()` has not been called.

As the problem statement states, both arrays are expected to be non-empty. Empty input is nonetheless accepted rather than throwing: an empty second array is reported as a subsequence of any first array, following the convention that the empty sequence is a subsequence of every sequence, and an empty first array is reported as containing no non-empty second array.

`SequenceChecker` is `public`, so it is visible to other assemblies. The project still declares `<OutputType>Exe</OutputType>`, so consuming the class from another project means referencing this executable assembly rather than a library. The `Driver` class carries no access modifier and stays `internal`; it exists only to run the bundled example.
