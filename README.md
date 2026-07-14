# Interview Question 02

## Prerequisites

Before running the application, make sure you have installed:

Backend API ->
* .NET SDK 8.0.422 (version required by this project)
* SQL Server
* Visual Studio Code


---

## Database Setup

1. Open SQL Server Management Studio (SSMS).
2. Navigate to the **Database** folder.
3. Execute the SQL script to create the database.

Example:

```sql
CreateDatabase.txt
```

4. Verify that the database has been created successfully.

---

---

## Installation

Clone the repository:

```bash
git clone https://github.com/Rawee-Srisuwanpat/interview-question-02.git
cd interview-question-02/LoginApi
```


---

## Configure Connection String Backend API

Open the `appsettings.json` file and update the connection string to match your SQL Server instance.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## Run the Application Backend API

Restore NuGet packages:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

---

## API Testing

After the application starts, open:

```
https://localhost:<port>/swagger
```

Use the Swagger UI to test the available APIs.

---

## Project Structure

```
InterviewQuestion02
│
├── Database
│   └── CreateDatabase.sql
│
├── Controllers
├── Models
├── Services
├── Repositories
├── appsettings.json
└── Program.cs
```

---



## Notes

* Run the database creation script **before** starting the application.
* Make sure the connection string points to the correct SQL Server instance.
* If you modify the database name, update the connection string accordingly.



# Interview Question 02 - Frontend

## Prerequisites

Before running this project, ensure the following software is installed:

* Frontend ->
* node.js 24.18.0 (version required by this project)
* npm 11.16.0
* Angular Cli 22.0.6

Install Angular CLI globally:

```bash
npm install -g @angular/cli
```

Verify the installation:

```bash
node -v
npm -v
ng version
```

---

## Installation

Clone the repository:

```bash
git clone https://github.com/Rawee-Srisuwanpat/interview-question-02.git
cd interview-question-02/login-proj
```

Install project dependencies:

```bash
npm install
```

---

## Environment Configuration

Open the `src/environments` folder and configure the API URL.

Example:

```typescript
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5236/api'
};
```

---

## Run the Project

Start the development server:

```bash
ng serve
```



Open your browser and navigate to:

```text
http://localhost:4200
```

---

## Build

Create a production build:

```bash
ng build
```

The build output will be generated in the `dist/` folder.

---

## Project Structure

```text
src/
├── app/
├── assets/
├── environments/
│   ├── environment.ts
│   └── environment.prod.ts
├── styles.css
└── main.ts
```

---

## Notes

* Ensure the backend API is running before starting the frontend.
* Update the API URL in the environment configuration if necessary.
* Run `npm install` whenever dependencies change.
  
