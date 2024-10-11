using CandidateHubApi.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static CandidateHubApi.Model.Candidates;

namespace CandidateHubApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class CandidatesController : ControllerBase
	{
		private readonly CandidateDbContext _context;
		

		public CandidatesController(CandidateDbContext context)
		{
			_context = context;
			
		}
		/// <summary>
		///		
		/// </summary>
		/// <param name="candidate"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> UpdateInsertCandidate([FromBody] Candidate candidate)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingCandidate = await _context.Candidates.FindAsync(candidate.Email); 
			if (existingCandidate != null)
			{
				// Update existing candidate
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
				// Create new candidate
				_context.Candidates.Add(candidate);
			}

			await _context.SaveChangesAsync();
			return Ok(candidate);
		}
	}
}
