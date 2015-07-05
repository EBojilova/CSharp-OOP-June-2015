namespace NightlifeEntertainment.Extended.Tickets
{
    using System;

    internal class VIPticket : Ticket
    {
        private const decimal VipCharge = 1.5m;
        
        public VIPticket(IPerformance performance)
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            if (this.Performance == null)
            {
                throw new ArgumentException(
                    "The price cannot be calculated because there is no performance for this ticket.");
            }

            return this.Performance.BasePrice * VipCharge;
        }
    }
}