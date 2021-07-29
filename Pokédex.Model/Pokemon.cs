using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokédex.Model
{
    [Table("Pokemon")]
    public class Pokemon : BaseModel
    {
        [Key]
        public int PokemonId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string Name { get; set; }

        public string Gender { get; set; }

        public string ImagePath { get; set; }

        [NotMapped]
        [DisplayName("Image")]
        public IFormFile ImageFormFile { get; set; }
    }
}
