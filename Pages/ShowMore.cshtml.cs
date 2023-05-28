using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KatalogSamochodowy.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KatalogSamochodowy.Pages
{
    public class ShowMoreModel : PageModel
    {
        private ApplicationDbContext _db;
        [BindProperty]
        public Samochod Samochod { get; set; }
        public ShowMoreModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int Id)
        {
            Samochod = _db.Samochod.Find(Id);
        }
    }
}
