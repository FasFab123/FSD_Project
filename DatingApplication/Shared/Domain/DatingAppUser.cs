using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.Shared.Domain
{
    public class DatingAppUser : BaseDomainModel
    {
        public DatingAppUser() 
        { 
        this.DatingAppUserInitiatorMatch = new HashSet<Match>();
        this.DatingAppUserRecieverMatch = new HashSet<Match>();
        }
        [Required]
        [StringLength(100, MinimumLength = 3,ErrorMessage = "Name is too short")]
        public string Username { get; set; }
        [Required]
        [Range(18, 99, ErrorMessage = "You must be at least 18 years old")]
        public int Age { get; set; }
        public string? Gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invailid Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password is too short")]
        public string Password { get; set; }
        public string? profile_picture_url { get; set; }
        public virtual List<UserProfile> UserProfiles { get; set; }
        public virtual List<Match> Matches { get; set; }
        [InverseProperty("DatingAppUserInitiator")]
        public virtual ICollection<Match> DatingAppUserInitiatorMatch { get; set; }
        [InverseProperty("DatingAppUserReciever")]
        public virtual ICollection<Match> DatingAppUserRecieverMatch {  get; set; }
        


    }
}
