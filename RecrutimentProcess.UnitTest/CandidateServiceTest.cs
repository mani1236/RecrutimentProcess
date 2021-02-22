using System;
using Xunit;
using Moq;
using RecruitmentProcess.Contracts.Services;
using RecruitmentProcess.Infrastracture.Repositories;
using RecruitmentProcess.Infrastracture.Entities;
using RecruitmentProcess.Contracts.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RecrutimentProcess.UnitTest
{
    public class CandidateServiceTest
    {
        [Fact]
        public void RegisterCandidate()
        {
            var mock = new Mock<ICandidateDetailsRepository>();
            var candidateService = new CandidateService(mock.Object);
            var CandidateInfo = TestData.GetCandidateDeatails();
            var results = candidateService.Post(CandidateInfo);
            Assert.NotNull(results);
        }
        [Fact]
        public void CandidateRegister_ArgumentNullException()
        {
            var mock = new Mock<ICandidateDetailsRepository>();
            var candidateService = new CandidateService(mock.Object);
            //Arrange
            var CandidateInfo = new CandidateDetailModel();
            //Act 
            Assert.ThrowsAsync<ArgumentNullException>(() => candidateService.Post(CandidateInfo));
        }

        [Fact]       
        public async Task  GetCandidate_Should_Throw_Exception()
        {
           var  candidatedetail = TestData.GetCandidateDeatailList();
            var mock = new Mock<ICandidateDetailsRepository>();
            var candidateService = new CandidateService(mock.Object);
            mock.Setup(m => m.Get()).ReturnsAsync(candidatedetail);
            var Results = await candidateService.Get();
            Assert.Equal(candidatedetail, Results);
        }       
    }
}
