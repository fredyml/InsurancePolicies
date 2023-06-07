namespace InsurancePolicies.Domain
{
    public interface IInsurancePolicyRepository
    {
        InsurancePolicy GetByPolicyNumber(int policyNumber);
        InsurancePolicy GetByVehicleLicensePlate(string licensePlate);
        void Add(InsurancePolicy policy);
        void Update(InsurancePolicy policy);
    }
}
