using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Infra.Data.Constants;
using PlataformaRedencao.Infra.Identity.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
    public class ApplicationUserConfiguration
        : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("asp_net_users", Schemas.Auth);
        }
    }
}