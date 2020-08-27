using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ParabolicFunction.Models
{
    public static class SeeData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.UserDatas.Any() && !context.Points.Any()) /////////////////????
            {
                context.UserDatas.AddRange(
                    new UserData { A = 4, B = 15, C = 8},
                    new UserData { A = 2, B = 8, C = 3 },
                    new UserData { A = 8, B = 10, C = 6 }
                    );

                context.Points.AddRange(
                    new Point { ChartID = 1, PointX = 10, PointY = 3 });
            }
            //context.SaveChanges();
        }
    }
}
