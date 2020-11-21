using System.Collections.Generic;
using Newtonsoft.Json;

namespace WillEnergy.Application.Measurements.Dto
{
    public class MeasurementDto
    {
        [JsonProperty("longtitude")]
        public double Longtitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("currentValuePm10")]
        public string CurrentValuePm10 { get; set; }

        [JsonProperty("currentValuePm25")]
        public string CurrentValuePm25 { get; set; }

        [JsonProperty("currentColourPm10")]
        public string CurrentColourPm10 { get; set; }

        [JsonProperty("currentColourPm25")]
        public string CurrentColourPm25 { get; set; }

        [JsonProperty("currentOrderNumberPm10")]
        public long CurrentOrderNumberPm10 { get; set; }

        [JsonProperty("currentOrderNumberPm25")]
        public long CurrentOrderNumberPm25 { get; set; }

        [JsonProperty("forecastedValuePm10")]
        public string ForecastedValuePm10 { get; set; }

        [JsonProperty("forecastedValuePm25")]
        public string ForecastedValuePm25 { get; set; }

        [JsonProperty("forecastedColourPm10")]
        public string ForecastedColourPm10 { get; set; }

        [JsonProperty("forecastedColourPm25")]
        public string ForecastedColourPm25 { get; set; }

        [JsonProperty("forecastedOrderNumberPm10")]
        public long ForecastedOrderNumberPm10 { get; set; }

        [JsonProperty("forecastedOrderNumberPm25")]
        public long ForecastedOrderNumberPm25 { get; set; }

        [JsonProperty("forecastedDateTime")]
        public string ForecastedDateTime { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("buildingNumber")]
        public string BuildingNumber { get; set; }

        [JsonProperty("PM1")]
        public double Pm1 { get; set; }

        [JsonProperty("PM25")]
        public double Pm25 { get; set; }

        [JsonProperty("PM10")]
        public double Pm10 { get; set; }

        [JsonProperty("TEMPERATURA")]
        public double Temperatura { get; set; }

        [JsonProperty("PREDKOSC_MAX")]
        public double PredkoscMax { get; set; }

        [JsonProperty("DATA_GODZINA")]
        public string DataGodzina { get; set; }

        [JsonProperty("MEASUREMENTS")]
        public IList<MeasurementDto> Measurements { get; set; }

        public string Predkosc { get; set; }

        public int CaqiPm25 => (int)(Pm25 * 100 / 110) > 100 ? 100 : (int)(Pm25 * 100 / 110);

        public int CaqiPm10 => (int)(Pm10 * 100 / 180) > 100 ? 100 : (int)(Pm10 * 100 / 180);
    }
}
