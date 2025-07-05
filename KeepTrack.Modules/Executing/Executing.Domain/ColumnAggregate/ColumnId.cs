using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain.ColumnAggregate
{
    public class ColumnId
    {
        public Guid Value { get; private set; }


        //public override bool Equals(Guid guid)
        //{
        //    return Value == guid;
        //}

        //public override bool Equals(object obj)
        //{
        //    return Equals((Guid)obj);
        //}

        //public bool Equals(Guid guid)
        //{
        //     return Value == guid;
        //}

        //public static bool operator ==(Guid id)
        //{
        //    return true;
        //}

        //public static bool operator !=(Guid id)
        //{
        //    return true;
        //}

        //public static bool operator >(Guid id)
        //{
        //    return true;
        //}

        //public static bool operator <(Guid id)
        //{
        //    return true;
        //}

        //public static bool operator <=(Guid id)
        //{
        //    return true;
        //}

        //public static bool operator >=(Guid id)
        //{
        //    return true;
        //}
    }
}
