using InsurancePolicies.Application.Services.Interfaces;
using InsurancePolicies.Domain.Entities;
using InsurancePolicies.Domain.Exceptions;
using InsurancePolicies.Domain.Interfaces;

namespace InsurancePolicies.Application.Services
{
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private readonly IInsurancePolicyRepository _policyRepository;

        public InsurancePolicyService(IInsurancePolicyRepository policyRepository)
        {
            _policyRepository = policyRepository ?? throw new ArgumentNullException(nameof(policyRepository));
        }

        public InsurancePolicy GetPolicyByNumber(int policyNumber)
        {
            var policy = _policyRepository.GetByPolicyNumber(policyNumber);

            if (policy == null)
            {
                throw new NotFoundException($"Policy with number {policyNumber} not found.");
            }

            return policy;
        }

        public InsurancePolicy GetPolicyByVehicleLicensePlate(string licensePlate)
        {
            var policy = _policyRepository.GetByVehicleLicensePlate(licensePlate);

            if (policy == null)
            {
                throw new NotFoundException($"Policy with vehicle license plate {licensePlate} not found.");
            }

            return policy;
        }

        public void CreatePolicy(InsurancePolicy policy)
        {
            DateTime currentDate = DateTime.Now;

            if (policy.PolicyStartDate >= currentDate &&  policy.PolicyEndDate > currentDate)
            {
                _policyRepository.Add(policy);
                return;
            }

            throw new InvalidOperationException("Cannot create a policy that is not currently active.");
        }
    }
}
