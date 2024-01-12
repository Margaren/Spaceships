namespace SpaceFleetDispatcher
{  
    public abstract class ASpaceship
    {
        public string Name { get; protected set; }
        public int Capacity { get; protected set; }
        public bool Full {  get; protected set; }

        public ASpaceship(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public static ASpaceship Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new NullReferenceException("Входные данные пусты");

            var resources = input.Split(new[] { "\t", " " },
              StringSplitOptions.RemoveEmptyEntries);
            int capacity;

            if (resources.Length != 3)
                throw new InvalidDataException("Формат некорректный");
            if (!int.TryParse(resources[1], out capacity) || capacity < 0)
                throw new Exception("Вместимость корабля неверная");

            var shipType = resources[0];
            var name = resources[2];

            if (shipType.Equals("LongRange",
                StringComparison.InvariantCultureIgnoreCase))
                return new LongRangeShip(name, capacity);
            if (shipType.Equals("MiddleRange",
                StringComparison.InvariantCultureIgnoreCase))
                return new MiddleRangeShip(name, capacity);
            if (shipType.Equals("NearRange",
                StringComparison.InvariantCultureIgnoreCase))
                return new NearRangeShip(name, capacity);

            throw new InvalidDataException($"Тип {shipType} не поддерживается");
        }

        public override string ToString()
        {
            return $"Корабль \"{Name}\", "
              + $"тип корабля {this.GetType().Name}\t" +
              $"вместимость: {Capacity}, "
              + $"дальность хода: {GetRange()}";
        }
        public abstract double GetRange();
    }

}