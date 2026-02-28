# Recipe Book

![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-Entity%20Framework-blue)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927)
![Type](https://img.shields.io/badge/Type-WinForms%20App-darkcyan)
![License](https://img.shields.io/badge/License-MIT-green)

---

## Beskrivning

**Recipe Book** är en modern WinForms-applikation byggd med .NET 10 och C# för att hantera recept, ingredienser och kategorier via ett grafiskt användargränssnitt. 

Data lagras i en Microsoft SQL Server-databas och all databasinteraktion sker med Entity Framework Core för robust och asynkron hantering.


Applikationen är strukturerad i modulära klasser (Recipe, Ingredient, Category, RecipeIngredient, RecipeCategory) som kapslar in respektive domänfunktion. Tjänstelagret (RecipeService) hanterar CRUD-operationer och affärslogik, medan olika formulär (MainForm, CreateRecipeForm, EditRecipeForm, ShowForm) sköter UI och användarflöden.


Databasen skapas automatiskt vid start med tabeller, unika index och relationshantering (many-to-many) via kopplingstabeller. On-delete-beteenden och constraints säkerställer dataintegritet, och all dataoperation sker asynkront för bästa prestanda och användarupplevelse.

---

## Funktioner

- Skapa recept: lägga till namn, beskrivning, instruktioner samt ingredienser och kategorier.
- Visa och söka recept: lista alla recept, sök och öppna detaljer för att se fullständig ingredienslista.
- Redigera recept: ändra receptdata, uppdatera mängder/enheter och ändra tillhörande kategorier.
- Ta bort recept: radera ett recept; kopplingar i `RecipeIngredients` och `RecipeCategories` tas bort automatiskt.
- Hantera ingredienser: skapa och uppdatera ingredienser med unika namn och standardenheter för återanvändning.
- Hantera kategorier: skapa och återanvänd kategorier med unika namn för enkel organisering.
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

- .NET SDK 10 (Target Framework: `net10.0`)
- Microsoft SQL Server (kan köras i Docker)
- Visual Studio eller VS Code med C#-stöd

---

## Installation

### 1. Klona projektet

```bash
git clone https://github.com/AlaaAlsous/recipebook.git
```

### 2. Installera beroenden

Se till att .NET SDK 10 är installerat.

### 3. Starta SQL Server med Docker (rekommenderas)

```bash
- docker pull mcr.microsoft.com/mssql/server:2022-latest

- docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Secret-Recipe-Book-Password!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

Skapa databas och användare:

```bash
- docker exec -i sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "Secret-Recipe-Book-Password!" -Q "CREATE DATABASE recipe_book_db;" -C

- docker exec -i sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "Secret-Recipe-Book-Password!" -d recipe_book_db -Q "CREATE LOGIN [recipebook] WITH PASSWORD = 'Secret-Recipe-Book-Password!'; CREATE USER [recipebook] FOR LOGIN [recipebook]; ALTER ROLE db_owner ADD MEMBER [recipebook];" -C
```

### 4. Applicera migrationer

```bash
dotnet tool install --global dotnet-ef

dotnet ef database update
```

### 5. Kör applikationen

```bash
dotnet run --project RecipeBook.csproj
```

---

## Användning

Vid start öppnas huvudfönstret där du kan:

- Skapa nya recept med ingredienser och kategorier
- Söka, visa, redigera och ta bort recept
- Hantera ingredienser och kategorier

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
- Automatisk skapande av databas och tabeller via `EnsureCreated()`.

---

## Teknisk miljö

- Target Framework: `net10.0`
- Paket:
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Design`

---

## Utvecklare

**Alaa Alsous**

Språk: C#  
Plattform: .NET 10  
Verktyg: Visual Studio
