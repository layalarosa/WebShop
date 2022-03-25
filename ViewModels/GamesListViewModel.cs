using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.ViewModels
{
    public class GamesListViewModel
    {
        public IEnumerable<Game> Games { get; set; }
        public string CurrentCategory { get; set; }
    }
}
