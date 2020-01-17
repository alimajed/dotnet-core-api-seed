# dotnet-core-api-seed
DotNetCoreApiSeed is a very simple a[[ that you can understand,use its structure and edit its content to satisfy your business logic and workflow.

DotNetCoreApiSeed app built dotnet core, entity framework core, postgres database.

It use dependency injection technique to respond to users requests.

It can be easly used and pluged in any solution or projects, and get connected with the frontend.

To use entity framework core, **dotnet ef** must be installed as a global or local tool, by typing the cmd "**_dotnet tool install --global dotnet-ef_**"

You use same migrations and to apply it run the cmd "**_dotnet ef database update_**" to update your existing DB, you can remove it and add new migration using cmd "**_dotnet ef migrations add InitialCreate_**", then apply the update cmd.

Not a big thing but it seems helpful if you want to build your app from scratch, and a good experience for me that I would like to share.
