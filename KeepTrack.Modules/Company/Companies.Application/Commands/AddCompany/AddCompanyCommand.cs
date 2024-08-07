using Companies.Domain;
using Companies.Domain.Results;
using KeepTrack.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companies.Application.Commands.AddCompany
{
    public class AddCompanyCommand : IRequest<Result<Company, KeepTrack.Common.Error>>, IApplicationCommand
    {
        public string Name { get; set; }
    }
}
