using CandidateHubApi.DbContext;
using CandidateHubApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using static CandidateHubApi.Model.Candidates;

namespace CandidateHubApi.Repository
{
	public class CandidateRepository : ICandidateRepository
	{
		private readonly CandidateDbContext _context;

		public CandidateRepository(CandidateDbContext context)
		{
			_context = context;
		}

		public async Task<Candidate> GetByEmailAsync(string email)
		{
			return await _context.Candidates.FirstOrDefaultAsync(c => c.Email == email);
		}

		public async Task AddOrUpdateAsync(Candidate candidate)
		{
			var existingCandidate = await GetByEmailAsync(candidate.Email);
			if (existingCandidate != null)
			{
				existingCandidate.FirstName = candidate.FirstName;
				existingCandidate.LastName = candidate.LastName;
				existingCandidate.PhoneNumber = candidate.PhoneNumber;
				existingCandidate.CallTimeInterval = candidate.CallTimeInterval;
				existingCandidate.LinkedInProfileUrl = candidate.LinkedInProfileUrl;
				existingCandidate.GitHubProfileUrl = candidate.GitHubProfileUrl;
				existingCandidate.Comment = candidate.Comment;

				_context.Candidates.Update(existingCandidate);
			}
			else
			{
				await _context.Candidates.AddAsync(candidate);
			}
			await _context.SaveChangesAsync();
		}
	}

}
