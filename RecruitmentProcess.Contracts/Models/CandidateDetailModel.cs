using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentProcess.Contracts.Models
{
    public class CandidateDetailModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Skill { get; set; }
        public DateTime? Dob { get; set; }
        public string Position { get; set; }
        public string FeedBack { get; set; }
        public int? InterviewLevel { get; set; }
        public string PhonneNumber { get; set; }
        public string email { get; set; }
        public string Decision { get; set; }
    }
}
