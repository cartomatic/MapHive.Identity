MapHive auth related projects:

IdentityServer3 implementation
More on IdentityServer: https://identityserver.github.io/

MembershipReboot implementation
More info on MembershipReboot: https://github.com/brockallen/BrockAllen.MembershipReboot

Identity Core API - api exposing some user membership related functionality, such as authentication, user management, etc.

Note:
This project is based on the IdentityServer3 & MembershipReboot examples

Deploy notes:
* project depends on Cartomatic.Utils - https://github.com/cartomatic/Utils; Cartomatic.Utils.Path should be a part of a solution and referenced by 
  the IdentityServer project 
* make sure the Certs directory contains a idsrv.maphive.net.pfx that can be found in https://github.com/cartomatic/MapHive.Identity under DevCerts
* project should bo configured to be debugged through IIS - the local dev domain is https://idsrv.maphive.local
* the above should be enough to build the project


Db restore notes:
* since both projects use db storage - IdentityServer and MembershipReboot, both need to have the db present in order to avoid errors.
* database server is pgsql 9.5 or newer, in dev mode configured to listen on 5434 and with an admin user postgres/postgres

* MembershipReboot is a class lib and does not contain a config; db configuration is always provided dynamically via IdentityServer or any other code using it; therefore
  in order oto restore the db properly a following EF update-database should be executed:
  Update-Database -ProjectName MembershipReboot -ConnectionString "server=localhost;user id=postgres;password=postgres;database=maphive_mr;port=5434" -ConnectionProviderName Npgsql
  
* IdentityServer on the other hand uses 3 independent DbContexts and 3 appropriate migration confogurations and will also not work with the default
  update-database command but requires 3 customised ones instead:
  Update-Database -ProjectName IdentityServer -ConnectionStringName IdentityServerDb -ConfigurationTypeName MapHive.Identity.IdentityServer.Migrations.ClientConfiguration.Configuration
  Update-Database -ProjectName IdentityServer -ConnectionStringName IdentityServerDb -ConfigurationTypeName MapHive.Identity.IdentityServer.Migrations.OperationalConfiguration.Configuration
  Update-Database -ProjectName IdentityServer -ConnectionStringName IdentityServerDb -ConfigurationTypeName MapHive.Identity.IdentityServer.Migrations.ScopeConfiguration.Configuration
