# Socium
[![Coverage Status](https://coveralls.io/repos/github/David-Mavrodiev/Socium/badge.svg?branch=master)](https://coveralls.io/github/David-Mavrodiev/Socium?branch=master)
[![Build status](https://ci.appveyor.com/api/projects/status/k3542jl2xomtp03i?svg=true)](https://ci.appveyor.com/project/David-Mavrodiev/socium)

## Screenshots

![Alt text](/Screenshots/HomePage.png?raw=true "Home Page")
![Alt text](/Screenshots/AccountPage.png?raw=true "Account Page")
![Alt text](/Screenshots/CreateQuestionPage.png?raw=true "Create Question Page")
![Alt text](/Screenshots/AllQuestionsPage.png?raw=true "All Questions Page")
![Alt text](/Screenshots/AdminHomePage.png?raw=true "Admin Home Page")
![Alt text](/Screenshots/AdminQuestionsPage.png?raw=true "Admin Questions Page")
![Alt text](/Screenshots/AdminUsersPage.png?raw=true "Admin Users Page")
![Alt text](/Screenshots/AllOptionsPage.png?raw=true "Admin Options Page")
![Alt text](/Screenshots/AllVotesPage.png?raw=true "Admin Votes Page")
![Alt text](/Screenshots/DetailQuestionPage.png?raw=true "Detail Question Page")



## General Requirements

Your Web application should use the following technologies, frameworks and development techniques:
* Use **ASP.NET MVC** and **Visual Studio 2015** +
* You should use **Razor** template engine for generating the UI +
	* Use **sections** and **partial views** +
	* Use **editor** and/or **display** templates +
* Use **MS SQL Server** as database back-end +
	* Use **Entity Framework 6** to access your database +
	* Using **repositories and/or service layer** is a must +
* Use at least **2 areas** in your project (e.g. for administration) +
* Create **tables with data** with **server-side paging and sorting** for every model entity +

* Create **beautiful and responsive UI** +

* Use the standard **ASP.NET Identity System** for managing users and roles +
	* Your registered users should have at least one of the two roles: **user** and **administrator** +
* Use **AJAX form and/or SignalR** communication in some parts of your application +
* Use **caching** of data where it makes sense (e.g. starting page) +
* Apply **error handling** and **data validation** to avoid crashes when invalid data is entered (both client-side and server-side)+
* Prevent yourself from **security** holes (XSS, XSRF, Parameter Tampering, etc.) +
	* Handle correctly the **special HTML characters** and tags like `<script>`, `<br />`, etc. +
* Create **unit tests** for your "business" functionality following the best practices for writing unit tests (**at least 80% code coverage**) - **~30% of the points for the project** (**IF YOU HAVE UNDER 50% CODE COVERAGE YOU WILL NOT PASS THE EXAM**)+
* Use **Dependency Inversion** principle and **Dependency Injection** technique following the best practices - **~20% of the points for the project** +
* Integrate your app with a **Continuous Integration server** (Jenkins, AppVeyor or other) - configure your unit tests to run on each commit to your master branch (**MANDATORY REQUIREMENT**) +
* Use GitHub and take advantage of the **branches** for writing your features. +
* **Documentation** of the project and project architecture (as `.md` file, including screenshots)+