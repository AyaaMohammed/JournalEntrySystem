# ً Journal Entry System

A simple **ASP.NET + AngularJS** application for managing **daily
journal entries** with **Header & Details**, account linking,
validations, and SQL Server storage.

”— Repo: `AyaaMohammed/JournalEntrySystem`

------------------------------------------------------------------------

## ً Features

-   **Clean Architecture** (Apis, Core, Data, Infrastructure, Service).\
-   **Entity Framework (Database First)** with **SQL Server**.\
-   **CQRS + Mediator** for structured request/response handling.\
-   **Repository Pattern** for data access.\
-   **Fluent Validation** for request validation.\
-   **Quartz** for PDF generation and scheduling.\
-   **Middleware** for error handling and custom response wrapping.\
-   **Business Logic Layer** with proper separation of concerns.\
-   **Dependency Injection**.\
-   **CORS enabled** to allow AngularJS frontend connection.\
-   **Custom API Routing**.\
-   **AngularJS Frontend** with controllers, services, views, and form
    validations.\
-   **Connection String:** `fCarePlus`

------------------------------------------------------------------------

## ً Journal Entry Requirements

1.  **Journal Entry Header**
    -   Required fields must be filled before saving.\
    -   Includes entry number, description, and date.
2.  **Journal Entry Details**
    -   Debit or Credit must be entered (mutually exclusive).\
    -   If debit value is entered â†’ credit becomes 0 automatically.\
    -   Must include account (ID & Name).
3.  **Account Auto-Complete**
    -   Auto-suggest account name & number when entering details.\
    -   Save account reference in database (Account_ID).
4.  **Automatic Balances**
    -   Show totals of debit/credit dynamically.\
    -   Show the difference between them (must equal 0 to allow saving).
5.  **Validation Rules**
    -   Cannot save if **Debit â‰  Credit**.\
    -   Cannot save without required fields.
6.  **Row Management**
    -   Ability to add multiple rows (e.g., 5 rows with one button).\
    -   Ability to delete rows with confirmation message.
7.  **Local Storage**
    -   Save unsaved data temporarily in browser local storage to
        prevent data loss.
8.  **Final Save**
    -   Ensure valid data (with all required fields) is stored securely
        in database.

------------------------------------------------------------------------

## ً Tech Stack

-   **Backend:** ASP.NET Core Web API\
-   **Frontend:** AngularJS + Live Server\
-   **Database:** SQL Server (`fCarePlus`)\
-   **ORM:** Entity Framework (Database First)\
-   **Patterns:** Repository, CQRS + Mediator\
-   **Validation:** FluentValidation\
-   **Reports:** Quartz + PDF Generation

------------------------------------------------------------------------

## ً How to Run

### Backend (ASP.NET API)

1.  Update `appsettings.json` with correct SQL Server connection string
    (`fCarePlus`).\
2.  Run API project â†’ Swagger/Router will expose endpoints.

### Frontend (AngularJS)

1.  Open AngularJS project in VS Code.\
2.  Run using **Live Server** extension.\
3.  Application will connect to API (CORS enabled).

-------------------------------------

Author: **Aya Mohammed**
