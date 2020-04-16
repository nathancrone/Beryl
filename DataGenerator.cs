using System;
using Microsoft.Extensions.DependencyInjection;
using Beryl.Data;
using Beryl.Models;
using Microsoft.EntityFrameworkCore;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var inMemoryDbContext = serviceProvider.GetRequiredService<BerylInMemoryContext>())
        using (var sqliteDbContext = serviceProvider.GetRequiredService<BerylSqliteContext>())
        {
            // delete all existing redirect rows
            foreach (var r in inMemoryDbContext.Redirects)
            {
                inMemoryDbContext.Redirects.Remove(r);
            }
            inMemoryDbContext.SaveChanges();

            // copy all redirect rows from sqlite to in-memory
            foreach (var r in sqliteDbContext.Redirects)
            {
                inMemoryDbContext.Redirects.Add(new Redirect() { RedirectId = r.RedirectId, Url = r.Url });
            }
            inMemoryDbContext.SaveChanges();
        }
    }
}