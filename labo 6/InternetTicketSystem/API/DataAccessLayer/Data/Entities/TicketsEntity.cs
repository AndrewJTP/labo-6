using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InternetTicketSystem.Data.Entities
{
    public class TicketEntity
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public DateTime? DepartureTime { get; set; }
        public enum TypeOfChair { Leito, Cama, Semicama};
        public TypeOfChair? Chair { get; set; }
    }
}
