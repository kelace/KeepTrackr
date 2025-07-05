using KeepTrack.Common;
using KeepTrackr.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executing.Domain.PermissionAggregate
{
    public class Permission : EntityBaseWithCustomId, IAggregateRoot
    {
        public PermissionId Id { get; set; }
    }
}
