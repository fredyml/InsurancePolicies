using InsurancePolicies.Application.Services;
using InsurancePolicies.Domain.Entities;
using InsurancePolicies.Domain.Exceptions;
using InsurancePolicies.Domain.Interfaces;
using Moq;

namespace InsurancePolicies.Tests
{
    public class InsurancePolicyServiceTests
    {
        private readonly Mock<IInsurancePolicyRepository> _mockRepository;
        private readonly InsurancePolicyService _policyService;

        public InsurancePolicyServiceTests()
        {
            _mockRepository = new Mock<IInsurancePolicyRepository>();
            _policyService = new InsurancePolicyService(_mockRepository.Object);
        }

        [Fact]
        public void GetPolicyByNumber_ExistingPolicy_ReturnsPolicy()
        {
            // Arrange
            int policyNumber = 123;
            var expectedPolicy = new InsurancePolicy { PolicyNumber = policyNumber };
            _mockRepository.Setup(r => r.GetByPolicyNumber(policyNumber)).Returns(expectedPolicy);

            // Act
            var policy = _policyService.GetPolicyByNumber(policyNumber);

            // Assert
            Assert.Equal(expectedPolicy, policy);
        }

        [Fact]
        public void GetPolicyByNumber_NonExistingPolicy_ThrowsNotFoundException()
        {
            // Arrange
            int policyNumber = 123;
            _mockRepository.Setup(r => r.GetByPolicyNumber(policyNumber)).Returns((InsurancePolicy)null);

            // Assert
            Assert.Throws<NotFoundException>(() => _policyService.GetPolicyByNumber(policyNumber));
        }

        [Fact]
        public void GetPolicyByVehicleLicensePlate_ExistingPolicy_ReturnsPolicy()
        {
            // Arrange
            string licensePlate = "ABC123";
            var expectedPolicy = new InsurancePolicy { VehicleLicensePlate = licensePlate };
            _mockRepository.Setup(r => r.GetByVehicleLicensePlate(licensePlate)).Returns(expectedPolicy);

            // Act
            var policy = _policyService.GetPolicyByVehicleLicensePlate(licensePlate);

            // Assert
            Assert.Equal(expectedPolicy, policy);
        }

        [Fact]
        public void GetPolicyByVehicleLicensePlate_NonExistingPolicy_ThrowsNotFoundException()
        {
            // Arrange
            string licensePlate = "ABC123";
            _mockRepository.Setup(r => r.GetByVehicleLicensePlate(licensePlate)).Returns((InsurancePolicy)null);

            // Assert
            Assert.Throws<NotFoundException>(() => _policyService.GetPolicyByVehicleLicensePlate(licensePlate));
        }

        [Fact]
        public void CreatePolicy_ValidPolicy_AddsPolicyToRepository()
        {
            // Arrange
            var policy = new InsurancePolicy
            {
                PolicyNumber = 123,
                PolicyStartDate = DateTime.Now.AddDays(1),
                PolicyEndDate = DateTime.Now.AddDays(2)
            };

            // Act
            _policyService.CreatePolicy(policy);

            // Assert
            _mockRepository.Verify(r => r.Add(policy), Times.Once);
        }

        [Fact]
        public void CreatePolicy_ExpiredPolicy_ThrowsInvalidOperationException()
        {
            // Arrange
            var policy = new InsurancePolicy
            {
                PolicyNumber = 123,
                PolicyStartDate = DateTime.Now.AddDays(-1),
                PolicyEndDate = DateTime.Now.AddDays(-1)
            };

            // Assert
            Assert.Throws<InvalidOperationException>(() => _policyService.CreatePolicy(policy));
        }
    }
}
