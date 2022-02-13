# GoogleMapsTests

This project is a sample using Selenium 4 with NUnit.

# setup

Run using docker compose:

```bash
docker-compose up -d
docker-compose exec dotnet bash
```

Install the dependencies:

```bash
dotnet build
```

Run the tests:

```bash
dotnet test --no-build
```

Remove the containers:

```bash
docker-compose down
```
