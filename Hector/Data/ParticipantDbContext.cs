using Microsoft.EntityFrameworkCore;
using Hector.Models;

namespace Hector.Data
{
    public class ParticipantDbContext : DbContext
    {
        public ParticipantDbContext(DbContextOptions<ParticipantDbContext> options) : base(options)
        { }

        public DbSet<Participant> Participants { get; set; }
    }
}
