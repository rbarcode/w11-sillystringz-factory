# Dr. Sillystringz's Factory

#### By Richard Barbour II

#### C# ASP.NET Core MVC web application with many-to-many relationships using MySQL database.

## Technologies Used

* C#
* HTML
* .Net 6.0 SDK (incl. NuGet)
* ASP.NET Core MVC
* MySQL 8.0.34
* Microsoft's Entity Framework Core
* Pomelo.EntityFrameworkCore.MySql (3rd party provider for MySQL compatible databases)
* dotnet-ef

## Description

This web-based application tracks engineers and machines for a factory manager using a MySQL database and offers full CRUD (Create Read Update Delete) functionality for both engineers and machines. The user can navigate between the splash page and pages displaying a list of engineers and a list of machines, as well as details pages for the individual engineer or machine. The user can add to the list of engineers and list of machines, and specify which engineers are licensed to repair which machines, thanks to the many-to-many relationship between the two classes. An engineer can be licensed to repair many machines and a machine can have many engineers licensed to repair it.

## Setup/Installation Requirements

1. Click on the green “<> Code” on the far right-hand side of the page's main column.
2. On the “Local” tab of the mini-window that opens underneath the “<>Code” button, copy the HTTPS link in the gray bar to your clipboard.
3. In GitBash (or a terminal shell of your choice), navigate to the directory where you wish to download the project and enter the following prompt (replacing the asterisked word with the appropriate link): `git clone *url-of-the-repository-copied-in-the-previous-step*`
4. Your chosen directory will now contain a folder titled "w11-sillystringz-factory".
5. If you don't have the .Net Software Development Kit already installed on your computer, install it now. You may also wish to download the REPL (read-evaluate-print-loop) tool called dotnet-script. You can install the relevant tools introduced in [this series of lessons on LearnHowToProgram.com](https://old.learnhowtoprogram.com/c-and-net/getting-started-with-c).
6. If you skipped the previous step and/or don't have MySQL and MySQL Workbench installed, follow the instructions in the LearnHowToProgram.com lesson ["Creating a Test Database: Exporting and Importing Databases with MySQL Workbench"](https://full-time.learnhowtoprogram.com/c-and-net/database-basics/creating-a-test-database-exporting-and-importing-databases-with-mysql-workbench).
7. Navigate into the production directory "Factory" and create a new file called `appsettings.json`.
8. Within `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values (i.e. "[YOUR_USERNAME]" and "[YOUR_PASSWORD]") with your own username and password for MySQL and choosing a name for your database (i.e. replacing the "[DATABASE_NAME]" with your chosen name). 

```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[DATABASE_NAME];uid=[YOUR_USERNAME];pwd=[YOUR_PASSWORD];"
  }
}
```

9. To create your database, run the following command in your terminal: `dotnet ef database update`. You can check MySQL / MySQL Workbench to verify that the database has been created.
10. To build and run the web app on your local server, navigate to the Factory directory. In the command line of your terminal, enter the following command to compile and execute the application in a web browser with a watcher: `dotnet watch`. 
11. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).

## Known Bugs

No known bugs.

## License

MIT License

Copyright (c) 2023 Richard Barbour II

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.