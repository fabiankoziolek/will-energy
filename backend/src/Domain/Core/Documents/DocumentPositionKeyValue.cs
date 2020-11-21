namespace WillEnergy.Domain.Core.Documents
{
    public class DocumentPositionKeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public DocumentPositionKeyValue(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
