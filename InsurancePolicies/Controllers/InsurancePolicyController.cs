using InsurancePolicies.Application.Services.Interfaces;
using InsurancePolicies.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePolicies.Controllers
{
    [ApiController]
    [Route("api/policies")]
    public class InsurancePolicyController : ControllerBase
    {
        private readonly IInsurancePolicyService _policyService;

        public InsurancePolicyController(IInsurancePolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet("number/{policyNumber}")]
        public IActionResult GetPolicyByNumber(int policyNumber)
        {
            var policy = _policyService.GetPolicyByNumber(policyNumber);
            if (policy == null)
            {
                return NotFound();
            }

            return Ok(policy);
        }

        [HttpGet("vehicle/{licensePlate}")]
        public IActionResult GetPolicyByVehicleLicensePlate(string licensePlate)
        {
            var policy = _policyService.GetPolicyByVehicleLicensePlate(licensePlate);
            if (policy == null)
            {
                return NotFound();
            }

            return Ok(policy);
        }

        [HttpPost("CreatePolicy")]
        public IActionResult CreatePolicy([FromBody] InsurancePolicy policy)
        {

            _policyService.CreatePolicy(policy);
            return CreatedAtAction(nameof(GetPolicyByNumber), new { policyNumber = policy.PolicyNumber }, policy);

        }
    }
}

