namespace InsurancePolicies.Infrastructure.Repository
{
    using InsurancePolicies.Domain.Entities;
    using InsurancePolicies.Domain.Interfaces;
    using MongoDB.Driver;

    public class InsurancePolicyRepository : IInsurancePolicyRepository
    {
        private readonly IMongoCollection<InsurancePolicy> _collection;

        public InsurancePolicyRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<InsurancePolicy>("InsurancePolicies");
        }

        public InsurancePolicy GetByPolicyNumber(int policyNumber)
        {
            return _collection.Find(p => p.PolicyNumber == policyNumber).FirstOrDefault();
        }

        public InsurancePolicy GetByVehicleLicensePlate(string licensePlate)
        {
            return _collection.Find(p => p.VehicleLicensePlate == licensePlate).FirstOrDefault();
        }

        public void Add(InsurancePolicy policy)
        {
            _collection.InsertOne(policy);
        }

        public void Update(InsurancePolicy policy)
        {
            _collection.ReplaceOne(p => p.PolicyNumber == policy.PolicyNumber, policy);
        }
    }
}
