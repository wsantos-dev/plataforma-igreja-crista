using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Infra.Data.Constants;

namespace PlataformaRedencao.Infra.Data.Mappings
{
    public class IdentityUserRole
        : IEntityTypeConfiguration<IdentityUserRole>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole> builder)
        {
            builder.ToTable("asp_net_user_roles", Schemas.Auth);
        }
    }
}