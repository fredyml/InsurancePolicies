using InsurancePolicies.Application.Services.Interfaces;
using InsurancePolicies.Domain.Entities;
using InsurancePolicies.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InsurancePolicies.Controllers
{
    [ApiController]
    [Route("api/policies")]
    public class InsurancePolicyController : ControllerBase
    {
        private readonly IInsurancePolicyService _policyService;

        public InsurancePolicyController(IInsurancePolicyService policyService)
        {
            _policyService = policyService ?? throw new ArgumentNullException(nameof(policyService));
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult GenerateToken()
        {
            var secretKey = Environment.GetEnvironmentVariable("KEY");
            var issuer = "https://test.com";
            var audience = "InsurancePolicy";
            var expiryMinutes = 60;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "NameTest"),
                new Claim(ClaimTypes.Role, "RoleTest")
            };

            var jwtTokenService = new JwtTokenService();
            var token = jwtTokenService.GenerateJwtToken(secretKey, issuer, audience, expiryMinutes, claims);

            return Ok(token);
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        [HttpPost("create")]
        public IActionResult CreatePolicy([FromBody] InsurancePolicy policy)
        {
            _policyService.CreatePolicy(policy);
            return CreatedAtAction(nameof(GetPolicyByNumber), new { policyNumber = policy.PolicyNumber }, policy);
        }
    }
}
