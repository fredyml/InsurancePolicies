namespace InsurancePolicies.Domain
{
    public class InsurancePolicy
    {
        public int PolicyNumber { get; set; }
        public string ClientName { get; set; }
        public string ClientIdentification { get; set; }
        public DateTime ClientBirthDate { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public List<string> Coverages { get; set; }
        public decimal MaxCoverageValue { get; set; }
        public string PolicyPlanName { get; set; }
        public string ClientCity { get; set; }
        public string ClientAddress { get; set; }
        public string VehicleLicensePlate { get; set; }
        public string VehicleModel { get; set; }
        public bool VehicleInspection { get; set; }
    }
}
