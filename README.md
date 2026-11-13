# Recipe Book

![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-Entity%20Framework-blue)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white)
![Type](https://img.shields.io/badge/Type-WinForms%20App-darkcyan)
![License](https://img.shields.io/badge/License-MIT-green)

---

## Beskrivning


**Recipe Book** är en modern WinForms-applikation byggd med .NET 10 och C# för att hantera recept, ingredienser och kategorier via ett grafiskt användargränssnitt. Du kan även skriva ut recept direkt från applikationen.

Appen använder SQLite som standard och sparar databasen lokalt i användarens `LocalApplicationData`-mapp. Om miljövariabeln `RECIPE_BOOK_SQLSERVER` innehåller en anslutningssträng ansluter appen i stället till SQL Server, till exempel en SQL Server-container som körs via Docker.

Applikationen är strukturerad i modulära klasser (Recipe, Ingredient, Category, RecipeIngredient, RecipeCategory) som kapslar in respektive domänfunktion. Tjänstelagret (RecipeService) hanterar CRUD-operationer och affärslogik, medan olika formulär (MainForm, CreateRecipeForm, EditRecipeForm, ShowForm) sköter UI och användarflöden. Utskriftsfunktionen finns i receptvyn.

Databasen skapas automatiskt vid start med tabeller, unika index och relationshantering (many-to-many) via kopplingstabeller. On-delete-beteenden och constraints säkerställer dataintegritet, och all dataoperation sker asynkront för bästa prestanda och användarupplevelse.

---


## Funktioner

- Skapa recept: lägga till namn, beskrivning, instruktioner samt ingredienser och kategorier.
- Visa och söka recept: lista alla recept, sök och öppna detaljer för att se fullständig ingredienslista.
- Redigera recept: ändra receptdata, uppdatera mängder/enheter och ändra tillhörande kategorier.
- Ta bort recept: radera ett recept; kopplingar i `RecipeIngredients` och `RecipeCategories` tas bort automatiskt.
- Hantera ingredienser: skapa och uppdatera ingredienser med unika namn och standardenheter för återanvändning.
- Hantera kategorier: skapa och återanvänd kategorier med unika namn för enkel organisering.
- **Skriv ut recept:** Du kan skriva ut recept direkt från applikationen via utskriftsfunktionen i receptvyn.
- Många-till-många-relationer: stöd för flera ingredienser och kategorier per recept via kopplingstabeller.
- Asynkrona databasanrop: använder `SaveChangesAsync()` för bättre respons i gränssnittet.
- Automatisk databasuppsättning: databas och tabeller skapas vid första körning med `EnsureCreated()` eller via migrationer.
- Dataintegritet: unika index och on-delete-regler (cascade/restrict) säkerställer konsistens och förhindrar oavsiktlig borttagning.

---

## Projektstruktur

```plaintext
RecipeBook/
├─ RecipeBook.csproj
├─ Program.cs
├─ Data/
│  └─ RecipeDbContext.cs
├─ Models/
│  ├─ Recipe.cs
│  ├─ Ingredient.cs
│  ├─ Category.cs
│  ├─ RecipeIngredient.cs
│  └─ RecipeCategory.cs
├─ Services/
│  ├─ RecipeService.cs
│  └─ RecipeFormHelper.cs
├─ Forms/
│  ├─ MainForm.cs
│  ├─ CreateRecipeForm.cs
│  ├─ EditRecipeForm.cs
│  └─ ShowForm.cs
├─ Assets/
│  └─ (bilder, ikoner)
├─ Migrations/
└─ README.md
```
---

## Systemkrav

- Windows 10/11 för den grafiska appen
- .NET SDK 10 för utveckling och publicering
- SQL Server krävs endast om du väljer den valfria SQL Server-anslutningen
- Visual Studio eller VS Code med C#-stöd

---

## Installation

### Köra appen lokalt

```bash
git clone https://github.com/AlaaAlsous/recipebook.git
```

### Installera beroenden

Installera .NET 10 SDK och återställ projektets NuGet-beroenden:

```powershell
dotnet restore ".\Recipe Book.csproj"
```

Kör sedan appen:

```powershell
dotnet run --project ".\Recipe Book.csproj"
```
Appen använder SQLite som standard. Databasen skapas automatiskt bredvid appens `.exe`-fil:

```text
Recipe-Book.sqlite
```

### Säkerhetskopiera SQLite-databasen

Recepten sparas i `Recipe-Book.sqlite` i samma mapp som appens `.exe`-fil. Stäng appen innan du kopierar filen, så att säkerhetskopian blir komplett. Om du kör kommandot från appens mapp kan du kopiera databasen till skrivbordet så här:

```powershell
$backup = Join-Path ([Environment]::GetFolderPath("Desktop")) "Recipe-Book-backup.sqlite"
Copy-Item ".\Recipe-Book.sqlite" $backup
```

För att återställa databasen stänger du appen och kopierar `Recipe-Book-backup.sqlite` tillbaka till appens `.exe`-mapp med namnet `Recipe-Book.sqlite`. Lägg appen i en mapp där din användare har skrivbehörighet; Windows skyddade mappar som `C:\Program Files` tillåter normalt inte appen att skapa databasen där.

Om appen i stället är konfigurerad att använda SQL Server via Docker lagras recepten i SQL Server-containern, inte i SQLite-filen. Den här kopieringsinstruktionen gäller då inte; säkerhetskopiera SQL Server-databasen separat innan containern tas bort.

### Publicera en fristående Windows-app

```powershell
dotnet publish ".\Recipe Book.csproj" -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
```

Den publicerade appen finns i `bin\Release\net10.0-windows\win-x64\publish\`.

### Valfri SQL Server i Docker (utveckling)

Appen startar inte Docker automatiskt. Skapa och starta först en SQL Server-container. I PowerShell anger du ett starkt lösenord och skapar containern så här:

```powershell
$saPassword = Read-Host "Ange ett starkt SQL Server SA-lösenord"
docker run --name recipe-book-sql `
  -e "ACCEPT_EULA=Y" `
  -e "MSSQL_SA_PASSWORD=$saPassword" `
  -p 1433:1433 `
  -d mcr.microsoft.com/mssql/server:2022-latest
```

Vänta tills SQL Server är redo, till exempel med `docker logs -f recipe-book-sql`, och avbryt loggvisningen med `Ctrl+C`. Anslut sedan appen till containern i samma PowerShell-fönster:

```powershell
$env:RECIPE_BOOK_SQLSERVER = "Server=localhost,1433;Database=recipe_book_db;User Id=sa;Password=$saPassword;TrustServerCertificate=True;Encrypt=True;"
dotnet run --project ".\Recipe Book.csproj"
```

SQLite är standard. När `RECIPE_BOOK_SQLSERVER` är satt använder appen anslutningssträngen och väljer SQL Server; SQL Server-containern måste redan vara igång. Databasen skapas automatiskt vid första start. Docker-instruktionerna ovan är avsedda för lokal utveckling, inte för en publik appnedladdning. Om en anslutningssträng är angiven men SQL Server inte går att nå visas ett databasfel; appen byter inte tyst till SQLite.

---

## Användning


Vid start öppnas huvudfönstret där du kan:

- Skapa nya recept med ingredienser och kategorier
- Söka, visa, redigera och ta bort recept
- Hantera ingredienser och kategorier
- Skriva ut recept

---

## Databasdesign

Databasen är designad för att hantera recept, ingredienser och kategorier med stöd för många-till-många-relationer. Nedan beskrivs tabeller, kolumner och relationer så som de faktiskt är implementerade:

### Tabeller

- **Recipes**
  - `RecipeId` (int, PK, auto-increment): Unikt ID för varje recept
  - `Name` (nvarchar(200), UNIQUE, NOT NULL): Namn på receptet
  - `Description` (nvarchar(1000), NULL): Beskrivning av receptet
  - `Instructions` (nvarchar(2000), NULL): Instruktioner för tillagning
  - `CreatedAt` (datetime2, NOT NULL): Skapandedatum
  - `UpdatedAt` (datetime2, NOT NULL): Senaste ändringsdatum

- **Ingredients**
  - `IngredientId` (int, PK, auto-increment): Unikt ID för varje ingrediens
  - `Name` (nvarchar(200), UNIQUE, NOT NULL): Namn på ingrediensen
  - `QuantityUnit` (nvarchar(50), NOT NULL): Standardenhet för ingrediensen

- **Categories**
  - `CategoryId` (int, PK, auto-increment): Unikt ID för varje kategori
  - `Name` (nvarchar(100), UNIQUE, NOT NULL): Namn på kategorin

- **RecipeIngredients**
  - `RecipeId` (int, FK): Referens till `Recipes.RecipeId`
  - `IngredientId` (int, FK): Referens till `Ingredients.IngredientId`
  - `Quantity` (decimal, NOT NULL): Mängd av ingrediensen
  - `Unit` (nvarchar(50), NOT NULL): Enhet (t.ex. g, ml, st)
  - **Primärnyckel:** (`RecipeId`, `IngredientId`)

- **RecipeCategories**
  - `RecipeId` (int, FK): Referens till `Recipes.RecipeId`
  - `CategoryId` (int, FK): Referens till `Categories.CategoryId`
  - **Primärnyckel:** (`RecipeId`, `CategoryId`)

### Relationer

- Ett recept kan ha flera ingredienser och kategorier (many-to-many)
- Ingredienser och kategorier kan återanvändas i flera recept
- Kopplingstabellerna `RecipeIngredients` och `RecipeCategories` hanterar dessa relationer

### On-Delete-beteenden

- Om ett recept tas bort:
  - Relaterade poster i `RecipeIngredients` och `RecipeCategories` tas bort (Cascade)
- Om en ingrediens eller kategori tas bort:
  - Kan endast tas bort om de inte används i något recept (Restrict)
  - Relaterade poster i kopplingstabeller tas inte bort automatiskt

### Entity Framework-konfiguration

- Relationer och on-delete-beteenden konfigureras i `RecipeDbContext` med `modelBuilder` och `Fluent API`.
- Unika namn för recept, ingredienser och kategorier säkerställs med `HasIndex(...).IsUnique()`.
- Databas och tabeller skapas vid första start via `EnsureCreated()`.
- De befintliga migrationsfilerna är genererade för SQL Server och körs inte av appen. SQLite använder `EnsureCreated()` i stället.

---

## Teknisk miljö


- Target Framework: `net10.0-windows`
- UI: Windows Forms
- Paket:
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.Sqlite`
  - `Microsoft.EntityFrameworkCore.SqlServer` (valfri SQL Server-anslutning)
  - `Microsoft.EntityFrameworkCore.Design`

---

## Utvecklare

**Alaa Alsous**

Språk: C#  
Plattform: .NET 10  
Verktyg: Visual Studio
