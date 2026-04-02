using MarketingCampaignAPI.Application.Services;
using MarketingRESTAPI.Application.Interfaces;
using MarketingRESTAPI.Infraestructure.FileReaders;
using MarketingRESTAPI.Infraestructure.Generators;
using MarketingRESTAPI.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dependencies
builder.Services.AddSingleton<IExcelReader, ExcelReader>();
builder.Services.AddSingleton<ILeadRepository, LeadRepository>();
builder.Services.AddSingleton<ISectorRepository, SectorRepository>();
builder.Services.AddScoped<IMailingService, MailingService>();
builder.Services.AddScoped<IEmailTemplateGenerator, EmailTemplateGenerator>();
builder.Services.AddScoped<IDossierService, DossierService>();
builder.Services.AddScoped<IPdfGenerator, PdfGenerator>();

QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
