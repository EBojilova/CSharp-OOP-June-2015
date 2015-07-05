namespace NightlifeEntertainment.Extended.Tickets
{
    using System;

    internal class StudentTicket : Ticket
    {
        private const decimal StudentDiscount = 20;

        public StudentTicket(IPerformance performance)
            : base(performance, TicketType.Student)
        {
        }

        protected override decimal CalculatePrice()
        {
            if (this.Performance == null)
            {
                throw new ArgumentException(
                    "The price cannot be calculated because there is no performance for this ticket.");
            }

            return this.Performance.BasePrice * (100 - StudentDiscount) / 100;
        }
    }
}