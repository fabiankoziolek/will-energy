using WillEnergy.Domain.Core.Documents;
using WillEnergy.Domain.Core.Documents.Extractor;
using WillEnergy.Domain.Core.Forms;
using Xunit;

namespace Application.UnitTests.DocumentParser
{
    public class FormKeyValueParserTest
    {
        [Fact]
        public void GivenFormInputWithFilledValues_ShouldCreateValidFormKeyValue()
        {
            // Arrange

            var expectedValue = "test value";
            var expectedKey = "#<" + nameof(FormInput) + ">#";

            var formInput = new FormInput(new DocumentContract());
            {
            }

            // Act

            var result = FormKeyValueParser.ExtractKeyValues(formInput);

            // Assert

            Assert.Contains(result, value => value.Key == expectedKey);
            Assert.Contains(result, value => value.Value == expectedValue);
        }
    }
}
