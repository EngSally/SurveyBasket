﻿using Mapster;
using MapsterMapper;
using SurveyBasket.Presistance;
using SurveyBasket.Services;

namespace SurveyBasket;

public   static class DependancyInjection
{
    public  static IServiceCollection  AddDependencies (this IServiceCollection services ,IConfiguration config)
    {

        // Add services to the container.
        var connectionString=config.GetConnectionString("DefaultConnection")   ??
             throw   new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        services.AddControllers();
        services.AddSwaggerService();
        services.AddScoped<IPollService, PollService>();
        services.AddMapsterConf();

        return services;
    }

    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
    public static IServiceCollection AddMapsterConf(this IServiceCollection services)
    {
        var mappingConfig = TypeAdapterConfig.GlobalSettings;
        mappingConfig.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMapper>(new Mapper(mappingConfig));

        return services;
    }



}
