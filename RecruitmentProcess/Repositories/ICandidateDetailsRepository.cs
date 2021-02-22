using RecruitmentProcess.Infrastracture.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentProcess.Infrastracture.Repositories
{
   public interface ICandidateDetailsRepository
    {
        Task<IEnumerable<CandidateDetail>> Get();
        Task Post(CandidateDetail candidateDetail);
    }
}
