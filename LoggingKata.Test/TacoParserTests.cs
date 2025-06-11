using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParserInstance = new TacoParser();

            //Act
            var actual = tacoParserInstance.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.376395,-84.913185, Taco Bell Adairsvill...",-84.913185)]
        [InlineData("34.820847,-87.681448,Taco Bell Florence...", -87.681448)]
        [InlineData("30.190097,-85.711394,Taco Bell Panama City...", -85.711394)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", -84.56005)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParserInstance = new TacoParser();

            //Act
            var actual = tacoParserInstance.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.376395,-84.913185, Taco Bell Adairsvill...",34.376395)]
        [InlineData("34.820847,-87.681448,Taco Bell Florence...", 34.820847)]
        [InlineData("30.190097,-85.711394,Taco Bell Panama City...", 30.190097)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", 34.113051)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParserInstance = new TacoParser();
            
            var actual = tacoParserInstance.Parse(line);
            
            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
