using InternetTicketSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace InternetTicketSystem.Data.Repository
{
    public interface ILibraryRepository
    {
        public IEnumerable<TicketEntity> GetTickets();
        public TicketEntity GetTicket(int TicketId);
        public TicketEntity CreateTicket(TicketEntity TicketEntity);
        public bool DeleteTicket(int TicketId);
        public TicketEntity UpdateTicket(TicketEntity TicketEntity);

    }
}
