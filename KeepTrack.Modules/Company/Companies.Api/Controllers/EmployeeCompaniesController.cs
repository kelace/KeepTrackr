using Companies.Application.Queries.GetAllCompanies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Companies.Api.Controllers
{
    [Route("api/employee/companies")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer") ]
    public class EmployeeCompaniesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public EmployeeCompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CompanyDto>> Get(GetAllCompaniesQuery command)
        {
            return await _mediator.Send<List<CompanyDto>>(command);
        }
    }
}
