using MediatR;
using Personal.Photography.Gallery.Application.Commands;
using Personal.Photography.Gallery.Application.CommandsHandler;
using Personal.Photography.Gallery.Application.Events;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.EFRepositories;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.DapperRepositories;
using Personal.Photography.Gallery.Data.Context;
using Personal.Photography.Gallery.Data.Repositories.EFRepositories;
using Personal.Photography.Gallery.Data.Repositories.DapperRepositories;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Personal.Photography.Gallery.Core.Communication.Mediator;
using Personal.Photography.Gallery.Core.Messages.CommonMessages.Notifications;
using Personal.Photography.Gallery.Application.EventsHandlers;
using Personal.Photography.Gallery.Domain.Interfaces.Queries;
using Personal.Photography.Gallery.Application.Queries;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.MongoDBRepositories;
using Personal.Photography.Gallery.Data.Repositories.MongoDBRepositories;
using Personal.Photography.Gallery.Domain.Interfaces.MongoDBServices;
using Personal.Photography.Gallery.Application.MongoDBServices;

namespace Personal.Photography.Gallery.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Mediator

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Repository
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientQueriesRepository, ClientQueriesRepository>();
            services.AddScoped<IProductMongoRepository, ProductMongoRepository>();
            services.AddScoped<IGalleryMongoRepository, GalleryMongoRepository>();
            services.AddScoped<IExhibitionsMongoRepository, ExhibitionsMongoRepository>();

            // MediatorHandler
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // CommandHandler
            services.AddScoped<IRequestHandler<RegisterClientCommand, ValidationResult>, ClientCommandHandler>();

            // Queries
            services.AddScoped<IClientQueries, ClientQueries>();

            //MongoDBServices
            services.AddScoped<IProductAppServices, ProductAppServices>();
            services.AddScoped<IGalleryAppServices, GalleryAppServices>();
            services.AddScoped<IExhibitionsAppServices, ExhibitionsAppServices>();

            //

            // Event
            services.AddScoped<INotificationHandler<RegisteredCustomerEvent>, ClientEventHandler>();

            // Context
            services.AddScoped<DataContext>();
        }
    }
}
