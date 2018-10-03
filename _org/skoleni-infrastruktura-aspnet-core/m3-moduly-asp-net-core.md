# Moduly ASP.NET Core

Cílem této části kurzu je naznačit účastníkům, jaké existují v ASP.NET Core moduly a k čemu je možné je obecně použít. Tato část nemá za cíl probírat jednotlivé moduly do hloubky, ale spíše ukázat jakou mají roli v ASP.NET Core a co vývojáři ve finále umožňují.

## Prezentace: Moduly ASP.NET Core

- Rozdělení ASP.NET Core / MVC / Web API / Razor Pages



## DEMO: Moduly ASP.NET Core

První část je zaměřená na konfiguraci obecně. Jedná se o základní princip Dependency Injection a nastavení kontejneru v ConfigurationServices. Toto nastavení pak umožní globálně měnit chování aplikace nebo přidávat obecné funkce.

- Dependency Injection
- Configuration Options
- Logging
- HttpContext

Další část již souvisí se změnami v Request pipeline

- Middlewares
- Error Handling
- Localization / Globalization

Další témata

- IApplicationLifetime a reakce na události ApplicationStarted...
- Background Tasks Hosted Services