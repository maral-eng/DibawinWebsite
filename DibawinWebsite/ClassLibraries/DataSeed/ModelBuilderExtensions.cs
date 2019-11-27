using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using DibawinWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DibawinWebsite.ClassLibraries.DataSeed
{

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = 1,
                    LatinName = "Rial",
                    Name = "ریال",
                    Status = true,
                    Symbol = "ريال"
                },
                new Currency
                {
                    Id = 2,
                    LatinName = "Toman",
                    Name = "تومان",
                    Status = true,
                    Symbol = "تومان"
                },
                new Currency
                {
                    Id = 3,
                    LatinName = "Dollar",
                    Name = "دلار",
                    Status = true,
                    Symbol = "$"
                },
                new Currency
                {
                    Id = 4,
                    LatinName = "Euro",
                    Name = "یورو",
                    Status = true,
                    Symbol = "€"
                },
                new Currency
                {
                    Id = 5,
                    LatinName = "Yuan",
                    Name = "یوان",
                    Status = true,
                    Symbol = "¥"
                }
            );
            modelBuilder.Entity<Skills>().HasData(
                new Skills
                {
                    Id = 1,
                    Title = "ASP.Net Core",
                    LatinTitle = "ASP.Net Core"
                },
                new Skills
                {
                    Id = 2,
                    Title = "C#",
                    LatinTitle = "C#"
                },
                new Skills
                {
                    Id = 3,
                    Title = "HTML5",
                    LatinTitle = "HTML5"
                },
                 new Skills
                 {
                     Id = 4,
                     Title = "CSS3",
                     LatinTitle = "CSS3"
                 },
                  new Skills
                  {
                      Id = 5,
                      Title = "JavaScript",
                      LatinTitle = "JavaScript"
                  },
                   new Skills
                   {
                       Id = 6,
                       Title = "JQuery",
                       LatinTitle = "JQuery"
                   },
                    new Skills
                    {
                        Id = 7,
                        Title = "MVC",
                        LatinTitle = "MVC"
                    },
                    new Skills
                    {
                        Id = 8,
                        Title = "React Js",
                        LatinTitle = "React Js"
                    },
                    new Skills
                    {
                        Id = 9,
                        Title = "Angular",
                        LatinTitle = "Angular"
                    },
                    new Skills
                    {
                        Id = 10,
                        Title = "UI",
                        LatinTitle = "UI"
                    },
                    new Skills
                    {
                        Id = 11,
                        Title = "UX",
                        LatinTitle = "UX"
                    },
                    new Skills
                    {
                        Id = 12,
                        Title = "MS SQL Server",
                        LatinTitle = "MS SQL Server"
                    },
                    new Skills
                    {
                        Id = 13,
                        Title = "Python",
                        LatinTitle = "Python"
                    }
            );
            modelBuilder.Entity<JobsTitle>().HasData(
                new JobsTitle
                {
                    Id = 1,
                    Title = "برنامه نویس بک اند",
                    LatinTitle = "Back-End developer"
                },
                new JobsTitle
                {
                    Id = 2,
                    Title = "برنامه نویس فرانت اند",
                    LatinTitle = "Front-End developer"
                },
                new JobsTitle
                {
                    Id = 3,
                    Title = "برنامه نویس فول استک",
                    LatinTitle = "Full-Stack developer"
                },
                new JobsTitle
                {
                    Id = 4,
                    Title = "پشتیبان نرم افزار",
                    LatinTitle = "System Support"
                },
                new JobsTitle
                {
                    Id = 5,
                    Title = "مهندس نرم افزار",
                    LatinTitle = "Software Engineer"
                },
                new JobsTitle
                {
                    Id = 6,
                    Title = "برنامه نویس ارشد",
                    LatinTitle = "Senior developer"
                },
                new JobsTitle
                {
                    Id = 7,
                    Title = "برنامه نویس مبتدی",
                    LatinTitle = "Junior developer"
                },
                new JobsTitle
                {
                    Id = 8,
                    Title = "برنامه نویس میان سطح",
                    LatinTitle = "Mid-Level developer"
                }
            );
        }

    }

}
