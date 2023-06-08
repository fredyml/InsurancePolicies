namespace InsurancePolicies.Infrastructure.Repository
{
    using InsurancePolicies.Domain.Entities;
    using InsurancePolicies.Domain.Exceptions;
    using InsurancePolicies.Domain.Interfaces;
    using MongoDB.Driver;
    using System;

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
            try
            {
                _collection.InsertOne(policy);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error al guardar la póliza en la base de datos.", ex);
            }
        }

        public void Update(InsurancePolicy policy)
        {
            try
            {
                _collection.ReplaceOne(p => p.PolicyNumber == policy.PolicyNumber, policy);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error al actualizar la póliza en la base de datos.", ex);
            }
        }
    }
}
