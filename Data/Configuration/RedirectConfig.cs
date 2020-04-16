using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Beryl.Models;

namespace Beryl.Data.Configuration
{
    internal class RedirectConfig : IEntityTypeConfiguration<Redirect>
    {
        public void Configure(EntityTypeBuilder<Redirect> builder)
        {
            builder.HasKey(x => x.RedirectId);

            builder.HasData(
                new Redirect
                {
                    RedirectId = 1,
                    Url = "http://www.google.com"
                },
                new Redirect
                {
                    RedirectId = 2,
                    Url = "http://www.amazon.com"
                }
            );
        }
    }
}