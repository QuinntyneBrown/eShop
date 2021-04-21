using eShop.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Api.Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(x => x.Privileges)
                            .WithMany(x => x.Roles)
                            .UsingEntity<RolePrivilege>(
                                x => x.HasOne(x => x.Privilege)
                                .WithMany().HasForeignKey(x => x.PrivilegeId),
                                x => x.HasOne(x => x.Role)
                               .WithMany().HasForeignKey(x => x.RoleId));

        }

    }
}
