using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Dtos.CategoriesDtos
{
    public class CreateOrUpdateCategoryDto
    {
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
    }
}
