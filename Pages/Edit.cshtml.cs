using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KatalogSamochodowy.Model;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace KatalogSamochodowy.Pages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        

        [BindProperty]
        public Samochod Samochod { get; set; }

        public void OnGet(int Id)
        {
            Samochod = _db.Samochod.Find(Id);
        }

        public async Task<IActionResult> OnPostAsync(IFormFile[] photos, int Id)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var SamochodFromDb = await _db.Samochod.FindAsync(Samochod.Id);

            if (SamochodFromDb.CarPhoto != null)
            {
                string saveplace = Path.Combine(Environment.CurrentDirectory, "wwwroot", "lib");
                string filePath = Path.Combine(saveplace, SamochodFromDb.CarPhoto);
                System.IO.File.Delete(filePath);
            }

            SamochodFromDb.BrandName = Samochod.BrandName;
            SamochodFromDb.ModelName = Samochod.ModelName;
            SamochodFromDb.Segment = Samochod.Segment;
            SamochodFromDb.BodyType = Samochod.BodyType;
            SamochodFromDb.Description = Samochod.Description;
            SamochodFromDb.Horsepower = Samochod.Horsepower;
            SamochodFromDb.Price = Samochod.Price;
            SamochodFromDb.YearOfProduction = Samochod.YearOfProduction;

            if (photos != null && photos.Length > 0)
            {
                foreach (var photo in photos)
                {
                    string saveplace = Path.Combine(Environment.CurrentDirectory, "wwwroot", "lib");
                    string filePath = Path.Combine(saveplace, photo.FileName);

                    using (var file = System.IO.File.Create(filePath))
                    {
                        await photo.CopyToAsync(file);
                    }

                    SamochodFromDb.CarPhoto = photo.FileName;
                }
            }
            else
            {
                Samochod.CarPhoto = "brakzdjecia.png";
            }

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
