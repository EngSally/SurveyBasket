namespace SurveyBasket;

public   static class DependancyInjection
{
    public  static IServiceCollection  AddDependencies (this IServiceCollection services)
    {

        // Add services to the container.

        services.AddControllers();
        services.AddSwaggerService();
        
        return services;
    }

    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }



  }
