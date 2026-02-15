using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Infra.Data.Constants;

namespace PlataformaRedencao.Infra.Data.Mappings
{
    public class IdentityUserClaimConfiguration
        : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.ToTable("asp_net_user_claims", Schemas.Auth);
        }
    }
}