using InsurancePolicies.Application.Services.Interfaces;
using InsurancePolicies.Domain.Entities;
using InsurancePolicies.Domain.Exceptions;
using InsurancePolicies.Domain.Interfaces;

namespace InsurancePolicies.Application.Services
{
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;

        public InsurancePolicyService(IInsurancePolicyRepository insurancePolicyRepository)
        {
            _insurancePolicyRepository = insurancePolicyRepository ?? throw new ArgumentNullException(nameof(insurancePolicyRepository));
        }

        public InsurancePolicy GetPolicyByNumber(int policyNumber)
        {
            var policy = _insurancePolicyRepository.GetByPolicyNumber(policyNumber);

            return policy ?? throw new NotFoundException($"Policy with number {policyNumber} not found.");
        }

        public InsurancePolicy GetPolicyByVehicleLicensePlate(string licensePlate)
        {
            var policy = _insurancePolicyRepository.GetByVehicleLicensePlate(licensePlate);

            return policy ?? throw new NotFoundException($"Policy with vehicle license plate {licensePlate} not found.");
        }
    }
}
