using InsurancePolicies.Domain.Entities;

namespace InsurancePolicies.Domain.Interfaces
{
    public interface IInsurancePolicyRepository
    {
        InsurancePolicy GetByPolicyNumber(int policyNumber);
        InsurancePolicy GetByVehicleLicensePlate(string licensePlate);
        void Add(InsurancePolicy policy);
        void Update(InsurancePolicy policy);
    }
}
