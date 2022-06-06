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

![fnapp](https://imgur.com/NLFFriE.jpeg)

---

Database commands:
```
CREATE TABLE customers (
	customer_id INT IDENTITY (1, 1) PRIMARY KEY,
	first_name VARCHAR (255) NOT NULL,
	last_name VARCHAR (255) NOT NULL,
	phone VARCHAR (25),
	email VARCHAR (255) NOT NULL,
	street VARCHAR (255),
	city VARCHAR (50),
	state VARCHAR (25),
	zip_code VARCHAR (5)
);
```
Dummy data in table:
```
INSERT INTO customers VALUES('Itachi','Uchiha','9876543210','itachi@gmail.com','eg street','konoha','eg state','00000');
```

---
#### Request & Response

SaveCustomerDetail:
![fnapp](https://imgur.com/UjrWrrZ.jpeg)

GetAllCustomers:
![fnapp](https://imgur.com/uwK5JQ3.jpeg)

UpdateCustomerDetails:
![fnapp](https://imgur.com/4hEBEP3.jpeg)
GetAllCustomers:
![fnapp](https://imgur.com/EZCvqhj.jpeg)

GetCustomerById:
![fnapp](https://imgur.com/aXWEs3d.jpeg)

RemoveCustomerById:
![fnapp](https://imgur.com/BSNeIUU.jpeg)
GetAllCustomers:
![fnapp](https://imgur.com/5tp1fXM.jpeg)

---
#### Stored Procedure support
Added SP call for GetAllCustomers in GetAllCustomersSP and  GetCustomerById in GetCustomerByIdSP. Request body will be same.
SP:
```
CREATE procedure [dbo].[getCustomersById]
(@id int)
as 
begin
	select * from customers where customer_id=@id
end
```
```
CREATE procedure [dbo].[getAllCustomers]
as 
begin
	select * from customers
end
```

---