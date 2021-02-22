using RecruitmentProcess.Contracts.Models;
using RecruitmentProcess.Infrastracture.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecrutimentProcess.UnitTest
{
    public static class TestData
    {
        public static CandidateDetailModel GetCandidateDeatails()
        {
           return new CandidateDetailModel
            {
                FirstName = "test",
                LastName = "test",
                Dob = DateTime.UtcNow,
                Address = "test",
                Skill = "Test",
                Position = "Test",
                InterviewLevel = 1,
                FeedBack = "test",
                email = "test@gmail.com",
                PhonneNumber = "+447657564745",
                Decision="selected"
            };
        }
        public static List<CandidateDetail> GetCandidateDeatailList()
        {
           return new List<CandidateDetail>()
            {
                new CandidateDetail(){Id=Guid.NewGuid(),FirstName="mani",LastName="puppala", Dob= DateTime.UtcNow, PhonneNumber="+44 222232312321",Skill=".Net",Position="Seior",InterviewLevel=1,email="test@gmail.com",Address="test",Decision="Rejected",FeedBack="test"},
                 new CandidateDetail(){Id=Guid.NewGuid(),FirstName="test1",LastName="testL", Dob= DateTime.UtcNow, PhonneNumber="+44 222232312321",Skill=".Net",Position="Seior",InterviewLevel=1,email="test@gmail.com",Address="test",Decision="Rejected",FeedBack="test"},
                  new CandidateDetail(){Id=Guid.NewGuid(),FirstName="test2",LastName="Test2l", Dob= DateTime.UtcNow, PhonneNumber="+44 222232312321",Skill=".Net",Position="Seior",InterviewLevel=1,email="test@gmail.com",Address="test",Decision="Selected",FeedBack="test"},
                   new CandidateDetail(){Id=Guid.NewGuid(),FirstName="test3",LastName="Test3l", Dob= DateTime.UtcNow, PhonneNumber="+44 222232312321",Skill=".Net",Position="Seior",InterviewLevel=1,email="test@gmail.com",Address="test",Decision="Selected",FeedBack="test"},
            };
        }

    }

}
