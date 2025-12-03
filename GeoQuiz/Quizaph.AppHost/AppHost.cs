var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddPostgres("PostgresServer");

var sqlDatabase = sqlServer.AddDatabase("QuizaphDatabase");

var backend = builder.AddProject<Projects.QuizaphBackend>("quizaphbackend")
    .WithReference(sqlDatabase)
    .WithExternalHttpEndpoints()
    .WaitFor(sqlDatabase);

builder.AddProject<Projects.QuizaphFrontend>("quizaphfrontend")
    .WithReference(backend);

builder.Build().Run();
