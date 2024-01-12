namespace SpaceFleetDispatcher
{
    internal class NearRangeShip : ASpaceship
    {
        public NearRangeShip(string name, int capacity) : base(name, capacity) { }

        public override double GetRange()
        {
            return 30.0;
        }
    }
}
