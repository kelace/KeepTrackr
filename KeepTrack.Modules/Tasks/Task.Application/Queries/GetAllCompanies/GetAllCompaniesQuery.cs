using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Queries.GetAllCompanies
{
    public class GetAllCompaniesQuery : IRequest<List<CompanyDto>>
    {
    }
}
