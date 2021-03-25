﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.Category
{
    public class CategoryEdit
    {
        public int CategoryId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(25, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }

    }
}
