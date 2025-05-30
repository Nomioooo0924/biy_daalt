﻿using System.ComponentModel.DataAnnotations;

namespace hoolsitebiydaalt.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Хувцасны нэрийг оруулна уу")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Хувцасны тайлбарыг оруулна уу")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Хувцасны үнийг оруулна уу")]
        [Range(0, 100000, ErrorMessage = "Үнэ 0-100000 хооронд байх ёстой")]
        public decimal Price { get; set; }

        [StringLength(100)]
        public string Category { get; set; }

      
    }
}
