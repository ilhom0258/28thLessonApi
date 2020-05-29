using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class Quote
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Текст обязателен")]
        public string Text { get; set; }

        public string Author { get; set; }

        [Required]
        [Timestamp]
        public DateTime InsertDate { get; set; }

    }
}
