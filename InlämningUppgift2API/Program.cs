using InlämningUppgift2API.Core.Inteface;
using InlämningUppgift2API.Core.Services;
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
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();    
builder.Services.AddScoped<ICommentService, CommentService>();  
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => {endpoints.MapControllers();});



app.Run();
