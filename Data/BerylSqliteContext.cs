using System;
using Microsoft.EntityFrameworkCore;
using Beryl.Models;
using Beryl.Data.Configuration;

namespace Beryl.Data
{
    public class BerylSqliteContext : BerylDbContext
    {
        public BerylSqliteContext(DbContextOptions<BerylSqliteContext> options) : base(options) { }
    }
}
