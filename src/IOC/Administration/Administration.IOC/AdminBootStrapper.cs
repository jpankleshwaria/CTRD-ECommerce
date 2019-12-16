using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CTRD.ECommerce.Application.Interfaces;
using CTRD.ECommerce.Application.Queries;
using CTRD.ECommerce.Infrastructure.DbConnection;
using CTRD.ECommerce.Infrastructure.Interfaces;
using CTRD.ECommerce.Infrastructure.Repository;
using Administration.IOC.AutoMappers;
using Common.Domain.Behaviors;

namespace Administration.IOC
{
    public class AdminBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //AutoMapper Setup 
            services.AddAutoMapperSetup();
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());

            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IConnectionFactory), typeof(ConnectionFactory));

            //This registers all mediatr Query/Commands in the Assembly
            //So only below one line of code is required, do not add any other Query/Command file here
            services.AddMediatR(typeof(GetCspListDTOQuery).Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

        }
    }
}
