using System;
using System.Collections.Generic;
using System.IO;
using Gr.Data;
using Gr.Enums;
using Gr.Model;

namespace Gr.Domain.Implementation
{
    public class ImportProductFeedFromYAMLService : IImportProductFeedService
    {
        private readonly IProductRepository _productRepository;
        private readonly string _fileSource;
        public ImportProductFeedFromYAMLService(Func<SupportedDataBaseType, IProductRepository> productRepository)
        {
            //// SupportedDataBaseType should have taken from configuration file as Current Database Type
            _productRepository = productRepository(SupportedDataBaseType.MySql) ?? throw new ArgumentNullException(nameof(IProductRepository));

            //// File path should be taken from Configuration
            _fileSource = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\feed-products\capterra.yaml"));
        }

        public bool ValidateSource()
        {
            var result = false;
            if (File.Exists(_fileSource))
            {
                result = true;
            }
            return result;
        }

        public bool ValidateContent()
        {
            //There are many ways to validate YAML, one can convert YAML to JSON and then see the reference of ImportProductFeedFromJSONService.ValidateContent
            // Or by using third party libraries or by creating custom parser
            return true;
        }

        public IEnumerable<Product> ParseContent()
        {
            return new List<Product>();
        }

        public void SaveContent(IEnumerable<Product> products)
        {
            return;
        }
    }
}
