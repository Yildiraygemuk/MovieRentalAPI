using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int OperationClaimId { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
