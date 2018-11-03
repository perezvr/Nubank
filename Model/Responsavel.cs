﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Responsavel")]
    public class Responsavel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
