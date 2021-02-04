using Agent.Core;
using Agent.Core.Interfaces;
using Agent.Infrastructure.Data;
using Agent.Infrastructure.Services;
using Agent.SharedKernel.Interfaces;
using Autofac;
using OnePay.PaymentApi;
using OnePay.TransactionApi;
using System.Collections.Generic;
using System.Reflection;
using Module = Autofac.Module;

namespace Agent.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private bool _isDevelopment = false;
        private List<Assembly> _assemblies = new List<Assembly>();

        public DefaultInfrastructureModule(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;

            var coreAssembly = Assembly.GetAssembly(typeof(CoreAssembly));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(InfrastructureAssembly));
            var paymentApiAssembly = Assembly.GetAssembly(typeof(PaymentApiAssembly));
            var transactionApiAssembly = Assembly.GetAssembly(typeof(TransactionApiAssembly));

            _assemblies.Add(coreAssembly);
            _assemblies.Add(infrastructureAssembly);
            _assemblies.Add(paymentApiAssembly);
            _assemblies.Add(transactionApiAssembly);


            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<CatalogueService>().As<ICatalogueService>().InstancePerDependency();
            builder.RegisterType<BookService>().As<IBookService>().InstancePerDependency();

            // OnePay Services
            builder.RegisterType<PaymentService>().As<IPaymentService>().InstancePerDependency();
            builder.RegisterType<TransactionService>().As<ITransactionService>().InstancePerDependency();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add development only services
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add production only services
        }
    }
}
