using TxtFIleRead;

namespace SpaceFleetDispatcher
{
    public class Dispatcher
    {
        public static readonly List<string> outData = new List<string>();
        private static readonly List<ASpaceship> Ships = new List<ASpaceship>();
        private static readonly List<Planet> Planets = new List<Planet>();

        private static Dictionary<Planet, double> Distanse = new Dictionary<Planet, double>();
        public static void SetDataAndGetOutData(string data)
        {
            GetShipsAndPlanetsList(data);
            DistributioOfTasks(Ships);
            ReaderClass.Write(outData.ToArray());
        }
        private static void GetShipsAndPlanetsList(string range)
        {
            var ships =
               from a in ReaderClass.Read(range)
               where a.Contains("Range")
               select a;
            if (!ships.Any())
                throw new InvalidDataException("Отсутствуют данные о кораблях");
            
            foreach (var line in ships)
            {
                Ships.Add(ASpaceship.Parse(line));
            }
            var planets =
                (from a in ReaderClass.Read(range) where !(string.IsNullOrEmpty(a)) select a).Except(from g2 in ships select g2);
            if (!planets.Any())
                throw new InvalidDataException("Отсутствуют данные о планетах");
            foreach (var line in planets)
            {
                Planets.Add(Planet.Parse(line));
            }
        }
        private static void DistributioOfTasks(List<ASpaceship> aSpaceships)
        {
            CalculateTheDistance();
            List<Planet> planetList = new List<Planet>();
            List<Planet> tempPlanets= new List<Planet>(Planets);
            tempPlanets.Remove(tempPlanets.First(x => x.Name == "Earth"));
            foreach (var ship in aSpaceships)
            {
                for (int j = 0; j < tempPlanets.Count; j++)
                {
                    if (ship.Capacity >= tempPlanets[j].NeedCargo && Distanse[tempPlanets[j]]<=ship.GetRange())
                    {
                        planetList.Add(tempPlanets[j]);
                    }
                }
                List<string> planetOutData = new List<string>();
                for (int i = 0; i < planetList.Count; i++)
                {
                    var planets = (from p in Distanse where p.Key == planetList.Find(x => x.Name == p.Key.Name) select p.Key).ToList();
                    planetOutData.Add($"{planets[i]}\tРасстояние до планеты: {Distanse[planets[i]]}");
                }
                outData.Add($"\n{ship}\nСписок планет:\n{string.Join("\n", planetOutData)}");
                tempPlanets = tempPlanets.Except(planetList).ToList();
                planetList.Clear();
            }
        }
        private static void CalculateTheDistance()
        {
            double distance = 0;
            var Earth = (from e in Planets where e.Name == "Earth" select e).ToList();
            if (!Earth.Any()|| Earth.Count > 1)
                throw new InvalidDataException("Отсутствует планета-порт или количество планет-портов больше одной");
            Planet planet = Earth.FirstOrDefault();

            foreach (var item in Planets)
            {
                if (item.Name == "Earth")
                    continue;
                distance = Math.Sqrt(
                    Math.Pow((item.CoordinateX - planet.CoordinateX), 2) + Math.Pow((item.CoordinateY - planet.CoordinateY), 2));
                Distanse.Add(item, distance);
            }
        }

    }
}