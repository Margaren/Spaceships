namespace SpaceFleetDispatcher.Tests
{
    public class DispatcherTest
    {
        [Theory]
        [InlineData(@"E:\aip\Spaceships\Lab_6\IncorrectDataForLab\InputDataWithoutPlanets.txt")]
        [InlineData(@"E:\aip\Spaceships\Lab_6\IncorrectDataForLab\InputDataWithoutShips.txt")]
        public void InputDataWithoutPlanetsOrShips(string data)
        {
            Assert.Throws<InvalidDataException>(() => Dispatcher.SetDataAndGetOutData(data));
        }
        [Theory]
        [InlineData(@"E:\aip\Spaceships\Lab_6\IncorrectDataForLab\PlanetPortMoreThanOne.txt")]
        [InlineData(@"E:\aip\Spaceships\Lab_6\IncorrectDataForLab\PlanetPortEmpty.txt")]
        public void IncorrectPlanetPortValue_Test(string port)
        {
            Assert.Throws<InvalidDataException>(() => Dispatcher.SetDataAndGetOutData(port));
        }
    }
}
