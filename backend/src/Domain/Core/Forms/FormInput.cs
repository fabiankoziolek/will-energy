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
            DokumentyPotwierdzajace = contract.DokumentyPotwierdzajace;
            ExectuionCompany = contract.ExectuionCompany;
            UczestnicyPrawa = string.Join(", ",
                contract.UczestnicyPrawa.Select(up =>
                    up.Name + " " + up.AddressDetails.StreetName + " " + up.AddressDetails.BuildingNumber + " " +
                    up.AddressDetails.PostCode + " " + up.AddressDetails.City).ToList());
            BankDetails_Name = contract.BankDetails.Name;
            BankDetails_Number = contract.BankDetails.Number;

            Inv_NumerEwidencjiDzialki = contract.PlannedWorkAddressDetails.NumerEwidencjiDzialki;
            Inv_Obreb = contract.PlannedWorkAddressDetails.Obreb;
            // PlannedWorkAddressDetails_PrzeznaczonyPodDzialalnoscospodarcza = contract.PlannedWorkAddressDetails.PrzeznaczonyPodDzialalnoscospodarcza;
            Inv_PowierzchniaUzytkowa = contract.PlannedWorkAddressDetails.PowierzchniaUzytkowa.ToString();
            PlannedWorkAddressDetails_UzytkowanieDlaDzialalnosciGospodarczej = contract.PlannedWorkAddressDetails.PrzeznaczonyPodDzialalnoscospodarcza ? "tak" : "nie";
            PowierzchniaPodDzialalnosc = contract.PlannedWorkAddressDetails.PowierzchniaPodDzialanosc.ToString();
            StosunekPowierzchniDzialalnosciDoUzytkowej = contract.PlannedWorkAddressDetails.StosunekPowierzchniDzialalnosciDoUzytkowej.ToString();

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
            TytulPrawaDoDypozycji = GetOwnershipType(contract.TytulPrawaDoDypozycji);
            DeMinimis = contract.CompanyDetails.NiepobieraniePomocyDeMinimis ? "nie" : "pobieram";
            CompanyDetails_Type = GetCompanyDetails(contract.CompanyDetails.Type);
            Date_Today = DateTime.Today.ToString("dd-MM-yyyy");
        }

        public string PlannedWorkAddressDetails_UzytkowanieDlaDzialalnosciGospodarczej { get; set; }

        public string PlannedWorkAddressDetails_PostCode { get; set; }

        public string PlannedWorkAddressDetails_City { get; set; }

        public string PlannedWorkAddressDetails_BuildingNumber { get; set; }

        public string PlannedWorkAddressDetails_StreetName { get; set; }

        private static string GetCompanyDetails(CompanyDetailsType companyDetailsType)
        {
            switch (companyDetailsType)
            {
                case CompanyDetailsType.DzialalnoscGospodarcza:
                    return "działalność gospodarcza";
                case CompanyDetailsType.DzialanoscRolnicza:
                    return "działalność rolnicza";
                case CompanyDetailsType.DzialanoscWZakresieRybolostwaIAkwakultury:
                    return "działalność w zakresie rybołóstwa i akwakultury";
                default:
                    throw new ArgumentOutOfRangeException(nameof(companyDetailsType), companyDetailsType, null);
            }
        }

        private string GetOwnershipType(TytulPrawaDoDypozycji contractTytulPrawaDoDypozycji)
        {
            switch (contractTytulPrawaDoDypozycji)
            {
                case Documents.TytulPrawaDoDypozycji.Owner:
                    return "właściciel";
                case Documents.TytulPrawaDoDypozycji.CoOwner:
                    return "współwłaściciel";
                case Documents.TytulPrawaDoDypozycji.PermanentManagement:
                    return "zarządzanie wieczyste";
                case Documents.TytulPrawaDoDypozycji.RestrictionsPropertyLaw:
                    return "???";
                case Documents.TytulPrawaDoDypozycji.Other:
                    return "inne";
                default:
                    throw new ArgumentOutOfRangeException(nameof(contractTytulPrawaDoDypozycji), contractTytulPrawaDoDypozycji, null);
            }
        }

        private string GetHeatingType(HeatingType type)
        {
            switch (type)
            {
                case HeatingType.NetworkNaturalGas:
                    return "Gaz ziemny";
                case HeatingType.LiquefiedNaturalGas:
                    return "Gaz w płynie";
                case HeatingType.Biomass:
                    return "";
                case HeatingType.Electricity:
                    return "";
                case HeatingType.NetworkHeat:
                    return "";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            ;
        }

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

        public string TytulPrawaDoDypozycji { get; set; }

        public string Date_Today { get; set; }
        public string DeMinimis { get; set; }
        public string CompanyDetails_Type { get; set; }
    }
}
