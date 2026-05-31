var builder = WebApplication.CreateBuilder(args);

// Регистрируем контроллеры и Swagger (удобно для проверки API в браузере)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger включаем всегда, чтобы на зачёте можно было открыть /swagger и показать API
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
