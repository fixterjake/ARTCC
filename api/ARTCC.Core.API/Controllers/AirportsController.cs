using ARTCC.Core.API.Extensions;
using ARTCC.Core.API.Repositories;
using ARTCC.Core.API.Services;
using ARTCC.Core.Shared.Models;
using ARTCC.Core.Shared.Responses;
using ARTCC.Core.Shared.Utils;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sentry;
using Constants = ARTCC.Core.Shared.Utils.Constants;

namespace ARTCC.Core.API.Controllers;

[ApiController]
[Route("v1/[controller]")]
[Produces("application/json")]
public class AirportsController : ControllerBase
{
    private readonly AirportRepository _airportRepository;
    private readonly RedisService _redisService;
    private readonly IValidator<Airport> _airportValidator;
    private readonly IHub _sentryHub;

    public AirportsController(AirportRepository airportRepository, RedisService redisService, IValidator<Airport> airportValidator, IHub sentryHub)
    {
        _airportRepository = airportRepository;
        _redisService = redisService;
        _airportValidator = airportValidator;
        _sentryHub = sentryHub;
    }

    [HttpPost]
    [Authorize(Roles = Constants.PERMISSION_CREATE_COMMENT)]
    [ProducesResponseType(typeof(Response<Airport>), 201)]
    [ProducesResponseType(typeof(Response<IList<ValidationFailure>>), 400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(typeof(Response<string?>), 500)]
    public async Task<ActionResult<Response<Airport>>> CreateAirport(Airport data)
    {
        try
        {
            if (!await _redisService.ValidatePermissions(Request.HttpContext.User, new string[] { Constants.PERMISSION_CREATE_AIRPORT }))
                return StatusCode(401);

            var validation = await _airportValidator.ValidateAsync(data);
            if (!validation.IsValid)
            {
                return BadRequest(new Response<IList<ValidationFailure>>
                {
                    StatusCode = 400,
                    Message = "Validation failure",
                    Data = validation.Errors
                });
            }

            var result = await _airportRepository.CreateAirport(data, Request);
            return StatusCode(201, new Response<Airport>
            {
                StatusCode = 201,
                Message = $"Created airport '{result.Id}'",
                Data = result
            });
        }
        catch (Exception ex)
        {
            return _sentryHub.CaptureException(ex).ReturnActionResult();
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<Airport>), 200)]
    [ProducesResponseType(typeof(Response<string?>), 404)]
    [ProducesResponseType(typeof(Response<string?>), 500)]
    public async Task<ActionResult<Response<IList<Airport>>>> GetAirport(int airportId)
    {
        try
        {
            var result = await _airportRepository.GetAirport(airportId);
            return Ok(new Response<Airport>
            {
                StatusCode = 200,
                Message = $"Got airport '{result.Id}'",
                Data = result
            });
        }
        catch (AirportNotFoundException ex)
        {
            return NotFound(new Response<string?>
            {
                StatusCode = 404,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return _sentryHub.CaptureException(ex).ReturnActionResult();
        }
    }

    [HttpGet("All")]
    [ProducesResponseType(typeof(Response<IList<Airport>>), 200)]
    [ProducesResponseType(typeof(Response<string?>), 500)]
    public async Task<ActionResult<Response<IList<Airport>>>> GetAirports()
    {
        try
        {
            var result = await _airportRepository.GetAirports();
            return Ok(new Response<IList<Airport>>
            {
                StatusCode = 200,
                Message = $"Got {result.Count} airports",
                Data = result
            });
        }
        catch (Exception ex)
        {
            return _sentryHub.CaptureException(ex).ReturnActionResult();
        }
    }

    [HttpPut]
    [Authorize(Roles = Constants.PERMISSION_UPDATE_AIRPORT)]
    [ProducesResponseType(typeof(Response<Airport>), 200)]
    [ProducesResponseType(typeof(Response<IList<ValidationFailure>>), 400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(typeof(Response<string?>), 404)]
    [ProducesResponseType(typeof(Response<string?>), 500)]
    public async Task<ActionResult<Response<Airport>>> UpdateAirport(Airport data)
    {
        try
        {
            if (!await _redisService.ValidatePermissions(Request.HttpContext.User, new string[] { Constants.PERMISSION_UPDATE_AIRPORT }))
                return StatusCode(401);

            var validation = await _airportValidator.ValidateAsync(data);
            if (!validation.IsValid)
            {
                return BadRequest(new Response<IList<ValidationFailure>>
                {
                    StatusCode = 400,
                    Message = "Validation failure",
                    Data = validation.Errors
                });
            }

            var result = await _airportRepository.UpdateAirport(data, Request);
            return Ok(new Response<Airport>
            {
                StatusCode = 200,
                Message = $"Updated airport '{result.Id}'",
                Data = result
            });
        }
        catch (AirportNotFoundException ex)
        {
            return NotFound(new Response<string?>
            {
                StatusCode = 404,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return _sentryHub.CaptureException(ex).ReturnActionResult();
        }
    }

    [HttpDelete]
    [Authorize(Roles = Constants.PERMISSION_DELETE_AIRPORT)]
    [ProducesResponseType(typeof(Response<string?>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(typeof(Response<string?>), 404)]
    [ProducesResponseType(typeof(Response<string?>), 500)]
    public async Task<ActionResult<Response<string>>> DeleteAirport(int airportId)
    {
        try
        {
            if (!await _redisService.ValidatePermissions(Request.HttpContext.User, new string[] { Constants.PERMISSION_DELETE_AIRPORT }))
                return StatusCode(401);
            await _airportRepository.DeleteAirport(airportId, Request);
            return Ok(new Response<string?>
            {
                StatusCode = 200,
                Message = $"Deleted airport '{airportId}'"
            });
        }
        catch (AirportNotFoundException ex)
        {
            return NotFound(new Response<string?>
            {
                StatusCode = 404,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return _sentryHub.CaptureException(ex).ReturnActionResult();
        }
    }
}
