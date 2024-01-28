using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.Shared.Domain
{
    public class Chat: BaseDomainModel
    {
        public string MessageText { get; set; }
        public DateTime ChatTimeStamp { get; set; }
        public string DatingAppUserMessage {  get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}
