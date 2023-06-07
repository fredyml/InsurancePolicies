using InsurancePolicies.Domain;

namespace InsurancePolicies.Application
{
    public class InsurancePolicyService
    {
        private readonly IInsurancePolicyRepository _policyRepository;

        public InsurancePolicyService(IInsurancePolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public InsurancePolicy GetPolicyByNumber(int policyNumber)
        {
            var policy = _policyRepository.GetByPolicyNumber(policyNumber);
            if (policy == null)
            {
               
            }

            return policy;
        }

        public InsurancePolicy GetPolicyByVehicleLicensePlate(string licensePlate)
        {
            var policy = _policyRepository.GetByVehicleLicensePlate(licensePlate);
            if (policy == null)
            {
                
            }

            return policy;
        }
    }
}
