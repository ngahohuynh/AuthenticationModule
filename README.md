# Authentication Module 
Authentication Module with .NET Core and Angular

## API commands
Open `AuthenticationModule/appsettings.json` file and paste your connection string in `<CONNECTION_STRING>`
#### _Create migration_
CD to your solution directory
```sh 
dotnet ef migrations add <name> -s AuthenticationModule -p DataAccess 
```
#### _Update database_
CD to your solution directory
```sh 
dotnet ef database update  -s AuthenticationModule -p DataAccess 
```
#### _Build the app in Release mode_
CD to your solution directory
```sh
dotnet build -c Release
```
Or
```sh
dotnet build -c Release -o <Your output directory>
```
#### _Run the app from builded folder_
CD to the build folder
```sh
dotnet AuthenticationModule.dll
```

## Frontend commands
#### _Run the application (With proxy)_
CD to the ClientApp folder
```sh
npm run start
```

Visit the website on your browser at `http://localhost:4200/`
