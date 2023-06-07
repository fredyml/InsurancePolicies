using InsurancePolicies.Domain.Entities;

namespace InsurancePolicies.Application.Services.Interfaces
{
    public interface IInsurancePolicyService
    {
        InsurancePolicy GetPolicyByNumber(int policyNumber);
        InsurancePolicy GetPolicyByVehicleLicensePlate(string licensePlate);
    }
}
