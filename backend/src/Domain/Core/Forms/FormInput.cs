using System;
using System.Linq;
using WillEnergy.Domain.Core.Documents;

namespace WillEnergy.Domain.Core.Forms
{
    public class FormInput
    {
        public FormInput(DocumentContract contract)
        {
            Date = contract.Date;
            Name = contract.Name;
            AddressDetails_City = contract.AddressDetails.City;
            AddressDetails_PostCode = contract.AddressDetails.PostCode;
            AddressDetails_BuildingNumber = contract.AddressDetails.BuildingNumber;
            AddressDetails_StreetName = contract.AddressDetails.StreetName;
            Corr_StreetName = contract.CorrespondenceAddressDetails?.StreetName ?? string.Empty;
            Corr_BuildingNumber = contract.CorrespondenceAddressDetails?.BuildingNumber ?? string.Empty;
            Corr_City = contract.CorrespondenceAddressDetails?.City ?? string.Empty;
            Corr_PostCode = contract.CorrespondenceAddressDetails?.PostCode ?? string.Empty;
            PhoneNumber = contract.PhoneNumber;
            Email = contract.Email;
            PlannedCompletionDate = contract.PlannedCompletionDate;
            EstimatedCost = contract.EstimatedCost;
            HeatingNetworkDetails = contract.CanConnectToHeatingNetwork ? "mam" : "nie mam";
            GasNetworkDetails = contract.CanConnectToGasNetwork ? "mam" : "nie mam";
            YearOfInvestment = contract.YearOfInvestment;
            DokumentyPotwierdzajace = contract.DispositionLawDocuments;
            ExectuionCompany = contract.ExectuionCompany;
            UczestnicyPrawa = string.Join(
                ", ",
                contract.LawParticipants.Select(up =>
                    up.Name + " " + up.AddressDetails.StreetName + " " + up.AddressDetails.BuildingNumber + " " +
                    up.AddressDetails.PostCode + " " + up.AddressDetails.City).ToList());
            BankDetails_Name = contract.BankDetails.Name;
            BankDetails_Number = contract.BankDetails.Number;

            Inv_NumerEwidencjiDzialki = contract.PlannedWorkAddressDetails.PropertyRegistrationNumber;
            Inv_Obreb = contract.PlannedWorkAddressDetails.District;
            Inv_PostCode = contract.PlannedWorkAddressDetails.PostCode;
            Inv_BuildingNumber = contract.PlannedWorkAddressDetails.BuildingNumber;
            Inv_StreetName = contract.PlannedWorkAddressDetails.StreetName;
            Inv_City = contract.PlannedWorkAddressDetails.City;
            Inv_PowierzchniaUzytkowa = contract.PlannedWorkAddressDetails.UsableArea.ToString();
            PlannedWorkAddressDetails_UzytkowanieDlaDzialalnosciGospodarczej =
                contract.PlannedWorkAddressDetails.IsForCommercialUse ? "tak" : "nie";
            PowierzchniaPodDzialalnosc = contract.PlannedWorkAddressDetails.CommercialArea.ToString();
            StosunekPowierzchniDzialalnosciDoUzytkowej = contract.PlannedWorkAddressDetails.CommercialToUsableAreaRatio.ToString();

            PlannedWorkAddressDetails_StreetName = contract.PlannedWorkAddressDetails.StreetName;
            PlannedWorkAddressDetails_BuildingNumber = contract.PlannedWorkAddressDetails.BuildingNumber;
            PlannedWorkAddressDetails_City = contract.PlannedWorkAddressDetails.City;
            PlannedWorkAddressDetails_PostCode = contract.PlannedWorkAddressDetails.PostCode;

            OldEnergyCharacteristics_Power = contract.OldEnergyCharacteristics.Power.ToString();
            OldEnergyCharacteristics_Age = contract.OldEnergyCharacteristics.Age.ToString();
            OldEnergyCharacteristics_ConsumptionPerYear = contract.OldEnergyCharacteristics.ConsumptionPerYear.ToString();
            OldEnergyCharacteristics_Type = GetHeatingType(contract.OldEnergyCharacteristics.Type);
            PlannedEnergyCharacteristics_Power = contract.PlannedEnergyCharacteristics.Power.ToString();
            PlannedEnergyCharacteristics_ConsumptionPerYear = contract.PlannedEnergyCharacteristics.ConsumptionPerYear.ToString();
            PlannedEnergyCharacteristics_Type = GetHeatingType(contract.PlannedEnergyCharacteristics.Type);

            TytulPrawaDoDyspozycji = string.Format(GetOwnershipType(contract.PropertyOwnershipType), UczestnicyPrawa);
            CompanyDetails_Type = GetCompanyDetails(contract.InvestorType);
            InvestorType_B = GetInvestorType(contract.InvestorType);
            Date_Today = DateTime.Today.ToString("dd-MM-yyyy");
            Nip = contract.Nip;
        }

        public string InvestorType_B { get; set; }

        public string Temp_4_Type { get; set; }

        public string Inv_City { get; set; }

        public string Inv_StreetName { get; set; }

        public string Inv_BuildingNumber { get; set; }

        public string Inv_PostCode { get; set; }

        public string Nip { get; set; }

        public string PlannedWorkAddressDetails_UzytkowanieDlaDzialalnosciGospodarczej { get; set; }

        public string PlannedWorkAddressDetails_PostCode { get; set; }

        public string PlannedWorkAddressDetails_City { get; set; }

        public string PlannedWorkAddressDetails_BuildingNumber { get; set; }

        public string PlannedWorkAddressDetails_StreetName { get; set; }

        public DateTimeOffset Date { get; set; }
        public string Name { get; set; } // FirstName + LastName || Company Name

        public string AddressDetails_StreetName { get; set; }
        public string AddressDetails_BuildingNumber { get; set; }
        public string AddressDetails_City { get; set; }
        public string AddressDetails_PostCode { get; set; }

        public string Corr_StreetName { get; set; }
        public string Corr_BuildingNumber { get; set; }
        public string Corr_City { get; set; }
        public string Corr_PostCode { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTimeOffset PlannedCompletionDate { get; set; }
        public int EstimatedCost { get; set; }

        public string HeatingNetworkDetails { get; set; }
        public string GasNetworkDetails { get; set; }

        public int YearOfInvestment { get; set; }
        public string DokumentyPotwierdzajace { get; set; } // to pole będzie wypełnione na podstawie TytułPrawaDoDypozycji
        public string ExectuionCompany { get; set; }
        public string UczestnicyPrawa { get; set; }
        public string BankDetails_Name { get; set; }
        public string BankDetails_Number { get; set; }
        public string Inv_NumerEwidencjiDzialki { get; set; }
        public string Inv_Obreb { get; set; }
        public string Inv_PrzeznaczonyPodDzialalnoscospodarcza { get; set; }

        public string Inv_PowierzchniaUzytkowa { get; set; }

        // public string PlannedWorkAddressDetails_PowierzchniaUzytkowa { get; set; }
        public string PowierzchniaPodDzialalnosc { get; set; }
        public string StosunekPowierzchniDzialalnosciDoUzytkowej { get; set; }
        public string OldEnergyCharacteristics_Power { get; set; }
        public string OldEnergyCharacteristics_Age { get; set; }
        public string OldEnergyCharacteristics_ConsumptionPerYear { get; set; }
        public string OldEnergyCharacteristics_Type { get; set; }
        public string PlannedEnergyCharacteristics_Power { get; set; }
        public string PlannedEnergyCharacteristics_ConsumptionPerYear { get; set; }
        public string PlannedEnergyCharacteristics_Type { get; set; }

        public string TytulPrawaDoDyspozycji { get; set; }

        public string Date_Today { get; set; }
        public string IsBenefitingDeMinimis { get; set; }
        public string CompanyDetails_Type { get; set; }

        private static string GetCompanyDetails(EInvestorType investorType)
        {
            switch (investorType)
            {
                case EInvestorType.Company:
                    return "działalność gospodarcza";
                case EInvestorType.Farmer:
                    return "działalność rolnicza";
                case EInvestorType.Fisherman:
                    return "działalność w zakresie rybołóstwa i akwakultury";
                case EInvestorType.PrivateIndividual:
                    return "osoba prywatna";
                default:
                    return string.Empty;
            }
        }

        private string GetInvestorType(EInvestorType investorType)
        {
            switch (investorType)
            {
                case EInvestorType.Company:
                    return "działalność gospodarczą";
                case EInvestorType.Farmer:
                    return "działalność rolniczą";
                case EInvestorType.Fisherman:
                    return "działalność w zakresie rybołóstwa i akwakultury";
                default:
                    return "......................";
            }
        }

        private string GetOwnershipType(PropertyOwnershipType contractPropertyOwnershipType)
        {
            switch (contractPropertyOwnershipType)
            {
                case PropertyOwnershipType.Owner:
                    return "własności";
                case PropertyOwnershipType.CoOwner:
                    return string.Format(
                        "współwłasności {0}, oraz dysponuję ich zgodami, które przedstawiam w załączeniu",
                        UczestnicyPrawa);
                case PropertyOwnershipType.PermanentManagement:
                    return "trwałego zarządu";
                case PropertyOwnershipType.PerpetualUsufruct:
                    return "użytkowania wieczystego";
                case PropertyOwnershipType.RestrictionsPropertyLaw:
                    return "ograniczonego prawa rzeczowego";
                case PropertyOwnershipType.Other:
                    return string.Format(
                        "innego tytułu, wynikające z następujących dokumentów potwierdzających powyższe prawo do dysponowania nieruchomością: {0}",
                        DokumentyPotwierdzajace);
                default:
                    return string.Empty;
            }
        }

        private static string GetHeatingType(HeatingType type)
        {
            switch (type)
            {
                case HeatingType.NetworkNaturalGas:
                    return "ogrzewanie gazowe";
                case HeatingType.LiquefiedNaturalGas:
                    return "ogrzewanie gazowe";
                case HeatingType.Biomass:
                    return "kocioł opalany granulatem drzewnym, tzw. biomasą";
                case HeatingType.Electricity:
                    return "ogrzewanie elektryczne";
                case HeatingType.NetworkHeat:
                    return "podłączenie do sieci ciepłowniczej";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
