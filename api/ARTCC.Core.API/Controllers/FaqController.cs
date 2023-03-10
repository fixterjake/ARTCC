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
public class FaqController : ControllerBase
{
    private readonly FaqRepository _faqRepository;
    private readonly RedisService _redisService;
    private readonly IValidator<Faq> _faqValidator;
    private readonly IHub _sentryHub;

    public FaqController(FaqRepository faqRepository, RedisService redisService, IValidator<Faq> faqValidator, IHub sentryHub)
    {
        _faqRepository = faqRepository;
        _redisService = redisService;
        _faqValidator = faqValidator;
        _sentryHub = sentryHub;
    }

    [HttpPost]
    [Authorize(Roles = Constants.PERMISSION_CREATE_FAQ)]
    [ProducesResponseType(typeof(Response<Faq>), 201)]
    [ProducesResponseType(typeof(Response<IList<ValidationFailure>>), 400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(typeof(Response<string?>), 500)]
    public async Task<ActionResult<Response<Faq>>> CreateFaq(Faq data)
    {
        try
        {
            if (!await _redisService.ValidatePermissions(Request.HttpContext.User, new string[] { Constants.PERMISSION_CREATE_FAQ }))
                return StatusCode(401);

            var validation = await _faqValidator.ValidateAsync(data);
            if (!validation.IsValid)
            {
                return BadRequest(new Response<IList<ValidationFailure>>
                {
                    StatusCode = 400,
                    Message = "Validation failure",
                    Data = validation.Errors
                });
            }

            var result = await _faqRepository.CreateFaq(data, Request);
            return StatusCode(201, new Response<Faq>
            {
                StatusCode = 201,
                Message = $"Created faq '{result.Id}'",
                Data = result
            });
        }
        catch (Exception ex)
        {
            return _sentryHub.CaptureException(ex).ReturnActionResult();
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response<Faq>), 200)]
    [ProducesResponseType(typeof(Response<string?>), 404)]
    [ProducesResponseType(typeof(Response<string?>), 500)]
    public async Task<ActionResult<Response<Faq>>> GetFaq(int faqId)
    {
        try
        {
            var result = await _faqRepository.GetFaq(faqId);
            return Ok(new Response<Faq>
            {
                StatusCode = 200,
                Message = $"Got faq '{faqId}'",
                Data = result
            });
        }
        catch (FaqNotFoundException ex)
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
    [ProducesResponseType(typeof(Response<IList<Faq>>), 200)]
    [ProducesResponseType(typeof(Response<string?>), 404)]
    [ProducesResponseType(typeof(Response<string?>), 500)]
    public async Task<ActionResult<Response<Faq>>> GetFaqs()
    {
        try
        {
            var result = await _faqRepository.GetFaqs();
            return Ok(new Response<IList<Faq>>
            {
                StatusCode = 200,
                Message = $"Got {result.Count} faqs",
                Data = result
            });
        }
        catch (Exception ex)
        {
            return _sentryHub.CaptureException(ex).ReturnActionResult();
        }
    }

    [HttpPut]
    [Authorize(Roles = Constants.PERMISSION_UPDATE_FAQ)]
    [ProducesResponseType(typeof(Response<Faq>), 200)]
    [ProducesResponseType(typeof(Response<IList<ValidationFailure>>), 400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(typeof(Response<string?>), 404)]
    [ProducesResponseType(typeof(Response<string?>), 500)]
    public async Task<ActionResult<Response<Faq>>> UpdateFaq(Faq data)
    {
        try
        {
            if (!await _redisService.ValidatePermissions(Request.HttpContext.User, new string[] { Constants.PERMISSION_UPDATE_FAQ }))
                return StatusCode(401);

            var validation = await _faqValidator.ValidateAsync(data);
            if (!validation.IsValid)
            {
                return BadRequest(new Response<IList<ValidationFailure>>
                {
                    StatusCode = 400,
                    Message = "Validation failure",
                    Data = validation.Errors
                });
            }

            var result = await _faqRepository.UpdateFaq(data, Request);
            return StatusCode(200, new Response<Faq>
            {
                StatusCode = 200,
                Message = $"Updated faq '{result.Id}'",
                Data = result
            });
        }
        catch (FaqNotFoundException ex)
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
    [Authorize(Roles = Constants.PERMISSION_DELETE_FAQ)]
    [ProducesResponseType(typeof(Response<string?>), 200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(typeof(Response<string?>), 404)]
    [ProducesResponseType(typeof(Response<string?>), 500)]
    public async Task<ActionResult<Response<string?>>> DeleteFaq(int faqId)
    {
        try
        {
            if (!await _redisService.ValidatePermissions(Request.HttpContext.User, new string[] { Constants.PERMISSION_DELETE_FAQ }))
                return StatusCode(401);

            await _faqRepository.DeleteFaq(faqId, Request);

            return Ok(new Response<string?>
            {
                StatusCode = 200,
                Message = $"Deleted faq '{faqId}'"
            });
        }
        catch (FaqNotFoundException ex)
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
