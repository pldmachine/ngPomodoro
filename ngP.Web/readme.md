How to add new migration file with different startup project:

`
dotnet ef migrations add InitialCreate -p ../ngP.Data/ngP.Data.csproj -v
`

How to set current evironment as a development:

`
$Env:ASPNETCORE_ENVIRONMENT = "Development"
`

