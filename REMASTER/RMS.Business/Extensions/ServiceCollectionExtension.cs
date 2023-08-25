using Microsoft.Extensions.DependencyInjection;
using RMS.Business.İmplementations;
using RMS.Business.İnterfaces;
using RMS.DataAcsess.implementations.Repositories;
using RMS.DataAcsess.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {

         


           services.AddScoped<ICustomerBs, CustomerBs>();
           services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddAutoMapper(typeof(CustomerBs));


            services.AddScoped<IDealerBs, DealerBs>();
           services.AddScoped<IDealerRepository, DealerRepository>();

          

            services.AddScoped<IVehicleBs, VehicleBs>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            services.AddScoped<ITechnicianBs, TechnicianBs>();
            services.AddScoped<ITechnicianRepository, TechnicianRepository>();

            services.AddScoped<IServicePerformedBs, ServicePerformedBs>();
            services.AddScoped<IServicePerformedRepository, ServicePerformedRepository>();

            services.AddScoped<IServiceBs, ServiceBs>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            services.AddScoped<IPaymentBs, PaymentBs>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IOrderBs, OrderBs>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IIssueBs, IssueBs>();
            services.AddScoped<IIssueRepository, IssueRepository>();

            services.AddScoped<IInvoiceBs, InvoiceBs>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<IAdminPanelUserBs, AdminPanelUserBs>();
            services.AddScoped<IAdminPanelUserRepository, AdminPanelUserRepository>();
        }

    }
}
