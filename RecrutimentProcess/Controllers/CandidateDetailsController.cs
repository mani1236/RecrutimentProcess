using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using RecruitmentProcess.Contracts.Models;
using RecruitmentProcess.Contracts.Services;
using RecruitmentProcess.Infrastracture.Entities;

namespace RecrutimentProcess.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CandidateDetailsController : ControllerBase
    {
        private ICandidateService _candidateService;
        private readonly ILogger _logger;

        public CandidateDetailsController(ICandidateService candidateService, ILogger logger)
        {
            _candidateService = candidateService;
            _logger = logger;
        }

        [HttpGet]
       
        // GET: CandidateDetails
        public async Task<IActionResult> Get()
        {

            try
            {
                var res = await _candidateService.Get();
                return Ok(res);
            }

            catch(SqlException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500); 
            }
            
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]

        // GET: CandidateDetails
        public async Task<IActionResult> Create([FromBody] CandidateDetailModel candidateDetailModel)
        {
            try
            {
                await _candidateService.Post(candidateDetailModel);
                return Ok("Candiate Registred");
            }

            catch (SqlException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

            catch(ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
        
}
