using System;

namespace WillEnergy.Application
{
    public class FormRequest
    {
        public string Name { get; set; } // FirstName + LastName || Company Name
        public DateTimeOffset Date { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string NumerEwidencjiDziałki { get; set; }
        public string Obręb { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public CharakterystykaPrac CharakterStareZrodlo { get; set; }
        public CharakterystykaPrac CharakterPlanowaneZrodlo { get; set; }
        public DateTimeOffset PlanowanyTerminZakonczeniaPrac { get; set; }
        public Bank Bank { get; set; }
        public TytułPrawa Type { get; set; }
        public string UczestnicyPrawa { get; set; } // jesli typ nie jest wlasnosc
        public string DokumentyPotwierdzające { get; set; } // to pole będzie wypełnione na podstawie  Tytułu
        public string FirmaRealizujaca { get; set; }

        // POLA pracodawcy
        public TypDzialalnosci TypDzialalnosci { get; set; }
        public bool NiepobieraniePomocyDeMinimis { get; set; }
    }

    public enum TytułPrawa
    {
        własność, // jesli wlasciciel to uzyj imie i nazwisko podane wyzej zamiast UczestnicyPrawa
        współwłaściciel,
        trwałegoZarządu,
        graniczeniaPrawaRzeczowego,
        inne,
    }

    public class Bank
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }

    public class CharakterystykaPrac
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
