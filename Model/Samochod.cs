using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations.Schema;

namespace KatalogSamochodowy.Model
{
    public class Samochod
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Marka")]
        [Required (ErrorMessage ="Pole jest wymagane!")]
        public string BrandName { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Pole jest wymagane!")]
        public string ModelName { get; set; }
        
        [Required(ErrorMessage = "Pole jest wymagane!")]
        public string Segment { get; set; }

        [Display(Name = "Typ nadwozia")]
        [Required(ErrorMessage = "Pole jest wymagane!")]
        public string BodyType { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Pole jest wymagane!")]
        public string Description { get; set; }

        [Range(1, 99999999999,
        ErrorMessage = "Konie mechaniczne nie mogą być ujemne!")]
        [Display(Name = "Konie mechaniczne")]
        [Required(ErrorMessage = "Pole jest wymagane!")]
        public int Horsepower { get; set; }

        [Range(0, 99999999999,
        ErrorMessage = "Cena nie może być ujemna!")]
        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Pole jest wymagane!")]
        public int Price { get; set; }

        [Range(1945, 2022,
        ErrorMessage = "W katalogu mogą znajdować się tylko samochody z lat pomiędzy 1945 a 2022!")]
        [Display(Name = "Rok produkcji")]
        [Required(ErrorMessage = "Pole jest wymagane!")]
        public int YearOfProduction { get; set; }

        [Display(Name = "Zdjęcia")]
        [Required(ErrorMessage = "Proszę wybrać zdjęcie!")]
        public string CarPhoto { get; set; }

       
        


    }
}
