using NumDecomp.Domain.Core.Interfaces.Services;
using NumDecomp.Domain.Services.Services;
using NumDecomp.Domain.Models;
using NumDecomp.App.DTO.DTO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IServiceDecomposition, ServiceDecomposition>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/v1/decomp/{entryNumber}", (int entryNumber, IServiceDecomposition serviceDecomp) =>
{
    Decomposition decomp = new Decomposition { EntryNumber = entryNumber };

    var result = serviceDecomp.GetDecomposition(decomp);

    if (result.DividingNumbers.Count > 0)
        return Results.Ok(result);

    return Results.Problem(result.Error);
}).Produces<DecompositionDTO>();

app.Run();