using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlannerMVC;
using PlannerMVC.Data;

namespace PlannerMVC.Models
{
    public static class SeedData
        {
         public static void Initialize(IServiceProvider serviceProvider)
            {
             using (var context = new PlannerContext(
                    serviceProvider.GetRequiredService<
                        DbContextOptions<PlannerContext>>()))
                {



                if (context.Activity.Any())
                    {
                        return;   
                    }

                context.Activity.AddRange(
                    new Activity
                    {
                        ActivityName = "Gym",
                        ActivityDetails = "Flint Gym"

                    },
                    new Activity
                    {
                        ActivityName = "Work",
                        ActivityDetails = "9-5, 10 min commute"

                    },
                     new Activity
                     {
                         ActivityName = "Run",
                         ActivityDetails = "Nike Run Club"

                     },
                      new Activity
                      {
                          ActivityName = "Tidy House",

                      }
                    

                    );

                    context.SaveChanges();

                }
            }
        }
    }