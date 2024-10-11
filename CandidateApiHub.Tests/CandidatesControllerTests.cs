using CandidateHubApi.Controllers;
using CandidateHubApi.Model;
using CandidateHubApi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;
using static CandidateHubApi.Model.Candidates;

namespace CandidateApiHub.Tests
{
	public class CandidatesControllerTests
	{
		private readonly CandidatesController _controller;
		private readonly Mock<ICandidateRepository> _mockRepository;

		public CandidatesControllerTests()
		{
			_mockRepository = new Mock<ICandidateRepository>();
			_controller = new CandidatesController(_mockRepository.Object);
		}

		[Fact]
		public async Task UpdateInsertCandidate_ValidCandidate_ReturnsOkResult()
		{
			// Arrange
			var candidate = new Candidate
			{
				Email = "test@example.com",
				FirstName = "John",
				LastName = "Doe",
				PhoneNumber = "1234567890",
				CallTimeInterval = "9 AM - 5 PM",
				LinkedInProfileUrl = "http://linkedin.com/in/johndoe",
				GitHubProfileUrl = "http://github.com/johndoe",
				Comment = "No comments"
			};

			_mockRepository.Setup(repo => repo.AddOrUpdateAsync(candidate)).Returns(Task.CompletedTask);

			// Act
		
			var result = await _controller.UpdateInsertCandidate(candidate);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			Assert.Equal("Candidate added/updated successfully.", okResult.Value);
		}

		[Fact]
		public async Task UpdateInsertCandidate_InvalidCandidate_ReturnsBadRequest()
		{
			// Arrange
			var candidate = new Candidate
			{
				Email = "success@example.com", 
				FirstName = "",  // Invalid firstname
				LastName = "Doe",
				PhoneNumber = "1234567890",
				CallTimeInterval = "9 AM - 5 PM",
				LinkedInProfileUrl = "http://linkedin.com/in/johndoe",
				GitHubProfileUrl = "http://github.com/johndoe",
				Comment = "No comments"
			};

			// Simulate model validation failure
			_controller.ModelState.AddModelError("FirstName", "First name is required.");

			// Act
			var result = await _controller.UpdateInsertCandidate(candidate);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

			// The Value of BadRequestObjectResult is a list of error messages
			var errorMessages = Assert.IsType<List<string>>(badRequestResult.Value);

			// Verify that the list contains the specific error message
			Assert.Contains("First name is required.", errorMessages);
		}


		[Fact]
		public async Task UpdateInsertCandidate_InvalidCandidateEmail_ReturnsBadRequest()
		{
			// Arrange
			var candidate = new Candidate
			{
				Email = "invalid-email", // Invalid email
				FirstName = "Sara", 
				LastName = "Dave",
				PhoneNumber = "1234567890",
				CallTimeInterval = "9 AM - 5 PM",
				LinkedInProfileUrl = "http://linkedin.com/in/johndoe",
				GitHubProfileUrl = "http://github.com/johndoe",
				Comment = "No comments"
			};

			// Simulate model validation failure
			_controller.ModelState.AddModelError("Email", "Invalid email address format.");

			// Act
			var result = await _controller.UpdateInsertCandidate(candidate);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

			// The Value of BadRequestObjectResult is a list of error messages
			var errorMessages = Assert.IsType<List<string>>(badRequestResult.Value);

			// Verify that the list contains the specific error message
			Assert.Contains("Invalid email address format.", errorMessages);
		}

		
	}
}
