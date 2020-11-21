using System;
using System.Collections.Generic;
using WillEnergy.Domain.Core.Forms;

namespace WillEnergy.Domain.Core.Documents
{
    public class DocumentContract
    {
        public DateTimeOffset Date { get; set; }
        public string Name { get; set; } // FirstName + LastName || Company Name

        /// <summary>
        /// Private individual or Company address.
        /// </summary>
        public AddressDetails AddressDetails { get; set; }

        public AddressDetails CorrespondenceAddressDetails { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public EInvestorType InvestorType { get; set; }
        public PlannedWorkAddressDetails PlannedWorkAddressDetails { get; set; }
        public EnergyCharacteristicsOfWork OldEnergyCharacteristics { get; set; }
        public EnergyCharacteristicsOfWork PlannedEnergyCharacteristics { get; set; }
        public DateTimeOffset PlannedCompletionDate { get; set; }
        public int EstimatedCost { get; set; }
        public BankDetails BankDetails { get; set; }
        public bool CanConnectToHeatingNetwork { get; set; }
        public bool CanConnectToGasNetwork { get; set; }
        public int YearOfInvestment { get; set; }
        public PropertyOwnershipType PropertyOwnershipType { get; set; }

        /// <summary>
        /// List współwłaścicieli posesji/nieruchomości.
        /// </summary>
        public IList<LawParticipant> LawParticipants { get; set; }

        /// <summary>
        /// Dokumenty upoważniające użytkowanie nieruchomości.
        /// </summary>
        public string DispositionLawDocuments { get; set; } // to pole będzie wypełnione na podstawie TytułPrawaDoDypozycji

        public string ExectuionCompany { get; set; }

        public string Nip { get; set; }
        public bool IsBenefitingDeMinimis { get; set; }
    }

    public class LawParticipant
    {
        public string Name { get; set; }
        public AddressDetails AddressDetails { get; set; }
    }

    public class AddressDetails
    {
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }

    public class PlannedWorkAddressDetails : AddressDetails
    {
        /// <summary>
        /// Numer ewidencyjny działki.
        /// </summary>
        public string PropertyRegistrationNumber { get; set; }

        /// <summary>
        /// Obręb w którym znajduje się działka.
        /// </summary>
        public string District { get; set; }

        public bool IsForCommercialUse { get; set; }

        /// <summary>
        /// Powierzchnia użytkowa.
        /// </summary>
        public int UsableArea { get; set; }

        /// <summary>
        /// Powierzchnia komercyjna.
        /// </summary>
        public int CommercialArea { get; set; }

        /// <summary>
        /// Stosunek powierzchni komercyjnej do użytkowej.
        /// </summary>
        public int CommercialToUsableAreaRatio { get; set; }
    }

    public enum PropertyOwnershipType
    {
        Owner, // jesli wlasciciel to uzyj imie i nazwisko podane wyzej zamiast UczestnicyPrawa
        CoOwner,
        PermanentManagement,
        RestrictionsPropertyLaw,
        Other,
        PerpetualUsufruct,
    }

    public class BankDetails
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }

    public class EnergyCharacteristicsOfWork
    {
        public HeatingType Type { get; set; } // wegiel, gaz, biomasa itd.
        public int Power { get; set; }
        public int Age { get; set; }
        public int ConsumptionPerYear { get; set; }
    }

    public enum HeatingType
    {
        NetworkNaturalGas,
        LiquefiedNaturalGas,
        Biomass,
        Electricity,
        NetworkHeat,
    }
}
