# FluentCases

FluentCases is a small .NET library for writing tests in a `Given` / `When` / `Then` style with a fluent API.

## What It Does

The library wraps a test context and lets you express arrange, act, and assert steps as a readable chain:

```csharp
using FluentCases;

ShoppingBasket basket = new();

Case
    .Given(basket, x => x.StartEmpty())
    .When(x => x.AddItem(price: 12.50m))
    .Then(x => x.TotalShouldBe(12.50m))
    .And(x => x.ItemCountShouldBe(1));
```

The current API supports:

- `Case.Given(context, arrange)`
- `Case.Given(create, arrange)`
- `When(act)`
- `Then(assert)`
- `And(assert)`

## Project Structure

```text
fluentcases/
├── src/FluentCases
└── tests/FluentCases.Tests
```

- `src/FluentCases` contains the library code.
- `tests/FluentCases.Tests` contains the xUnit test project and usage examples.

## Target Frameworks

- Library: `netstandard2.0`
- Tests: `net10.0`

## Build

```bash
dotnet build src/FluentCases/FluentCases.csproj
```

## Test

```bash
dotnet test tests/FluentCases.Tests/FluentCases.Tests.csproj
```

## Notes

- The fluent chain executes each step immediately.
- `Given`, `When`, `Then`, and `And` all validate null delegates.
- `Case.Given(create, arrange)` also guards against a null context returned by the factory.
