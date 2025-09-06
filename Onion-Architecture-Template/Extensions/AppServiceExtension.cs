using Microsoft.EntityFrameworkCore;
using OnionTemplate.Domain.Repositories;
using OnionTemplate.Domain.Specifications;
using OnionTemplate.Repo.Data;
using OnionTemplate.Repo.Repositories;

namespace Onion_Architecture_Template.Extensions
{
    public static class AppServiceExtension
    {
        public static async Task<IServiceCollection> AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));



            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(ISpecification<>), typeof(BaseSpecification<>));





            return services;

        }
    }
}

