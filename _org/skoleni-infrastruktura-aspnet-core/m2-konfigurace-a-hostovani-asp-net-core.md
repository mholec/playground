# Konfigurace a hostování ASP.NET Core

Tato část seznamuje účastníka se strukturou ASP.NET Core aplikace a zavedením konfiguračních souborů. Modul se věnuje podrovně problematice environment variables a jejich nastavení různými způsoby. Účastník kurzu je seznámen s interním serverem Kestrel a možnostmi konfigurace a dále s tzv. deployment modely FDD a SSD, jejich výhodami a charakteristikami. V rámci modulu je dále předvedeno zahostování aplikaci na lokálním počítači a vysvětlení jakým způsobem funguje vazba mezi interním serverem a IIS.

## Prezentace: Konfigurace a hostování ASP.NET Core

1. bod
2. bod
3. bod
4. bod

## DEMO: Konfigurace ASP.NET Core

- **program cs** a zavedení kestrelu

- **startup.cs**, ConfigureServices a Configure

- konfigurační modul, **json konfigurace** a IConfiguration

  - podpora INI konfigurací, přes config builder **AddIniFile**

  - priorita dle pořadí registrace, proto je lepší mít to pod kontrolou

    ```c#
    public static IConfigurationBuilder AddIniFiles(this IConfigurationBuilder config, string filename, bool reloadable = false)
    {
    	var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    
    config.AddIniFile($"{filename}.ini", false, reloadable);
    config.AddIniFile($"{filename}.{environment}.ini", true, reloadable);
    
    return config;
    
    }
    ```

- **konfigurační konvence**, dvojtečky a podtržítka (:, __)

- environment variables a nastavení v lokálním prostředí

  - nastavení windows přes CMD: **setx ASPNETCORE_ENVIRONMENT "Development"**
  - pomocí powershellu **$Env:ASPNETCORE_ENVIRONMENT = "Development"**
  - přes ovládací panel (hledat přes WIN pojem "proměnné prostředí" v CZ)
  - v IDE pomocí Properties/**launchSettings.json** nebo ve VS Code **launch.json**
  - při spuštění z cmd pomocí **dotnet run --environment "Staging"**
  - další nastavení jsou pak až na úrovni IIS (viz. později hostování)

## DEMO: Deployment a hostování

- Kestrel a nastavení v aplikaci, co se skrývá za **CreateDefaultBuilder()**

  - Override nastavení pomocí UseKestrel()

    ```c#
    WebHost.CreateDefaultBuilder(args)
        .UseKestrel(opt =>
          {
           opt.Limits.MaxRequestBodySize = int.MaxValue;
          })
    ```

    info: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/web-host?view=aspnetcore-2.1

- **ASP.NET Core Module**, hostování s IIS, odkaz na hosting bundle package

  - https://www.microsoft.com/net/download/thank-you/dotnet-runtime-2.1.3-windows-hosting-bundle-installer

- **HTTP.sys** (dříve WebListener) a základní výhody a nastavení v aplikaci (nemá podporu IIS)

- Rozdíl mezi **FDD a SCD**, ukázky balíčků k nasazení

- **Nasazení aplikace na lokální IIS**

  - Upozornění na rozdíly FDD (targetuje se na dotnet tool) vs SCD (targetuje se na aplikace.exe - ve světě win)

- **Publikace do Azure**
