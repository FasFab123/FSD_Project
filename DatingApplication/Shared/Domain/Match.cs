using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.Shared.Domain
{
    public class Match : BaseDomainModel
    {
        [ForeignKey("DatingAppUserInitiator")]
        public int? DatingAppUserInitiatorId { get; set; }
        [ForeignKey("DatingAppUserReciever")]
        public int? DatingAppUserRecieverId { get; set; }
        public virtual DatingAppUser? DatingAppUserInitiator { get; set; }
        public virtual DatingAppUser? DatingAppUserReciever { get; set; }
    }
}
