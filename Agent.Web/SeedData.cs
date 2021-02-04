using Agent.Core.Entities;
using Agent.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agent.Web
{
    public static class SeedData
    {
        private static List<Catalogue> GetCatalogues()
        {
            return new List<Catalogue>
            {
                new Catalogue {
                    Name = "Cyber Security"
                },
                new Catalogue {
                    Name = "Design Pattern"
                },
                new Catalogue {
                    Name = "ASP.NET Core"
                }
            };
        }

        private static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book {
                    Title = "Cyber Security Engineering",
                    Author = "Nancy R. Mead, Carol C. Woody",
                    Publisher = "Addison-Wesley",
                    Price = 46.99m,
                    CatalogueId = 1,
                    Image = "cyber_security_engineering.png"
                },
                new Book {
                    Title = "Computer Security Fundamentals",
                    Author = "Chuck Easttom",
                    Publisher = "Pearson",
                    Price = 30.18m,
                    CatalogueId = 1,
                    Image = "computer_security_fundamentals.png"
                },
                new Book {
                    Title = "Professional ASP.NET Design Patterns",
                    Author = "Scott Millett",
                    Publisher = "Wiley Publishing, Inc.",
                    Price = 15.00m,
                    CatalogueId = 2,
                    Image = "professional_asp_net_design_patterns.png"
                },
                new Book {
                    Title = ".NET Design Patterns",
                    Author = "Praseed Pai, Shine Xavier",
                    Publisher = "Packt Publishing",
                    Price = 20.00m,
                    CatalogueId = 2,
                    Image = "net_design_patterns.png"
                },
                new Book {
                    Title = "ASP.NET Core Application Development",
                    Author = "James Chambers, David Paquette, Simon Timms",
                    Publisher = "Microsoft Press",
                    Price = 80.00m,
                    CatalogueId = 3,
                    Image = "asp_net_core_application_development.png"
                },
                new Book {
                    Title = "Enterprise Application Architecture with .NET Core",
                    Author = "Ganesan Senthilvel, Ovais Mehboob Ahmed Khan, Habib Ahmed Qureshi",
                    Publisher = "Packt Publishing",
                    Price = 65.10m,
                    CatalogueId = 3,
                    Image = "enterprise_application_architecture_with_net_core.png"
                }
            };
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
            PopulateCatalogueData(dbContext);
            PopulateBookData(dbContext);
        }

        public static void PopulateCatalogueData(AppDbContext dbContext)
        {
            if (!dbContext.Catalogues.Any())
            {
                GetCatalogues().ForEach(c => dbContext.Catalogues.Add(c));
                dbContext.SaveChanges();
            }
        }

        public static void PopulateBookData(AppDbContext dbContext)
        {
            if (!dbContext.Books.Any())
            {
                GetBooks().ForEach(b => dbContext.Books.Add(b));
                dbContext.SaveChanges();
            }
        }
    }
}
