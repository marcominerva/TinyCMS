# TinyCMS

[![Lint Code Base](https://github.com/marcominerva/TinyCMS/actions/workflows/linter.yml/badge.svg)](https://github.com/marcominerva/TinyCMS/actions/workflows/linter.yml)
[![CodeQL](https://github.com/marcominerva/TinyCMS/actions/workflows/codeql.yml/badge.svg)](https://github.com/marcominerva/TinyCMS/actions/workflows/codeql.yml)
[![Deploy on Azure](https://github.com/marcominerva/TinyCMS/actions/workflows/deploy.yml/badge.svg)](https://github.com/marcominerva/TinyCMS/actions/workflows/deploy.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/marcominerva/TinyCMS/blob/master/LICENSE)

The smallest CMS engine ever, made with [ASP.NET Core](https://github.com/dotnet/aspnetcore) and [Dapper](https://github.com/DapperLib/Dapper). Currently, only static content is supported, but adding new pages is as simple as inserting a new row in a database table with the raw HTML content of the page.

**Setup**

1. Create database tables using the scripts available in the [TinyCms.Database](https://github.com/marcominerva/TinyCMS/tree/master/database) project
2. Insert a row in the _Sites_ table (currently, only a single site is supported)
3. Insert at least a row in the _ContentPages_ table for the Home Page of the site, using **index** as url. The **Content** column can be any HTML
4. Create all the other pages in the _ContentPages_ table, with the url you want
5. (optional) Specify 404 and 403 response pages inserting the corresponding rows in the _ContentPages_ table, using **404** and **403** url respectively
6. Set the database connection string in the [appsettings.json](https://github.com/marcominerva/TinyCMS/blob/master/src/TinyCms/appsettings.json#L3) file.
7. Have fun :wink:
 
**Contribute**

The project is constantly evolving. Contributions are welcome. Feel free to file issues and pull requests on the repo and we'll address them as we can. 
