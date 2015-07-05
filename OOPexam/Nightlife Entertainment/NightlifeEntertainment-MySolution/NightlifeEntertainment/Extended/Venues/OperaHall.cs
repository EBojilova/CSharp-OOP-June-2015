namespace NightlifeEntertainment.Extended.Venues
{
    using System.Collections.Generic;

    internal class OperaHall : Venue
    {
        public OperaHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Opera, PerformanceType.Theatre })
        {
        }
    }
}