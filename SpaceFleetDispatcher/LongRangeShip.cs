namespace SpaceFleetDispatcher
{
    internal class LongRangeShip:ASpaceship
    {
        public LongRangeShip(string name, int capacity) : base(name, capacity) { }

        public override double GetRange()
        {
            return 2.0;
        }
    }
}
