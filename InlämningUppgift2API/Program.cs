using InlämningUppgift2API.Data;
using InlämningUppgift2API.Data.interfaces;
using InlämningUppgift2API.Data.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IPostRepo, PostRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => {endpoints.MapControllers();});



app.Run();
