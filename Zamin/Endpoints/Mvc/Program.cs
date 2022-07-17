using Microsoft.EntityFrameworkCore;
using SampleApp.Infra.Data.Commands;
using SampleApp.Infra.Data.Queries;
using Zamin.EndPoints.Web;
using Zamin.EndPoints.Web.StartupExtentions;
using Zamin.Utilities.Configurations;

var builder = new ZaminProgram().Main(args, "appsettings.json", "appsettings.zamin.json", "appsettings.serilog.json");

//Configuration
ConfigurationManager Configuration = builder.Configuration;
builder.Services.AddZaminApiServices(Configuration);

var dbPathOption = GetDbPathOption();
builder.Services.AddDbContext<SampleAppQueryDbContext>(dbPathOption);
builder.Services.AddDbContext<SampleAppCommandDbContext>(dbPathOption);

//Middlewares
var app = builder.Build();
var zaminOptions = app.Services.GetRequiredService<ZaminConfigurationOptions>();

app.UseZaminApiConfigure(zaminOptions, app.Environment);

app.Run();

static Action<DbContextOptionsBuilder> GetDbPathOption()
{
    string startupPath = Environment.CurrentDirectory;
    var dbPath = Path.Join(startupPath, "SampleAppDatabase.sqlite");

    //var projectPath = Directory.GetParent(startupPath).Parent.Parent.FullName;

    return c => c.UseSqlite($"Data Source= {dbPath}");
}