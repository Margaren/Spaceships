namespace SpaceFleetDispatcher.Tests
{
    public class ParseTest
    {
        [Fact]
        public void EmptyInputDataInPlanetParse_Test()
        {
            string planet = string.Empty;
            Assert.Throws<NullReferenceException>(()=>Planet.Parse(planet));
        }
        [Theory]
        [InlineData(@"E:\aip\Spaceships\Lab_6\IncorrectDataForLab\IncorrectDataForPlanet")]
        [InlineData(@"E:\aip\Spaceships\Lab_6\IncorrectDataForLab\IncorrectNeedCargoForPlanet")]
        public void IncorrectFormatAndNeedCargo_Test(string cargo)
        {
            Assert.Throws<InvalidDataException>(() => Planet.Parse(cargo));
        }
        [Fact]
        public void EmptyInputDataInSpaceshipParse_Test()
        {
            string str = string.Empty;
            Assert.Throws<NullReferenceException>(() => ASpaceship.Parse(str));
        }
        [Theory]
        [InlineData(@"E:\aip\Spaceships\Lab_6\IncorrectDataForLab\IncorrectDataForSpaceship")]
        [InlineData(@"E:\aip\Spaceships\Lab_6\IncorrectDataForLab\IncorrectCapacityForSpaceship")]
        [InlineData(@"E:\aip\Spaceships\Lab_6\IncorrectDataForLab\IncorrectShipType")]
        public void IncorrectFormatAndCapacity_Test(string capacity)
        {
            Assert.Throws<InvalidDataException>(() => ASpaceship.Parse(capacity));
        }
        
    }
}