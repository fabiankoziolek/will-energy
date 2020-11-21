using System;
using System.Collections.Generic;

namespace WillEnergy.Domain.Core.Documents
{
    public class DocumentContract
    {
        public DateTimeOffset Date { get; set; }
        public string Name { get; set; } // FirstName + LastName || Company Name
        public AddressDetails AddressDetails { get; set; } // Private / Company
        public AddressDetails CorrespondenceAddressDetails { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public PlannedWorkAddressDetails PlannedWorkAddressDetails { get; set; }
        public EnergyCharacteristicsOfWork OldEnergyCharacteristics { get; set; }
        public EnergyCharacteristicsOfWork PlannedEnergyCharacteristics { get; set; }
        public DateTimeOffset PlannedCompletionDate { get; set; }
        public int EstimatedCost { get; set; }
        public BankDetails BankDetails { get; set; }
        public bool CanConnectToHeatingNetwork { get; set; }
        public bool CanConnectToGasNetwork { get; set; }
        public int YearOfInvestment { get; set; }

        public TytulPrawaDoDypozycji TytulPrawaDoDypozycji { get; set; }
        public IList<LawParticipant> UczestnicyPrawa { get; set; } // kiedy nie właściciel
        public string DokumentyPotwierdzajace { get; set; } // to pole będzie wypełnione na podstawie TytułPrawaDoDypozycji

        public string ExectuionCompany { get; set; }

        public CompanyDetails CompanyDetails { get; set; } // na podstawie PrzeznaczonyPodDziałalnośćGospodarczą
    }

    public class CompanyDetails
    {
        public CompanyDetailsType Type { get; set; }
        public bool NiepobieraniePomocyDeMinimis { get; set; }
        public string Nip { get; set; }
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
        public string NumerEwidencjiDzialki { get; set; }
        public string Obreb { get; set; }
        public bool PrzeznaczonyPodDzialalnoscospodarcza { get; set; }
        public int PowierzchniaUzytkowa { get; set; }
        public int PowierzchniaPodDzialanosc { get; set; }
        public int StosunekPowierzchniDzialalnosciDoUzytkowej { get; set; }
    }

    public enum TytulPrawaDoDypozycji
    {
        Owner, // jesli wlasciciel to uzyj imie i nazwisko podane wyzej zamiast UczestnicyPrawa
        CoOwner,
        PermanentManagement,
        RestrictionsPropertyLaw,
        Other,
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

    public enum CompanyDetailsType
    {
        DzialalnoscGospodarcza,
        DzialanoscRolnicza,
        DzialanoscWZakresieRybolostwaIAkwakultury,
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
