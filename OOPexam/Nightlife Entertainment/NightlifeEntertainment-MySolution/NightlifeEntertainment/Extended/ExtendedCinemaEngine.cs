﻿namespace NightlifeEntertainment.Extended
{
    using System;
    using System.Linq;

    using NightlifeEntertainment.Extended.Performances;
    using NightlifeEntertainment.Extended.Tickets;
    using NightlifeEntertainment.Extended.Venues;

    internal class ExtendedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            IVenue venue;
            switch (commandWords[2])
            {
                case "opera":
                    venue = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(venue);
                    break;
                case "sports_hall":
                    venue = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(venue);
                    break;
                case "concert_hall":
                    venue = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(venue);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            IVenue venue;
            switch (commandWords[2])
            {
                case "theatre":
                    venue = this.GetVenue(commandWords[5]);
                    var theatre = new Theatre(
                        commandWords[3], 
                        decimal.Parse(commandWords[4]), 
                        venue, 
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    venue = this.GetVenue(commandWords[5]);
                    var consert = new Concert(
                        commandWords[3], 
                        decimal.Parse(commandWords[4]), 
                        venue, 
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(consert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[3]);
            switch (commandWords[1])
            {
                case "student":
                    for (var i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }

                    break;
                case "vip":
                    for (var i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VIPticket(performance));
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
            var soldTickets = performance.Tickets.Where(t => t.Status == TicketStatus.Sold);

            //////Dracula: 4 ticket(s), total: $48.00
            //////Venue: Arena (Sofia-Mladost)
            //////Start time: 12/10/2014 20:00:00
            this.Output.AppendFormat(
                "{0}: {1} ticket(s), total: ${2:F2}", 
                performance.Name, 
                soldTickets.Count(), 
                soldTickets.Sum(t => t.Price)).AppendLine();
            this.Output.AppendFormat("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location)
                .AppendLine();
            this.Output.AppendFormat("Start time: {0}", performance.StartTime).AppendLine();
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            //////Search for "conCERt"
            //////Performances:
            //////-SlaviTrifonovConcert
            //////-RadoShisharkataConcert
            //////Venues:
            //////-ConcertHallNDK
            //////--SlaviTrifonovConcert
            //////--TarjaTurunen
            //////-OtherConcertHall
            var searchFrase = commandWords[1];
            var searchFraseLower = searchFrase.ToLower();
            var searchDate = DateTime.Parse(commandWords[2] + " " + commandWords[3]);
            this.Output.AppendFormat("Search for \"{0}\"", searchFrase).AppendLine();
            this.FindPerfomances(searchFraseLower, searchDate);
            this.FindVanues(searchFraseLower, searchDate);
        }

        private void FindVanues(string searchFrase, DateTime searchDate)
        {
            this.Output.AppendLine("Venues:");
            var foundVenues = this.Venues.Where(p => p.Name.ToLower().Contains(searchFrase)).OrderBy(v => v.Name);
            if (foundVenues.Any())
            {
                foreach (var venue in foundVenues)
                {
                    this.Output.AppendFormat("-{0}", venue.Name).AppendLine();
                    this.FindPerfomances(venue, searchDate);
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }
        }

        private void FindPerfomances(string searchFrase, DateTime searchDate)
        {
            var foundPerfomances = this.Performances.Where(
                p => p.Name.ToLower().Contains(searchFrase) && p.StartTime.CompareTo(searchDate) >= 0)
                .OrderBy(p => p.StartTime)
                .ThenByDescending(p => p.BasePrice)
                    .ThenBy(p => p.Name);
            this.Output.AppendLine("Performances:");
            if (foundPerfomances.Any())
            {
                foreach (var peformance in foundPerfomances)
                {
                    this.Output.AppendFormat("-{0}", peformance.Name).AppendLine();
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }
        }

        private void FindPerfomances(IVenue venue, DateTime searchDate)
        {
            var foundPerfomances = this.Performances.Where(p => p.Venue == venue && p.StartTime.CompareTo(searchDate) >= 0)
                .OrderBy(p => p.StartTime)
                .ThenByDescending(p => p.BasePrice)
                    .ThenBy(p => p.Name);
            if (foundPerfomances.Any())
            {
                foreach (var peformance in foundPerfomances)
                {
                    this.Output.AppendFormat("--{0}", peformance.Name).AppendLine();
                }
            }
        }
    }
}