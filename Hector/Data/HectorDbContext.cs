using Microsoft.EntityFrameworkCore;
using Hector.Models.DTOs;

namespace Hector.Data
{
    public class HectorDbContext : DbContext
    {
        public HectorDbContext(DbContextOptions<HectorDbContext> options) : base(options)
        { }

        public DbSet<JobDTO> Jobs { get; set; }
        public DbSet<ParticipantDTO> Participants { get; set; }

    }
}
