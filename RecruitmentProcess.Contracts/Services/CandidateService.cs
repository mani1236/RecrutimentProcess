using Microsoft.Data.SqlClient;
using RecruitmentProcess.Contracts.Models;
using RecruitmentProcess.Infrastracture.Entities;
using RecruitmentProcess.Infrastracture.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentProcess.Contracts.Services
{
    public class CandidateService : ICandidateService
    {
        private ICandidateDetailsRepository _candidateDetailsRepository;
        public CandidateService(ICandidateDetailsRepository candidateDetailsRepository)
        {
            _candidateDetailsRepository = candidateDetailsRepository;
        }
        public async Task<IEnumerable<CandidateDetail>> Get()
        {
           var res= await _candidateDetailsRepository.Get();
           return res;
                  
        }

        public async Task Post(CandidateDetailModel candidateDetail)
        {
                if (candidateDetail == null)
                {
                    throw new ArgumentNullException(nameof(candidateDetail));
                }
                var CandidateInfo = new CandidateDetail
                {
                    Id = Guid.NewGuid(),
                    FirstName = candidateDetail.FirstName,
                    LastName = candidateDetail.LastName,
                    Dob = candidateDetail.Dob,
                    Address = candidateDetail.Address,
                    Skill = candidateDetail.Skill,
                    Position = candidateDetail.Position,
                    InterviewLevel = candidateDetail.InterviewLevel,
                    FeedBack=candidateDetail.FeedBack,
                    email=candidateDetail.email,
                    PhonneNumber=candidateDetail.PhonneNumber,
                    Decision=candidateDetail.Decision
                    
                };
                await _candidateDetailsRepository.Post(CandidateInfo);  
            
        }
    }
}
