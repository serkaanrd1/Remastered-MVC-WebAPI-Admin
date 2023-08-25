using System.Text.Json.Serialization;

namespace RMS.WebAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddAPIServices(this IServiceCollection services)
        {

            services.AddControllers()
                    .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();



        }

    }
}
