using System.Collections.Generic;
using Newtonsoft.Json;

namespace WillEnergy.Domain.Core.Measurements
{
    public class Measurement
    {
        [JsonProperty("longtitude")]
        public double Longtitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("currentSubjectiveValuePm10")]
        public string CurrentSubjectiveValuePm10 { get; set; }

        [JsonProperty("currentSubjectiveValuePm25")]
        public string CurrentSubjectiveValuePm25 { get; set; }

        [JsonProperty("currentSubjectiveColourPm10")]
        public string CurrentSubjectiveColourPm10 { get; set; }

        [JsonProperty("currentSubjectiveColourPm25")]
        public string CurrentSubjectiveColourPm25 { get; set; }

        [JsonProperty("currentSubjectiveOrderNumberPm10")]
        public long CurrentSubjectiveOrderNumberPm10 { get; set; }

        [JsonProperty("currentSubjectiveOrderNumberPm25")]
        public long CurrentSubjectiveOrderNumberPm25 { get; set; }

        [JsonProperty("forecastedSubjectiveValuePm10")]
        public string ForecastedSubjectiveValuePm10 { get; set; }

        [JsonProperty("forecastedSubjectiveValuePm25")]
        public string ForecastedSubjectiveValuePm25 { get; set; }

        [JsonProperty("forecastedSubjectiveColourPm10")]
        public string ForecastedSubjectiveColourPm10 { get; set; }

        [JsonProperty("forecastedSubjectiveColourPm25")]
        public string ForecastedSubjectiveColourPm25 { get; set; }

        [JsonProperty("forecastedSubjectiveOrderNumberPm10")]
        public long ForecastedSubjectiveOrderNumberPm10 { get; set; }

        [JsonProperty("forecastedSubjectiveOrderNumberPm25")]
        public long ForecastedSubjectiveOrderNumberPm25 { get; set; }

        [JsonProperty("forecastedDateTime")]
        public string ForecastedDateTime { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("buildingNumber")]
        public string BuildingNumber { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("ID_URZADZENIA")]
        public int ID_URZADZENIA { get; set; }

        [JsonProperty("PM1")]
        public double PM1 { get; set; }

        [JsonProperty("PM25")]
        public double PM25 { get; set; }

        [JsonProperty("PM10")]
        public double PM10 { get; set; }

        [JsonProperty("TEMPERATURA")]
        public double TEMPERATURA { get; set; }

        [JsonProperty("WILGOTNOSC")]
        public double WILGOTNOSC { get; set; }

        [JsonProperty("CISNIENIE")]
        public double CISNIENIE { get; set; }

        [JsonProperty("KIERUNEK_WIATRU")]
        public double KIERUNEK_WIATRU { get; set; }

        [JsonProperty("PREDKOSC")]
        public double PREDKOSC { get; set; }

        [JsonProperty("TYP_OPADU")]
        public long TYP_OPADU { get; set; }

        [JsonProperty("SUMA_OPADU")]
        public long SUMA_OPADU { get; set; }

        [JsonProperty("INTENSYWNOSC")]
        public long INTENSYWNOSC { get; set; }

        [JsonProperty("PREDKOSC_MAX")]
        public double PREDKOSC_MAX { get; set; }

        [JsonProperty("DATA_GODZINA")]
        public string DATA_GODZINA { get; set; }

        public IList<Measurement> Measurements { get; set; }
    }
}
