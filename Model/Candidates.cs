using System.ComponentModel.DataAnnotations;

namespace CandidateHubApi.Model
{
	public class Candidates
	{
		public class Candidate
		{
			public int Id { get; set; }

			[Required(ErrorMessage = "First name is required.")]
			public string FirstName { get; set; }

			[Required(ErrorMessage = "Last name is required.")]
			public string LastName { get; set; }

			[Required(ErrorMessage = "Phone number is required.")]
			[Phone(ErrorMessage = "Invalid phone number format.")]
			public string PhoneNumber { get; set; }

			[Required(ErrorMessage = "Email is required.")]
			[EmailAddress(ErrorMessage = "Invalid email address format.")]
			public string Email { get; set; }

			public string CallTimeInterval { get; set; }
			public string LinkedInProfileUrl { get; set; }
			public string GitHubProfileUrl { get; set; }

			[Required(ErrorMessage = "Comment is required.")]
			public string Comment { get; set; }
		}
	}
}
