# Foobar 

How to use Microsoft Entity Framework migrations in this project 
The documentation can be found at https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/

## Navigate to the correct folder

First, in the command line or powershell head to the ~/LogisticBooking.API/LogisticBooking.API

When in there, the dotnet entity commands can be entered 

## Commands to use 

When we need to update a model, we need to create a new migrations and update the database with the newly created migrations

to create a new migrations use the following commands 

I have created a system where i use the name initx.x for the current version
It can be seen in the following folder what version is being used - 
~/LogisticBooking.API/LogisticBooking.API/Migrations


```bash
 dotnet ef migrations add initx.x --context BackendDbContext initx.x // use the next version eg. 1.9  - 

```

Next we need to apply the migrations and update the database. 
Use the following command
Remeber to use the same name choosen above 
```Bash
dotnet ef database update initx.x --context BackendDbContext
```

