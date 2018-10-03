### Nová migrace

	dotnet ef migrations add InitMigration

### Generování skriptu

```
dotnet ef migrations script
```

### Update databáze

	dotnet ef database update

### Scaffolding

	dotnet ef dbcontext scaffold "connectionstring" Microsoft.EntityFrameworkCore.  
	SqlServer -o Models -f -c DemoDbContext