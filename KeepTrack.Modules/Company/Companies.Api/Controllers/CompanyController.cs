using Companies.Application.Commands.AddCompany;
using Companies.Application.Queries.GetAllCompanies;
using Companies.Domain;
using Companies.Domain.Results;
using KeepTrack.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Companies.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CompanyDto>> Get()
        {
            return await _mediator.Send<List<CompanyDto>>(new GetAllCompaniesQuery());
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddCompanyCommand command)
        {
            var result = await _mediator.Send<Result<Company, Error>>(command);

            IActionResult SuccessResult(Company company)
            {
                return Ok(new {status = true ,message = $"company {company.Name} succesfully been created"});
            }

            IActionResult ErrorResult(Error error)
            {
                return Ok(new { status = false, error = error });
            }

            return result.Match<IActionResult>(SuccessResult, ErrorResult);
        }

    }
}
