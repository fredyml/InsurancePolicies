using InsurancePolicies.Application;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePolicies.Controllers
{
    [ApiController]
    [Route("api/policies")]
    public class InsurancePolicyController : ControllerBase
    {
        private readonly InsurancePolicyService _policyService;

        public InsurancePolicyController(InsurancePolicyService policyService)
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
    }
}
