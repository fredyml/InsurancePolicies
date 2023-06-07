namespace InsurancePolicies.Domain.Entities
{
    public class InsurancePolicy
    {
        /// <summary>
        /// Número de póliza
        /// </summary>
        public int PolicyNumber { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Identificación del cliente
        /// </summary>
        public string ClientIdentification { get; set; }

        /// <summary>
        /// Fecha de nacimiento del cliente
        /// </summary>
        public DateTime ClientBirthDate { get; set; }

        /// <summary>
        /// Fecha de inicio de la póliza
        /// </summary>
        public DateTime PolicyStartDate { get; set; }

        /// <summary>
        /// Fecha de fin de la póliza
        /// </summary>
        public DateTime PolicyEndDate { get; set; }

        /// <summary>
        /// Lista de coberturas de la póliza
        /// </summary>
        public List<string> Coverages { get; set; }

        /// <summary>
        /// Valor máximo de cobertura
        /// </summary>
        public decimal MaxCoverageValue { get; set; }

        /// <summary>
        /// Nombre del plan de póliza
        /// </summary>
        public string PolicyPlanName { get; set; }

        /// <summary>
        /// Ciudad del cliente
        /// </summary>
        public string ClientCity { get; set; }

        /// <summary>
        /// Dirección del cliente
        /// </summary>
        public string ClientAddress { get; set; }

        /// <summary>
        /// Placa del vehículo
        /// </summary>
        public string VehicleLicensePlate { get; set; }

        /// <summary>
        /// Modelo del vehículo
        /// </summary>
        public string VehicleModel { get; set; }

        /// <summary>
        /// Indicador de si se ha realizado una inspección del vehículo
        /// </summary>
        public bool VehicleInspection { get; set; }
    }
}
