using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  TaskManagment.Domain
{
    public static class Errors
    {
        public static Error EmployerLabelCreation => new("EmployerLabelCreationError", "Only employer is allowed to create label");
    }
}
