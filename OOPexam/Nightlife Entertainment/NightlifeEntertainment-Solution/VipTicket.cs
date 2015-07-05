using System;

namespace NightlifeEntertainment
{
    public class VipTicket : Ticket
    {
        public VipTicket(IPerformance performance)
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            decimal basePrice = base.CalculatePrice();
            return basePrice * 1.5m;
        }
    }
}
