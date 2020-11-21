using System.Collections.Generic;
using WillEnergy.Domain.Core.Forms;

namespace WillEnergy.Domain.Core.Documents.Extractor
{
    public static class FormKeyValueParser
    {
        public static IList<DocumentPositionKeyValue> ExtractKeyValues(FormInput form)
        {
            var documentPositions = new List<DocumentPositionKeyValue>();

            var fields = form.GetType().GetProperties();

            foreach (var field in fields)
            {
                field.GetType();
                var value = (object)field.GetValue(form);
                documentPositions.Add(new DocumentPositionKeyValue(ParseKey(field.Name), value?.ToString() ?? string.Empty));
            }

            return documentPositions;
        }

        public static string ParseKey(string key) => "#<" + key + ">#";
    }
}
