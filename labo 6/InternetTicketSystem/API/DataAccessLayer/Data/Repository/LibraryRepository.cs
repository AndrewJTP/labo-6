using InternetTicketSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace InternetTicketSystem.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private List<TicketEntity> Tickets = new List<TicketEntity>(){
            new TicketEntity(){Id=1,Owner="Pepe",DepartureTime=new DateTime(2021,01,01)},
            new TicketEntity(){Id=2,Owner="Juan",DepartureTime=new DateTime(2021,01,01)},
            new TicketEntity(){Id=3,Owner="Maria",DepartureTime=new DateTime(2021,01,01)},
            new TicketEntity(){Id=4,Owner="Lucas",DepartureTime=new DateTime(2021,01,01)}
        };
        public TicketEntity GetTicket(int TicketId)
        {
            return Tickets.FirstOrDefault(c => c.Id == TicketId);
        }
        public TicketEntity CreateTicket(TicketEntity TicketEntity)
        {
            int TicketId;
            if (Tickets.Count() == 0)
            {
                TicketId = 1;
            }
            else
            {
                TicketId = Tickets.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            }
            TicketEntity.Id = TicketId;
            Tickets.Add(TicketEntity);
            return TicketEntity;
        }

        public bool DeleteTicket(int TicketId)
        {
            var TicketToDelete = GetTicket(TicketId);
            Tickets.Remove(TicketToDelete);
            return true;
        }

        public IEnumerable<TicketEntity> GetTickets()
        {
            return Tickets;
        }

        public TicketEntity UpdateTicket(TicketEntity TicketEntity)
        {
            var TickettoUpdate = GetTicket(TicketEntity.Id);
            TickettoUpdate.Owner = TicketEntity.Owner ?? TickettoUpdate.Owner;
            TickettoUpdate.DepartureTime = TicketEntity.DepartureTime ?? TickettoUpdate.DepartureTime;
            TickettoUpdate.Chair = TicketEntity.Chair ?? TickettoUpdate.Chair;
            return TickettoUpdate;
        }
    }
}
