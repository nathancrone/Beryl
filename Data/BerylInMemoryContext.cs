using System;
using Microsoft.EntityFrameworkCore;
using Beryl.Models;
using Beryl.Data.Configuration;

namespace Beryl.Data
{
    public class BerylInMemoryContext : BerylDbContext
    {
        public BerylInMemoryContext(DbContextOptions<BerylInMemoryContext> options) : base(options) { }
    }
}
