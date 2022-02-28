<p align="center">
  A Template for Developing Azure Function
</p>
  
---

## About The Project
<br/>
A 3-layered architecture template for developing http triggered azure function connected to MSSQL using Entity Framework
<br/>

---

## Getting Started
If you want to run it locally on your system you will need following application installed:<br/>
- Visual Studio<br/>
- MSSQL<br/>

Now Clone the repository
```sh
git clone https://github.com/UlbertAO/FnApp
```
Open the project in Visual Studio.

Right click on `Master.Microservice` and select `Set As Startup Project`.

![fnapp](https://imgur.com/mfCZKzk.jpeg)

You should configure a `local.settings.json` file to hold the Configuration Manager values for `ConnectionString` within the Functions project. 

`local.settings.json` should contain the following correctly configured values:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "ConnectionString": "Your Connection String Here",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  }
}
```

For Example:
```json
"ConnectionString": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=fnappdb;Integrated Security=true;"
```


![fnapp](https://imgur.com/FBAdACt.jpeg)

NOW BUILD AND RUN
