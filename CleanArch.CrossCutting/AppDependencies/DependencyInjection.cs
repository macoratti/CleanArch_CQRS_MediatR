using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.CrossCutting.AppDependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
                  this IServiceCollection services,
                  IConfiguration configuration)
    {
        var mySqlConnection = configuration
                              .GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
                         options.UseMySql(mySqlConnection,
                         ServerVersion.AutoDetect(mySqlConnection)));

        services.AddScoped<IMemberRepository,MemberRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var myhandlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

        return services;
    }
}
