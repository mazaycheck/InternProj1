using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data.Configurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasData(
                new Town() { TownId = 1, Title = "Chisinau", CoordX = 199, CoordY = 250 },
                new Town() { TownId = 2, Title = "Balti", CoordX = 250, CoordY = 300 },
                new Town() { TownId = 3, Title = "Cahul", CoordX = 100, CoordY = 115 }
            );

        }
    }
}
