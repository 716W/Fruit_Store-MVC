using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Store.Core.DTOs
{
    class NewDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public String? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
