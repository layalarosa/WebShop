using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Game> GamesOfTheWeek { get; set; }
    }
}
