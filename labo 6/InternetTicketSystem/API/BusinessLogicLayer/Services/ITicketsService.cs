using InternetTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTicketSystem.Services
{
    public interface ITicketsService
    {
        public IEnumerable<TicketModel> GetTickets();
        public TicketModel GetTicket(int TicketId);
        public TicketModel CreateTicket(TicketModel TicketModel);
        public bool DeleteTicket(int TicketId);
        public TicketModel UpdateTicket(int TicketId, TicketModel TicketModel);
    }
}
