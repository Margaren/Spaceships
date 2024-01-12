namespace SpaceFleetDispatcher
{
    internal class MiddleRangeShip:ASpaceship
    {
        public MiddleRangeShip(string name, int capacity) : base(name, capacity) { }

        public override double GetRange()
        {
            return 6.0;
        }
    }
}
