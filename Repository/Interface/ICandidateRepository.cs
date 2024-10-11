using static CandidateHubApi.Model.Candidates;

namespace CandidateHubApi.Repository.Interface
{
	public interface ICandidateRepository
	{
		Task<Candidate> GetByEmailAsync(string email);
		Task AddOrUpdateAsync(Candidate candidate);
	}
}
