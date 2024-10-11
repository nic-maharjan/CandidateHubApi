

using static CandidateHubApi.Model.Candidates;

namespace CandidateHubApi.DbContext
{
	using Microsoft.EntityFrameworkCore;
	public class CandidateDbContext : DbContext
	{
		public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options) { }

		public DbSet<Candidate> Candidates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Candidate>()
				.HasKey(c => c.Email);
		}
	}
}
