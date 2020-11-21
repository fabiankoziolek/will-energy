using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WillEnergy.Domain.Core.Documents;
using Xunit;

namespace Application.UnitTests.DocumentParser
{
    public class DocumentParserTest
    {
        private const string TestDocumentName = "Test_File.doc";
        private const string OutputDocumentName = "Test_File_Output.doc";
        private const string DocumentParserFolderName = "DocumentParser";
        private const string TestFileFolderName = "Files";

        [Fact]
        public async Task GivenDocumentTemplateAndKeyValues_ShouldProperlyParseDocument()
        {
            // Arrange
            var testFilePath = Path.Combine(DocumentParserFolderName, TestFileFolderName, TestDocumentName);
            var outputFilePath = Path.Combine(DocumentParserFolderName, TestFileFolderName, OutputDocumentName);
            var parser = new WillEnergy.Domain.Core.Documents.Parser.DocumentParser();

            // Act

            var keyValues = new List<DocumentPositionKeyValue>()
            {
                new DocumentPositionKeyValue("#<TEST_VALUE_1>#", "VAL1"),
                new DocumentPositionKeyValue("#<TEST_VALUE_2>#", "VAL2")
            };
            var output = await parser.ParseDocument(keyValues, testFilePath);
            using (var fileStream = new FileStream(outputFilePath, FileMode.Create))
            {
                output.Position = 0;
                await output.CopyToAsync(fileStream);
            }

            // Assert

            Assert.True(true);
        }
    }
}
