using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using System.Configuration;

namespace SportsStore.WebUI.Infrastructure {

    public class NinjectDependencyResolver : IDependencyResolver {
        /// <summary>
        /// 
        /// </summary>
        private IKernel kernel;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernelParam"></param>
        public NinjectDependencyResolver(IKernel kernelParam) {
            kernel = kernelParam;
            AddBindings();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }
        /// <summary>
        /// 
        /// </summary>
        private void AddBindings() {
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product> {
            //    new Product {Name="Football", Price=25 },
            //    new Product {Name="Surf board", Price=179 },
            //    new Product {Name="Running shoes", Price=95 },
            //});
            //kernel.Bind<IProductsRepository>().ToConstant(mock.Object);
            kernel.Bind<IProductsRepository>().To<EFProductRepository>();
            EmailSettings emailSettings = new EmailSettings {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Eamil.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
        }
    }
}
