using System;
using Microsoft.Extensions.DependencyInjection;
using Gr.Data;
using MySqlDb = Gr.Data.MySql;
using MongoDb = Gr.Data.MongoDB;
using Gr.Enums;
using Gr.Domain;
using Gr.Domain.Implementation;

namespace GrAssignment
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += CatchUnhandledException;

            UnityRegistration();

            ProductFeedParsing();

            DisposeUnityRegistration();
        }

        static void CatchUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("\n*****Exception Occured:*****");
            Console.WriteLine($"{e.ExceptionObject.ToString()}");
            Console.WriteLine("\nPress any key to EXIT");
            Console.ReadKey();
            Environment.Exit(0);
        }
        private static void ProductFeedParsing()
        {
            ChooseFeedType:
                Console.Write("** Below are available product feed types which can be parsed **\n  Type 1 for JSON \n  Type 2 for YAML \n  Type E to EXIT" +
                                    "\n\nPlease choose the feed type to be parsed: ");

                var userChoice = Console.ReadLine();

                if (userChoice.ToLower() == "e")
                {
                    Console.Write("You have been exited successfully!!");
                    Environment.Exit(0);
                }

                if (!int.TryParse(userChoice, out int productFeedType))
                {
                    Console.WriteLine($"\nChoosen product feed type is not available.\n\n");
                    goto ChooseFeedType;
                }

                if (Enum.IsDefined(typeof(ProductFeedType), productFeedType))
                {
                    var productFeedEngine = _serviceProvider.GetService<IProductFeedProcessingEngine>();
                    productFeedEngine.ImportProductFeed((ProductFeedType)productFeedType);
                }
                else
                {
                    Console.WriteLine($"\nProduct feed type productFeedType is not available.\n\n");
                }
                goto ChooseFeedType;
        }

        private static void UnityRegistration()
        {
            var services = new ServiceCollection();

            services.AddScoped<IProductFeedProcessingEngine, ProductFeedProcessingEngine>();
            services.AddScoped<IProductFeedFactory, ProductFeedFactory>();
            services.AddScoped<ImportProductFeedFromJSONService>();
            services.AddScoped<ImportProductFeedFromYAMLService>();

            services.AddScoped<MySqlDb.ProductRepository>();
            services.AddScoped<MongoDb.ProductRepository>();
            services.AddTransient<Func<SupportedDataBaseType, IProductRepository>>(
                serviceProvider => currentDBType =>
            {
                switch (currentDBType)
                {
                    case SupportedDataBaseType.MySql:
                        return serviceProvider.GetService<MySqlDb.ProductRepository>();
                    case SupportedDataBaseType.MongoDB:
                        return serviceProvider.GetService<MongoDb.ProductRepository>();
                    default:
                        Console.Write($"Doesn't support {currentDBType} type Product repository");
                        throw new Exception($"Doesn't support {currentDBType} type Product repository");
                }
            });

            services.AddScoped<MySqlDb.CategoryRepository>();
            services.AddScoped<MySqlDb.CategoryRepository>();
            services.AddTransient<Func<SupportedDataBaseType, ICategoryRepository>>(
                serviceProvider => currentDBType =>
                {
                    switch (currentDBType)
                    {
                        case SupportedDataBaseType.MySql:
                            return serviceProvider.GetService<MySqlDb.CategoryRepository>();
                        case SupportedDataBaseType.MongoDB:
                            return serviceProvider.GetService<MongoDb.CategoryRepository>();
                        default:
                            Console.Write($"Doesn't support {currentDBType} type Category repository");
                            throw new Exception($"Doesn't support {currentDBType} type Category repository");
                    }
                });

            _serviceProvider = services.BuildServiceProvider();
        }

        private static void DisposeUnityRegistration()
        {
            if (_serviceProvider != null && _serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
