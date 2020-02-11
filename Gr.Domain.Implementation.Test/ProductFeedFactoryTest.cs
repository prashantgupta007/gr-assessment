using System;
using Moq;
using NUnit.Framework;
using Gr.Data;
using Gr.Enums;
using Gr.Exceptions;

namespace Gr.Domain.Implementation.Test
{
    public class ProductFeedFactoryTest
    {
        private Mock<IServiceProvider> _serviceProviderMock;

        [SetUp]
        public void Setup()
        {
            _serviceProviderMock = new Mock<IServiceProvider>();
        }

        [Test]
        public void ServiceShouldNotBeNull_When_JSON_Argument_Supplied_For_JSONService_GetProductFeedFileTypeServiceTest()
        {
            ImportJSONProductFeedServiceMock();

            var productFeedService = ProductFeedFactory().GetProductFeedFileTypeService(ProductFeedType.JSON);

            Assert.IsNotNull(productFeedService);
            Assert.AreEqual(typeof(ImportProductFeedFromJSONService), productFeedService.GetType());
        }

        [Test]
        public void ServiceShouldBeNull_When_YAML_Argument_Supplied_For_JSONService_GetProductFeedFileTypeServiceTest()
        {
            ImportJSONProductFeedServiceMock();

            var productFeedService = ProductFeedFactory().GetProductFeedFileTypeService(ProductFeedType.YAML);

            Assert.IsNull(productFeedService);
        }

        [Test]
        public void ServiceShouldNotBeNull_When_YAML_Argument_Supplied_For_YAMLService_GetProductFeedFileTypeServiceTest()
        {
            ImportYAMLProductFeedServiceMock();

            var productFeedService = ProductFeedFactory().GetProductFeedFileTypeService(ProductFeedType.YAML);

            Assert.IsNotNull(productFeedService);
            Assert.AreEqual(typeof(ImportProductFeedFromYAMLService), productFeedService.GetType());
        }

        [Test]
        public void ServiceShouldBeNull_When_JSON_Argument_Supplied_For_YAMLService_GetProductFeedFileTypeServiceTest()
        {
            ImportYAMLProductFeedServiceMock();
            
            var productFeedService = ProductFeedFactory().GetProductFeedFileTypeService(ProductFeedType.JSON);

            Assert.IsNull(productFeedService);
        }

        [Test]
        public void ServiceShouldThrowException_When_CSV_Argument_Supplied_For_GetProductFeedFileTypeServiceTest()
        {
            Assert.AreEqual(Assert.Throws<InvalidProductFeedProcessingEngineException>(() =>
                            ProductFeedFactory().GetProductFeedFileTypeService(ProductFeedType.CSV)).Message, "CSV product feed service is not implemented");
        }

        private ProductFeedFactory ProductFeedFactory()
        {
            return new ProductFeedFactory(_serviceProviderMock.Object);
        }

        private void ImportJSONProductFeedServiceMock()
        {
            _serviceProviderMock.Setup(x => x.GetService(typeof(ImportProductFeedFromJSONService)))
                                 .Returns(new ImportProductFeedFromJSONService(ProductRepositoryMock()));
        }

        private void ImportYAMLProductFeedServiceMock()
        {
            _serviceProviderMock.Setup(x => x.GetService(typeof(ImportProductFeedFromYAMLService)))
                                 .Returns(new ImportProductFeedFromYAMLService(ProductRepositoryMock()));
        }

        private Func<SupportedDataBaseType, IProductRepository> ProductRepositoryMock()
        {
            Func<SupportedDataBaseType, IProductRepository> productRepositoryMock = dbType =>
            {
                var _productRepositoryMock = new Mock<IProductRepository>();
                return _productRepositoryMock.Object;
            };

            return productRepositoryMock;
        }
    }
}
