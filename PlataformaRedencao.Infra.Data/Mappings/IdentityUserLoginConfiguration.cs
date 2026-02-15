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
    public class IdentityUserLoginConfiguration
        : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.ToTable("asp_net_user_logins", Schemas.Auth);
        }
    }
}