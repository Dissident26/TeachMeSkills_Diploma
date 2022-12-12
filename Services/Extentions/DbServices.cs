using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataBase.Contexts;
using DataBase.Constants;
using Services.Interfaces;
using Services.DbServices;

namespace Services.Extentions
{
    public static class DbServices
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services)
        {
            services.AddDbContext<DbContextMain>(options =>
            {
                options.UseSqlServer(DbConstants.GetConnectionString());
            });

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPostServices, PostServices>();
            services.AddScoped<ITagServices, TagServices>();
            services.AddScoped<IPostTagServices, PostTagServices>();
            services.AddScoped<ICommentServices, CommentServices>();
            services.AddScoped<IAuthServices, AuthServices>();

            return services;
        }
    }
}
