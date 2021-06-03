using Microsoft.AspNetCore.Mvc;
using InternetTicketSystem.Models;
using InternetTicketSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using InternetTicketSystem.Exceptions;
using Microsoft.AspNetCore.Http;

namespace InternetTicketSystem.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private ITicketsService _Ticketservice;
        public TicketsController(ITicketsService Ticketservice)
        {
            _Ticketservice = Ticketservice;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TicketModel>> GetTickets()
        {
            try
            {
                return Ok(_Ticketservice.GetTickets());
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }

        }
        [HttpGet("{TicketId:int}", Name="GetTicket")]
        public ActionResult<TicketModel> GetTicket(int TicketId)
        {
            try
            {
                return Ok(_Ticketservice.GetTicket(TicketId));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult<TicketModel> CreateTicket([FromBody] TicketModel TicketModel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(TicketModel);
                }
                var url = HttpContext.Request.Host;
                var createdTicket = _Ticketservice.CreateTicket(TicketModel);
                return CreatedAtRoute("GetTicket",new { TicketId=createdTicket.Id},createdTicket);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
       
       [HttpDelete("{TicketId:int}")]
       public ActionResult<bool> DeleteTicket(int TicketId)
        {
            try
            {
                return Ok(_Ticketservice.DeleteTicket(TicketId));
            }
            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPut("{TicketId:int}")]
        public ActionResult<TicketModel> UpdateTicket(int TicketId, [FromBody] TicketModel TicketModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(TicketModel.Owner) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }
                return _Ticketservice.UpdateTicket(TicketId, TicketModel);
            }

            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
       
    }
}
