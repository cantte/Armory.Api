using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Ammunition.Requests;
using Armory.Armament.Ammunition.Application;
using Armory.Armament.Ammunition.Application.CheckExists;
using Armory.Armament.Ammunition.Application.Create;
using Armory.Armament.Ammunition.Application.Find;
using Armory.Armament.Ammunition.Application.SearchAll;
using Armory.Armament.Ammunition.Application.SearchAllByFlight;
using Armory.Armament.Ammunition.Application.Update;
using Armory.Armament.Ammunition.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Armament.Ammunition
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AmmunitionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AmmunitionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAmmunition([FromBody] CreateAmmunitionRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateAmmunitionCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckAmmunitionExistsQuery(request.Lot));
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("AmmunitionAlreadyRegistered",
                    $"Ya existe una munición con el lote '{request.Lot}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        private NotFoundObjectResult AmmunitionNotFound(string code)
        {
            ModelState.AddModelError("AmmunitionNotFound",
                $"No se encontró ninguna munición con el código '{code}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmmunitionResponse>>> GetAmmunition()
        {
            var ammunition = await _mediator.Send(new SearchAllAmmunitionQuery());
            return Ok(ammunition);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<AmmunitionResponse>> GetAmmunition(string code)
        {
            var ammunition = await _mediator.Send(new FindAmmunitionQuery(code));
            if (ammunition != null)
            {
                return Ok(ammunition);
            }

            return AmmunitionNotFound(code);
        }

        [HttpGet("ByFlight/{flightCode}")]
        public async Task<ActionResult<IEnumerable<AmmunitionResponse>>> GetAmmunitionByFlight(string flightCode)
        {
            var ammunition = await _mediator.Send(new SearchAllAmmunitionByFlightQuery { FlightCode = flightCode });
            return Ok(ammunition);
        }

        [HttpGet("Exists/{code}")]
        public async Task<ActionResult<bool>> CheckExists(string code)
        {
            var exists = await _mediator.Send(new CheckAmmunitionExistsQuery(code));
            return Ok(exists);
        }

        [HttpPut("{lot}")]
        public async Task<ActionResult> UpdateAmmunition(string lot, [FromBody] UpdateAmmunitionRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateAmmunitionCommand>(request);
                command.Lot = lot;
                await _mediator.Send(command);
            }
            catch (AmmunitionNotFoundException)
            {
                return AmmunitionNotFound(lot);
            }

            return Ok();
        }
    }
}
