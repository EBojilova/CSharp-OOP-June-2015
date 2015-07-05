using System;
using System.Collections.Generic;
using System.Linq;

namespace NightlifeEntertainment
{
    public class ExtendedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var operaHall = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(operaHall);
                    break;
                case "sports_hall":
                    var sportsHall = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[5]);
            switch (commandWords[2])
            {
                case "theatre":
                    var theatre = new Theatre(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        venue,
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concert = new Concert(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        venue,
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[2]);
            var performance = this.GetPerformance(commandWords[3]);
            switch (commandWords[1])
            {
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }

                    break;
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VipTicket(performance));
                    }

                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[1]);
            var ticketsSold = performance.Tickets.Where(t => t.Status == TicketStatus.Sold);
            decimal totalPrice = ticketsSold.Sum(t => t.Price);

            this.Output.AppendFormat("{0}: {1} ticket(s), total: ${2:F2}", performance.Name, ticketsSold.Count(), totalPrice)
              .AppendLine()
              .AppendFormat("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location)
              .AppendLine()
              .AppendFormat("Start time: {0}", performance.StartTime)
              .AppendLine();
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            string searchWord = commandWords[1];
            DateTime currentTime = DateTime.Parse(commandWords[2] + " " + commandWords[3]);
            var foundPerformances = this.FindPerformances(currentTime)
              .Where(p => p.Name.ToLower().Contains(searchWord.ToLower()));

            var foundVenues = this.Venues
              .Where(v => v.Name.ToLower().Contains(searchWord.ToLower()))
              .OrderBy(v => v.Name);

            this.PrintFindResults(foundPerformances, foundVenues, searchWord, currentTime);
        }

        private IEnumerable<IPerformance> FindPerformances(DateTime currentTime)
        {
            return this.Performances
              .Where(p => p.StartTime >= currentTime)
              .OrderBy(p => p.StartTime)
              .ThenByDescending(p => p.BasePrice)
              .ThenBy(p => p.Name);
        }

        private void PrintFindResults(IEnumerable<IPerformance> foundPerformances, IEnumerable<IVenue> foundVenues, string searchWord, DateTime currentTime)
        {
            this.Output.AppendLine("Search for \"" + searchWord + "\"")
                .AppendLine("Performances:");
            if (foundPerformances.Any())
            {
                string performanceResults = string.Join(Environment.NewLine, foundPerformances.Select(p => "-" + p.Name));
                this.Output.AppendLine(performanceResults);
            }
            else
            {
                this.Output.AppendLine("no results");
            }

            this.Output.AppendLine("Venues:");
            if (foundVenues.Any())
            {
                foreach (var venue in foundVenues)
                {
                    this.Output.AppendLine("-" + venue.Name);
                    var foundPerformancesInVenue = this.FindPerformances(currentTime)
                      .Where(p => p.Venue == venue);
                    if (foundPerformancesInVenue.Any())
                    {
                        this.Output.AppendLine(string.Join(Environment.NewLine, foundPerformancesInVenue.Select(p => "--" + p.Name)));
                    }
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }
        }
    }
}
