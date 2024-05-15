INSTRUCTIONS for Running the Web Api service
Open project solution with Visual Studio 2019

Attach the MDF DB file provided embedded in the solution items folder with SQL Server Express 2019 LocalDB (recomended SQL Management Studio 2018) (Application on sturtup created a text file first time it starts with connection string to localDB, if fails you can play/change the connection string of the file in solution folder to connect it to other DB)

Run it with IIS Express

Run Unit tests and integration tests and check all tests are in green

Test the API with the following CURL commands , or swagger(application startup) or either postman :