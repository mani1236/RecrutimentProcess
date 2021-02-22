using System;
using Xunit;
using Moq;
using RecruitmentProcess.Contracts.Services;
using RecruitmentProcess.Infrastracture.Repositories;
using RecruitmentProcess.Infrastracture.Entities;
using RecruitmentProcess.Contracts.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using RecrutimentProcess.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace RecrutimentProcess.UnitTest
{
    public class CandidateControllerTest
    {
        private readonly Mock<ICandidateService> _mockcandidateservice;
        private readonly Mock<ILogger<CandidateDetailsController>> _mockLogger;
        private readonly CandidateDetailsController _candidateDetailsController;

        public CandidateControllerTest()
        {
            _mockcandidateservice = new Mock<ICandidateService>();
            _mockLogger = new Mock<ILogger<CandidateDetailsController>>();
            _candidateDetailsController = new CandidateDetailsController(_mockcandidateservice.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Get_Candidates_exception()
        {
            //Arrange 
            _mockcandidateservice.Setup(x => x.Get()).Throws<Exception>();
            //Act 
            var result = await _candidateDetailsController.Get();
            //Assert 
            var errorResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, errorResult.StatusCode);


        }

        [Fact]
        public async Task Get_Candidates()
        {
            var candidatedetail = TestData.GetCandidateDeatailList();
            //Arrange 
            _mockcandidateservice.Setup(x => x.Get()).ReturnsAsync(candidatedetail);
            //Act 
            var result = await _candidateDetailsController.Get();
            //Assert 
            Assert.NotNull(result);


        }


        [Fact]
        public async Task Post_Candidates_ArugmentNullexception()
        {
            var candidate = new CandidateDetailModel();
            //Arrange 
            _mockcandidateservice.Setup(x => x.Post(candidate)).Throws<ArgumentNullException>();
            //Act 
            var result = await _candidateDetailsController.Create(candidate);
            //Assert 
            var errorResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, errorResult.StatusCode);


        }

        [Fact]
        public async Task Post_Candidates_exception()
        {
            var CandidateInfo = TestData.GetCandidateDeatails();
            //Arrange 
            _mockcandidateservice.Setup(x => x.Post(CandidateInfo)).Throws<Exception>();
            //Act 
            var result = await _candidateDetailsController.Create(CandidateInfo);
            //Assert 
            var errorResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, errorResult.StatusCode);
        }

        [Fact]
        public async Task Post_Candidates_Ok()
        {
            var CandidateInfo = TestData.GetCandidateDeatails();
            //Arrange 
            _mockcandidateservice.Setup(x => x.Post(CandidateInfo));
            //Act 
            var result = await _candidateDetailsController.Create(CandidateInfo);
            //Assert 
            var okResult = result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
