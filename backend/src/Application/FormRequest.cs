using System;
using System.Collections.Generic;

namespace WillEnergy.Application
{
    public class FormRequest
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
        public bool MożliwościPodłączeniaNieruchomościNaKtórejBędzieRealizowaneZadanieDoSieciCiepłowniczej { get; set; }
        public bool MożliwościPodłączeniaNieruchomościNaKtórejBędzieRealizowaneZadanieDoSieciGazowej { get; set; }
        public int RokGDZIEZakończęInwestycjęPodłączeniaDoSieciNajpóźniejDoDnia7Listopada { get; set; }

        public TytułPrawaDoDypozycji TytułPrawaDoDypozycji { get; set; }
        public IList<UczestnikPrawa> UczestnicyPrawa { get; set; } // jesli typ nie jest wlasnosc
        public string DokumentyPotwierdzające { get; set; } // to pole będzie wypełnione na podstawie Tytułu

        public string FirmaRealizujaca { get; set; }

        // POLA pracodawcy jeśli nie
        public CompanyDetails CompanyDetails { get; set; } // na podstawie PrzeznaczonyPodDziałalnośćGospodarczą
    }

    public class CompanyDetails
    {
        public TypDzialalnosci TypDzialalnosci { get; set; }
        public bool NiepobieraniePomocyDeMinimis { get; set; }
        public string Nip { get; set; }
    }

    public class UczestnikPrawa
    {
        public string Name { get; set; }
        public AddressDetails AddressDetails { get; set; }
    }

    public class AddressDetails
    {
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
    }

    public class PlannedWorkAddressDetails : AddressDetails
    {
        public string NumerEwidencjiDziałki { get; set; }
        public string Obręb { get; set; }
        public bool PrzeznaczonyPodDziałalnośćGospodarczą { get; set; }
        public int PowierzchniaUżytkowaObiektu { get; set; }
        public int PowierzchniaUżytkowaObiektuPrzeznaczonaPodDziałalność { get; set; }
        public int UdziałPowierzchniPrzeznaczonejPodDziałalnośćGospodarcząWStosunkuDoPowierzchniUżytkowejBudynku { get; set; }
    }

    public enum TytułPrawaDoDypozycji
    {
        własność, // jesli wlasciciel to uzyj imie i nazwisko podane wyzej zamiast UczestnicyPrawa
        współwłaściciel,
        trwałegoZarządu,
        graniczeniaPrawaRzeczowego,
        inne,
    }

    public class BankDetails
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }

    public class EnergyCharacteristicsOfWork
    {
        public HeatingType Type { get; set; } // wegiel, gaz, biomasa itd.
        public int Moc { get; set; }
        public int Wiek { get; set; }
        public int ZuzycieNaRok { get; set; }
    }

    public enum TypDzialalnosci
    {
        DziałalnoscGospodarcza,
        DzialanoscRolnicza,
        DzialanoscWZakresieRybolostwaIAkwakultury
    }

    public enum HeatingType {
        NetworkNaturalGas,
        LiquefiedNaturalGas,
        Biomass,
        Electricity,
        NetworkHeat,
    }
}
