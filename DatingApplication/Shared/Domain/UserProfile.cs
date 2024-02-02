using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.Shared.Domain
{
    public class UserProfile: BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage ="Invalid Entry")]
        public string? Hobby { get; set; }
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage = "Invalid Animal")]
        public string? FavouriteAnimal { get; set; }
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage ="Description is too short")]
        public string? DatingAppUserDescription { get; set; }
        public float Height { get; set; }
        public float Weigth { get; set; }
        public int DatingAppUserId { get; set; }
        public virtual DatingAppUser? DatingAppUser { get; set; }
    }
}
