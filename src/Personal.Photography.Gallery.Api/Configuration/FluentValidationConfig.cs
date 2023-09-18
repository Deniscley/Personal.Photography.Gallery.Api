using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Personal.Photography.Gallery.Application.Commands;
using System.Text.Json.Serialization;
using static Personal.Photography.Gallery.Application.Commands.RegisterClientCommand;

namespace Personal.Photography.Gallery.Api.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(p =>
                {
                    p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddScoped<IValidator<RegisterClientCommand>, RegisterClientValidation>();
            //services.AddValidatorsFromAssemblyContaining<RegisterClientValidation>();
            services.AddFluentValidationRulesToSwagger();
        }
    }
}
