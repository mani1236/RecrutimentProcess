using Microsoft.EntityFrameworkCore;
using RecruitmentProcess.Infrastracture.Dbcontext;
using RecruitmentProcess.Infrastracture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentProcess.Infrastracture.Repositories
{
    public class CandidateDetailsRepository : ICandidateDetailsRepository
    {
        private RecruitmentContext _recruitmentContext;
        public CandidateDetailsRepository(RecruitmentContext recruitmentContext)
        {
            _recruitmentContext = recruitmentContext;
        }
        public async Task<IEnumerable<CandidateDetail>> Get()
        {
            var Candidates = await _recruitmentContext.CandidateDetails.ToListAsync();
            return Candidates;
        }
        public async Task Post(CandidateDetail candidateDetail)
        {      
            await _recruitmentContext.CandidateDetails.AddAsync(candidateDetail);
            await _recruitmentContext.SaveChangesAsync();
        }
    }
}
