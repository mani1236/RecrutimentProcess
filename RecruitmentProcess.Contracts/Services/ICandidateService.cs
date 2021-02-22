using RecruitmentProcess.Contracts.Models;
using RecruitmentProcess.Infrastracture.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentProcess.Contracts.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidateDetail>> Get();
        Task Post(CandidateDetailModel candidateDetail);
    }
}
