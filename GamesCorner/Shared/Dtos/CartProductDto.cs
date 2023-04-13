using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesCorner.Shared.DTOs;

namespace GamesCorner.Shared.Dtos
{
    public class CartProductDto
    {
        public string Id { get; set; }
        public ProductModelDto? Product{ get; set; }
        public int Amount { get; set; }
    }
}
