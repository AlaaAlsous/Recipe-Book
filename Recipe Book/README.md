# Recipe Book — Instruktioner

Detta är ett enkelt program för att spara och visa recept. Det använder Entity Framework Core (EF) och Microsoft SQL Server.

## Snabbstart — steg för steg (kopiera/klistra i terminalen)

1) Hämta SQL Server Docker-image:

```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
```

2) Starta en SQL Server-container:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Secret-NET.25-Password!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

Observera: SQL Server kan behöva några sekunder för att bli redo. Vänta 10–20 sekunder innan nästa steg.

3) Skapa databasen `net25_db` och användaren `net25` (kopiera/klistra):

```bash
# Skapar databasen net25_db och användaren net25 med samma lösenord
docker exec -i sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "Secret-NET.25-Password!" -Q "CREATE DATABASE net25_db; CREATE LOGIN [net25] WITH PASSWORD = 'Secret-NET.25-Password!'; USE net25_db; CREATE USER [net25] FOR LOGIN [net25]; ALTER ROLE db_owner ADD MEMBER [net25];" -C
```

4) Starta programmet:

- Klona repot.
- Öppna projektet i Visual Studio eller kör `dotnet run` i projektmappen.

5) Vad programmet gör automatiskt vid start:

- Programmet kör `context.Database.EnsureCreated()` (se `Program.cs`).
- Det betyder: om databasen och tabellerna inte finns skapas de automatiskt från EF-modellen.
- Du behöver alltså inte skapa tabeller manuellt efter steg 3.


## Anslutningsinställningar (standard)

Fil: `Data/RecipeDbContext.cs` (metoden `OnConfiguring`)

- Server: `localhost,1433`
- Database: `net25_db`
- User: `net25`
- Password: `Secret-NET.25-Password!`


## Snabb kontroll efter start

Om du vill kontrollera att tabeller skapats, kör detta (kopiera):

```bash
# Lista tabeller
docker exec -i sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U net25 -P "Secret-NET.25-Password!" -d net25_db -Q "SELECT name FROM sys.tables;" -C
```


## En översiktlig guide för hur programmet fungerar

- Lägga till recept med ingredienser och kategorier
  - Använd GUI: öppna "Skapa recept" (fil: `Forms/CreateRecipeForm.cs`).
  - Ingredienser lägger du till i formulärets ingrediensfält och de visas i en lista/grid innan du sparar.
  - Kategorier anges som kommaseparerad text och tolkas av `RecipeFormHelper`.
  - När du sparar anropas `Services/RecipeService.AddRecipeAsync`: receptet sparas i `Recipes`, nya ingredienser och kategorier skapas i `Ingredients`/`Categories` om de saknas, och kopplingar läggs i `RecipeIngredients`/`RecipeCategories`.

- Spara, visa, redigera och ta bort recept
  - Huvudfönstret visar receptlistan (`Forms/MainForm.cs`), där du kan redigera eller ta bort ett recept.
  - Visa detaljer: `Forms/ShowForm.cs` (hämtar recept med `Include` för ingredienser och kategorier via `RecipeService`).
  - Redigera: `Forms/EditRecipeForm.cs` skickar uppdaterade värden till `RecipeService.UpdateRecipeAsync`, vilket ersätter gamla kopplingar och sparar nya.
  - Ta bort: `RecipeService.DeleteRecipeAsync` tar bort receptet; försök att ta bort en ingrediens som används förhindras av `DeleteIngredientAsync`.

- Datamodellen (tabeller och relationer)
  - Huvudtabeller: `Recipes`, `Ingredients`, `Categories` (finns i `Models/`).
  - Kopplingstabeller: `RecipeIngredients` (lagrar även `Quantity` och `Unit`) och `RecipeCategories` för många-till-många-relationer.
  - Index och constraints: namnfält är markerade som unika i modellerna för att undvika dubbletter; relationer och OnDelete-beteenden definieras i `Data/RecipeDbContext.cs`.

Alla operationer använder Entity Framework Core (parameteriserade anrop) och sparas via `_context.SaveChangesAsync()` i `RecipeService`, vilket skyddar mot SQL‑injektion och håller logiken samlad i servicelagret.


## Varför Entity Framework?

- Mindre SQL-kod – Du skriver C# istället för långa SQL-frågor, vilket gör utvecklingen snabbare och koden renare.
- Skydd mot SQL injection – Parameterisering används automatiskt när du kör LINQ-frågor, vilket gör koden säkrare.
- Automatisk mapping (ORM) – Tabeller och kolumner mappas direkt till klasser och properties, så du jobbar med objekt istället för råa databastabeller.
- Change Tracking – EF håller koll på ändringar i objekt och uppdaterar databasen korrekt när du sparar.
- Migrationer – Du kan uppdatera databasschemat via kod och versionshantera ändringar enkelt.
- LINQ-stöd – Stark typning, IntelliSense och compile-time fel gör frågorna lättare att skriva och läsa.

## Kort analys

- Modell: Recept, ingredienser och kategorier ligger i egna tabeller. Det minskar dubbletter och gör det lättare att uppdatera data.
- Prestanda: Index på namn och FK gör sökningar snabbare. Vid många poster, visa sida för sida (paginering) och hämta bara de kolumner som behövs.
- Läsning: `Include` hämtar relaterad data men kan bli tungt för stora listor. Använd projektion (Select) eller paginering när det behövs.

