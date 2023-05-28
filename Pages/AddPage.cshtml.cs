using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KatalogSamochodowy.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace KatalogSamochodowy.Pages
{
    public class AddPageModel : PageModel
    {
        private readonly ApplicationDbContext _db;
     
        public AddPageModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Samochod Samochod { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(IFormFile[] photos)
        {
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

                    Samochod.CarPhoto = photo.FileName;
                }
            }
            else
                Samochod.CarPhoto = "brakzdjecia.png";
           

            _db.Add(Samochod);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");

            
        }

            
    }
}
