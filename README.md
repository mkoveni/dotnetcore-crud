This is a simple crud application built with dotnet core 2.0.0 and entity framework.
Please make sure that you have installed sqlserver for this project to work correctly. You have to modify the connection string within the app.settings.Development.json file. you can get the app and and running using the following commands.

git clone https://github.com/mkoveni/dotnetcore-crud.git
cd dotnetcore-crud
npm install
dotnet restore

After you have modified the app.settings.Development.json file, then you run migrations using the following command

dotnet ef database update
