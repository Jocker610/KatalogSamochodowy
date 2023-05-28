using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KatalogSamochodowy.Model;
using System.IO;



namespace KatalogSamochodowy.Pages
{
    public class przegladModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //[BindProperty]
        //public  Samochod Samochod { get; set; }

        public IEnumerable<Samochod> Samochod { get; set; }
        public przegladModel (ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGet ()
        {
            Samochod = await _db.Samochod.ToListAsync();
        }


        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var samochod = await _db.Samochod.FindAsync(Id);
            if (samochod == null)
            {
                return NotFound();
            }

            _db.Samochod.Remove(samochod);

            await _db.SaveChangesAsync();
            if (samochod.CarPhoto != null)
            {
                string saveplace = Path.Combine(Environment.CurrentDirectory, "wwwroot", "lib");
                string filePath = Path.Combine(saveplace, samochod.CarPhoto);
                System.IO.File.Delete(filePath);
            }
            

            return RedirectToPage("/przeglad");
        }

    }
}
