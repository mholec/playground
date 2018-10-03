# Pohled na .NET Core ekosystem

Tento modul má za cíl seznámit s instalací .NET Core a základním seznámením kde se dotnet nachází na disku, jak pracovat s CLI a jak využít nástroj dotnet pro založení projektu. Dále modul seznamuje účastníka se založením nového projektu a novým csproj formátem. Účastník pochopí evoluci ASP.NET Core, seznámí se s runtimes typu App a All a bude znát použití složky wwwroot.

## Prezentace: Pohled na .NET Core ekosystem

TODO

## DEMO: Seznámení s .NET Core CLI

- **dotnet download** website https://www.microsoft.com/net/download
  - ukázky verzí, upozornění na v1.x (dříve součást VS)
  - archiv, rozdíl vydávání verzí LTS vs Current vs Preview
- **instalace SDK** (součástí jsou runtimes)
- použití nástroje dotnet - **dotnet --info** a **dotnet --help**
- **umístění SDK** a runtimes na disku (viz. to co se vrací v CMD)

## DEMO: Založení a správa projektu

- **založení projektu** ve Visual Studio (porovnánídruhů šablon)

- založení projektu příkazovou řádkou přes **dotnet new --help**

- **dotnet new web -lang c# -o src/library**

- **editace csproj** bez unloadu a poznámky k historickým verzím

  - vysvětlení sekcí nového csproj
    - nový csproj obsahuje odkazy na nugety, neobsahuje odkazy na všechny files
  - seznámení s odkazem na SDK **<Project Sdk="Microsoft.NET.Sdk"...** - možnost vlastní SDKs
  - **wwwroot** jako static folder a chování prázdných složek
  - target framework a chování **Dependencies** a NuGet
    - https://docs.microsoft.com/cs-cz/nuget/reference/target-frameworks
  - **runtime identifiers** pro buildění pro konkrétní verzi (SCD)

  - porovnání metabalíčků **All** vs **App**, striktnost verzí na NuGetu
