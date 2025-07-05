using KeepTrack.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain.UserAggregate
{
    public class Permission : EntityBase
    {
        public List<PermissionType> PermissionTypes { get; set; }
        public Guid UserId { get; set; }

        public Permission(List<PermissionType> permissionTypes)
        {
            PermissionTypes = permissionTypes;
        }

        public bool CanRemove()
        {
            return PermissionTypes.Contains(PermissionType.RemoveColumn);
        }

        public static Permission CreateOwnerPermission()
        {
            var list = new List<PermissionType>()
            {
                PermissionType.AddColumn,
                PermissionType.EditColumn,
                PermissionType.MoveColumn,
                PermissionType.RemoveColumn,
                PermissionType.AddCard,
                PermissionType.EditCard,
                PermissionType.MoveCard,
                PermissionType.RemoveCard,
                PermissionType.AddLabel,
            };
            return new Permission(list);
        }
    }

    public enum PermissionType
    {
        AddColumn,
        EditColumn,
        MoveColumn,
        RemoveColumn,

        AddCard,
        EditCard,
        MoveCard,
        RemoveCard,

        AddLabel,
        //...
    }
}
