﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public bool IsUserOwned { get; set; }
    }
}
