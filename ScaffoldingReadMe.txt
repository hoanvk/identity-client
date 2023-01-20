Support for ASP.NET Core Identity was added to your project.

For setup and configuration information, see https://go.microsoft.com/fwlink/?linkid=2116645.
dotnet ef migrations add CreateIdentitySchema -c RoleBaseDemo.Areas.Identity.Data.RoleBaseDemoIdentityDbContext --output-dir Migrations/Identity
dotnet ef migrations add CreateIdentitySchema -c RoleBaseDemo.Data.RoleBaseDemoContext --output-dir Migrations/Movie
