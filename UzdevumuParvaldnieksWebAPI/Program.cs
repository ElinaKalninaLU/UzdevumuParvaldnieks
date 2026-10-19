using System.Diagnostics;
using UzdevumuParvaldnieksKlases;
using UzdevumuParvaldnieksTestData;
using UzdevumuTestData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITestDataFactory, TestDataFactoryList>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Uzdevumi", (ITestDataFactory tdf) =>
{
    var testData = tdf.GetTestData();
    return testData;
    // Implementation for getting uzdevumi
});

app.MapGet("/Uzdevumi/{id}", (int id, ITestDataFactory tdf) =>
    tdf.GetTestDataItem(id)
        is Uzdevums uzd
            ? Results.Ok(uzd)
            : Results.NotFound());

app.MapDelete("/Uzdevumi/{id}", (int id, ITestDataFactory tdf) =>
{
    if (tdf.DeleteTestData(tdf.GetTestDataItem(id)))
        return Results.Ok();
    else return Results.NotFound();
});

app.MapPost("/Uzdevumi", (Uzdevums uzd, ITestDataFactory tdf) =>
{
    int _id = uzd.ID;
    if (tdf.AddTestData(uzd))
    {
        return Results.Created($"/Uzdevumi/{_id}", uzd);
    }
    else
    {
        return Results.BadRequest();
    }
});

app.MapPut("/Uzdevumi/{id}", (Uzdevums uzd, ITestDataFactory tdf) =>
{
    if (tdf.UpdateTestData(uzd))
        return Results.Ok();
    else return Results.NotFound();
});



app.Run();

