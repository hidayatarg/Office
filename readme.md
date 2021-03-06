### Docker MSSQL Server
Download docker image for sql server and activate it
```docker
docker pull microsoft/mssql-server-linux
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=ProductApi(!)' -e 'MSSQL_PID=Express' -p 1433:1433 --name=catalogdb microsoft/mssql-server-linux
docker start catalogdb

```

### Docker Containers Tricks
-   to list or check active containers `docker ps`
-   to list all containers `docker ps -a`
-   to start a container `docker start CONTAINER_ID`

### Migration
It will create the database with name of mentioned in API `AppSetting.json`

`First Test Route: https://localhost:5001/api/Category/`

#### AutoMapper
NuGet Packages
- `AutoMapper.Extensions.Microsoft.DependencyInjection`
- `AutoMapper`


#### POST Category
Type JSON Raw Body
https://localhost:5001/api/Category
```json
{
    "Name":"CarKit"
}
```

### Best Practices
Try catch are not used in controller there will be a middleware class to catch the exceptions.

#### Action Filters 
We can change the the codes in the request pipline using filters. In the insert methods we expect the data to arrive for that we used if block to check if the incoming data is valid or not.

services.Configure<ApiBehaviorOptions>

we will change the behavior of the API and Return custom Errors.
