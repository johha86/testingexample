using Microsoft.EntityFrameworkCore;

namespace Contoso.Payment.API
{
    /// <summary>
    /// DbContext used by the service.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Entities.Payment> Payments { get; set; } = null!;
    }
}
