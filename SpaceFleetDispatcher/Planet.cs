namespace SpaceFleetDispatcher
{
    public class Planet
    {
        public string Name { get; protected set; }
        public double NeedCargo { get; protected set; }
        public double CoordinateX { get; protected set; }
        public double CoordinateY { get; protected set; }
        public Planet(string name, double needCargo, double coordX, double coordY)
        {
            Name = name;
            NeedCargo = needCargo;
            CoordinateX = coordX;
            CoordinateY = coordY;
        }
        public override string ToString()
        {
            return $"Название планеты: {Name}, " +
                $"Количество необходимого продукта: {NeedCargo}, " +
                $"Координаты (x,y)  {CoordinateX}\t{CoordinateY}";
        }
        public static Planet Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new NullReferenceException("Ошибка! Данные не введены");


            var resources = input.Split(new[] { "\t", " " },
              StringSplitOptions.RemoveEmptyEntries);
            double needCargo;
            if (resources.Length != 4)
                throw new InvalidDataException("Ошибка! Данные введены неверно");
            if (!double.TryParse(resources[3], out needCargo) || needCargo < 0)
                throw new InvalidDataException("Ошибка! Количество необходимого груза введено неверно");
            var planetName = resources[0];
            var coordinateX = resources[1];
            var coordinateY = resources[2];
            return new Planet(planetName, needCargo, double.Parse(coordinateX), double.Parse(coordinateY));
        }
    }
}
