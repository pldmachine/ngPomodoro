

using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ngP_Web.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {

        public EFContext _context { get; }

        public ItemController(EFContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<Item> Items()
        {
            return _context.Items.ToList();
        }
    }
}