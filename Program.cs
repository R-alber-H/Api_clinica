var builder = WebApplication.CreateBuilder(args);

// Registrar servicios y repositorios
builder.Services.AddSingleton<PacienteRepository>();
builder.Services.AddSingleton<IPacienteService, PacienteService>();

// Registrar otros servicios/repositories según tu proyecto
builder.Services.AddSingleton<MedicoRepository>();
builder.Services.AddSingleton<IMedicoService, MedicoService>();

builder.Services.AddSingleton<CitaRepository>();
builder.Services.AddSingleton<ICitasService, CitaService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();