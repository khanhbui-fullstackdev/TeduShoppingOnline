﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Model.Abstracts;

namespace TeduShopingOnline.Model.Models
{
    [Table("PostCategories")]
    public class PostCategory : Audit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public int ParentId { get; set; }

        public int DisplayOrder { get; set; }

        public string Image { get; set; }

        public bool HomeFlag { get; set; }
    }
}
