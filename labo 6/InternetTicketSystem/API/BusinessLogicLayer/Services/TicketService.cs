using AutoMapper;
using InternetTicketSystem.Data.Entities;
using InternetTicketSystem.Data.Repository;
using InternetTicketSystem.Exceptions;
using InternetTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InternetTicketSystem.Services
{
    public class TicketsService : ITicketsService
    {
        private ILibraryRepository _libraryRepository;
        private IMapper _mapper;

        public TicketsService(ILibraryRepository libraryRepository, IMapper _mapper)
        {
            this._libraryRepository = libraryRepository;
            this._mapper = _mapper;
        }

        public IEnumerable<TicketModel> GetTickets()
        {
            var entityList= _libraryRepository.GetTickets();
            var modelList = _mapper.Map<IEnumerable<TicketModel>>(entityList);
            return modelList;
        }
        public TicketModel GetTicket(int TicketId)
        {
            var Ticket = _libraryRepository.GetTicket(TicketId);

            if (Ticket == null)
            {
                throw new NotFoundException($"The Ticket {TicketId} doesnt exists, try it with a new id");
            }

            return _mapper.Map<TicketModel>(Ticket);
        }
      
        public TicketModel CreateTicket(TicketModel TicketModel)
        {

            var entityreturned=_libraryRepository.CreateTicket(_mapper.Map<TicketEntity>(TicketModel));
            
            return _mapper.Map<TicketModel>(entityreturned);
        }

        public bool DeleteTicket(int TicketId)
        {
            var TicketToDelete = GetTicket(TicketId);
            return _libraryRepository.DeleteTicket(TicketId);
        }

        public TicketModel UpdateTicket(int TicketId, TicketModel TicketModel)
        {
            
            var TicketToUpdate=_libraryRepository.UpdateTicket(_mapper.Map<TicketEntity>(TicketModel));

            return _mapper.Map<TicketModel>(TicketToUpdate);
        }
    }
}
