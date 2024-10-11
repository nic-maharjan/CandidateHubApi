using CandidateHubApi.DbContext;
using CandidateHubApi.Repository.Interface;
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

		public  ICandidateRepository _repository;

		public CandidatesController(ICandidateRepository repository)
		{
			_repository = repository;
			
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
				// Extract error messages only
				var errorMessages = ModelState.Values
					.SelectMany(v => v.Errors)
					.Select(e => e.ErrorMessage)
					.ToList();

				return BadRequest(errorMessages);
			}

			await _repository.AddOrUpdateAsync(candidate);
			return Ok("Candidate added/updated successfully.");
		}
	}
}
