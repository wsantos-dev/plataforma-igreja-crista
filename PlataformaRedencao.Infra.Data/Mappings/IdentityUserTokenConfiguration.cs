using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Infra.Data.Constants;

namespace PlataformaRedencao.Infra.Data.Configurations.Identity;

public class IdentityUserTokenConfiguration 
    : IEntityTypeConfiguration<IdentityUserToken<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
    {
        builder.ToTable("asp_net_user_tokens", Schemas.Auth);
    }
}
