using System.Collections;
using BoltaShop.Models.Base;
using BoltaShop.Models.Dto;
using BoltaShop.Repository.Interface;

namespace BoltaShop.Models.Dbo
{
    public class Book : IEntityBase
    {
        // 01
        public int Id { get; set; }
        public string Naziv { get; set; }

        // Relationships
        public List<AuthorBook> AuthorsBooks { get; set; }

        // Opis knjige
        public string? OpisKratki { get; set; }
        public string? Opis { get; set; }
        // Slika
        public string? Slika { get; set; }


        // 02
        public bool Dostupno { get; set; }
        public double? Cijena { get; set; }

        public bool Snizenje { get; set; }
        public double? CijenaSnizenje { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }


        // 03
        public int? GodinaIzdanja { get; set; }
        public string? Nakladnik { get; set; }
        public string? Isbn { get; set; }
        public BookCategory? BookCategory { get; set; }
        public BookBinding? BookBinding { get; set; }
        public int? BrojStranica { get; set; }


        // 04
        public double? Sirina { get; set; }
        public double? Visina { get; set; }
        public double? Debljina { get; set; }
        public double? Tezina { get; set; }
    }
}
