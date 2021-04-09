using Microsoft.EntityFrameworkCore;

namespace eShop.Api.Models
{
    [Owned]
    public class Privilege
    {
        public AccessRight AccessRight { get; init; }
        public string Aggregate { get; init; }

        public Privilege(AccessRight accessRight, string aggregate)
        {
            AccessRight = accessRight;
            Aggregate = aggregate;
        }

        public Privilege()
        {

        }
    }
}
