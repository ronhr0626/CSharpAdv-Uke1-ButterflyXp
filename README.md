# ButterflyXp

C# Advanced – Ukesoppgave 1: Fra behov til REST API

**Project:** XP / Level system. A butterfly gains XP and levels up through its life stages.

| Level | XP    | Stage     |
|-------|-------|-----------|
| 1     | 0–9   | Egg       |
| 2     | 10–19 | Larva     |
| 3     | 20–29 | Pupa      |
| 4     | 30+   | Butterfly |

## Project structure

```
excalidraw/              MVP diagram
ButterflyXp.Core/        Domain logic (Butterfly, ButterflyService, repository)
ButterflyXp.Tests/       Domain tests (xUnit)
ButterflyXp.Api/         REST API (controller)
ButterflyXp.Api.Tests/   API contract tests (WebApplicationFactory)
api.md                   API contract
```



## Run the tests

```bash
dotnet test
```

## Run the API

```bash
dotnet run --project ButterflyXp.Api
```

Open Scalar in the browser to test the endpoints manually:

```
http://localhost:<port>/scalar
```

Use the port shown in the terminal.

## API

See [api.md](api.md) for endpoints, request bodies and status codes.

Data is stored in memory, so all butterflies are lost when the API restarts.