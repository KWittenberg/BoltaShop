using BoltaShop.Models.Dbo;
using BoltaShop.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace BoltaShop.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();



                //Authors
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author() { Slika = "/img/Autor/TWittenberg.jpg",
                            Ime = "Tomislav",
                            Prezime = "Wittenberg",
                            Opis = "Tomislav Wittenberg rođen je 8. siječnja 1937. godine u Djedinoj Rijeci – mlin Baćur. " +
                                   "Osnovnu školu polazi u Djedinoj Rijeci, Nižu Gimnaziju u Požegi, a Učiteljsku školu u Slavonskom Brodu. " +
                                   "Radni vijek proveo je uglavnom u privredi. Uz rad završava Višu Upravnu školu u Zagrebu. " +
                                   "Još kao učenik javlja se s kraćim prilozima u Brodskom listu, a poslije i u Požeškom listu. " +
                                   "Urednik je povremenog lista Mladost (1959.-1961). godine u Požegi. " +
                                   "Kao sporedni posao u GIKPRO Požega bio je glavni urednik istoimenog lista (1982.-1988.), u kojem se javlja kao 'Stipa iz Puvarije'. " },

                        new Author() { Slika = "/img/Autor/VHip.jpg",
                            Ime = "Vladimir",
                            Prezime = "Hip",
                            Opis = "Vladimir Hip rođen je u Osijeku 17. listopada 1927. godine, gdje je otac Antun radio kao službenik u poreznoj upravi. " +
                                   "Često se selio s roditeljima tako da je četiri razreda osnovne škole završio u Bosanskom Novom. " +
                                   "U prvi razred gimnazije upisuje se u Požegi (školske godine 1938./1939.), nakon čega doseljavaju u Požegu i njegovi roditelji. " + 
                                   "Stanuju u iznajmljenom stanu na Ciglanama, poznatoj radničkoj četvrti u Jelačičevoj ulici broj 18. (bivšaulica Rade Končara). " +
                                   "Tu je mali Vlado upoznao već u najranijoj mladosti mukotrpan život. " + 
                                   "Njegovi kolege iz razreda i prijatelji kažu da je 'Cujo', kako su ga od milja zvali u razredu, počeo pisati pjesme već u četvrtom razredu gimnazije za časopis 'Naše znanje', kojega su sami uređivali. " + 
                                   "Naravno da je 'Cujo' pisao najbolje hrvatske zadaće i bio jedan od najboljih đaka u razredu. " },

                        new Author() { Slika = "/img/Autor/BZivkovic.jpg",
                            Ime = "Branko",
                            Prezime = "Živković",
                            Opis = "Branko ŽIVKOVIĆ (Požeške Sesvete, 30. 5. 1925. godine) specijalist iz ginekologije i književnik. " + 
                                   "Gimnaziju je završio u Požegi, a Medicinski fakultet u Zagrebu. Primarius je postao 1975. godine, a doktor znanosti 1981. godine. " +
                                   "Od 1959. godine radi u Medicinskom centru u Novoj Gradiški, gdje je osnovao ginekološko-porođajni odjel i dispanzer za žene, te postao prvi šef Službe za zaštitu žene. " + 
                                   "Od 1963. godine radi u Kliničkoj bolnici 'Sestara Milosrdnica' u Zagrebu, gdje je šef odsjeka na Klinici zaženske bolesti i porodiljstvo. Objavio je 45 znanstvenih i stručnih radova. " },

                    });
                    context.SaveChanges();
                }

                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Naziv = "Groblja Požeske Doline",
                            OpisKratki = "Groblja Požeske Doline - Kratki opis knjige.",
                            Opis = "Groblja Požeske Doline - Opis knjige. bla bla bla",
                            Slika = "/img/1996 Groblja Pozeske Doline/1996 Groblja Pozeske Doline 00.jpg",
                            Dostupno = true,
                            Cijena = 200.00,
                            Snizenje = false,
                            GodinaIzdanja = 1996,
                            Nakladnik = "Bolta",
                            Isbn = "978-953-9700-00-0",
                            BookCategory = BookCategory.Monografije,
                            BookBinding = BookBinding.Meki,
                            BrojStranica = 190,
                            Sirina = 170,
                            Visina = 240,
                            Debljina = 10,
                            Tezina = 350
                        },

                        new Book()
                        {
                            Naziv = "Rudina",
                            OpisKratki = "Rudina - Kratki opis knjige.",
                            Opis = "Rudina - Opis knjige. bla bla bla",
                            Slika = "/img/1997 Rudina/1997 Rudina 11.jpg",
                            Dostupno = true,
                            Cijena = 300.00,
                            Snizenje = true,
                            CijenaSnizenje = 250.00,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30),
                            GodinaIzdanja = 1997,
                            Nakladnik = "Bolta",
                            Isbn = "978-953-9730-00-0",
                            BookCategory = BookCategory.Monografije,
                            BookBinding = BookBinding.Tvrdi,
                            BrojStranica = 126,
                            Sirina = 223,
                            Visina = 290,
                            Debljina = 16,
                            Tezina = 845
                        },

                        new Book()
                        {
                            Naziv = "Puvarija",
                            OpisKratki = "Puvarija - Kratki opis knjige.",
                            Opis = "Puvarija - Opis knjige. bla bla bla",
                            Slika = "/img/1998 Puvarija/Puvarija 00.jpg",
                            Dostupno = true,
                            Cijena = 300.00,
                            Snizenje = true,
                            CijenaSnizenje = 250.00,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30),
                            GodinaIzdanja = 1998,
                            Nakladnik = "Bolta",
                            Isbn = "978-953-97322-1-2",
                            BookCategory = BookCategory.Monografije,
                            BookBinding = BookBinding.Meki,
                            BrojStranica = 314,
                            Sirina = 164,
                            Visina = 234,
                            Debljina = 17,
                            Tezina = 510
                        },

                    });
                    context.SaveChanges();
                }

                //AuthorBook
                if (!context.AuthorsBooks.Any())
                {
                    context.AuthorsBooks.AddRange(new List<AuthorBook>()
                    {
                        new AuthorBook() { AuthorId = 1, BookId =  1 },
                        new AuthorBook() { AuthorId = 1, BookId =  2 },
                        new AuthorBook() { AuthorId = 1, BookId =  3 },
                    });
                    context.SaveChanges();
                }
            }
        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            //using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            //{

            //    //Roles
            //    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            //        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            //    if (!await roleManager.RoleExistsAsync(UserRoles.User))
            //        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            //    //Users
            //    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            //    string adminUserEmail = "admin@etickets.com";

            //    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            //    if (adminUser == null)
            //    {
            //        var newAdminUser = new ApplicationUser()
            //        {
            //            FullName = "Admin User",
            //            UserName = "admin-user",
            //            Email = adminUserEmail,
            //            EmailConfirmed = true
            //        };
            //        await userManager.CreateAsync(newAdminUser, "Coding@1234?");
            //        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            //    }


            //    string appUserEmail = "user@etickets.com";

            //    var appUser = await userManager.FindByEmailAsync(appUserEmail);
            //    if (appUser == null)
            //    {
            //        var newAppUser = new ApplicationUser()
            //        {
            //            FullName = "Application User",
            //            UserName = "app-user",
            //            Email = appUserEmail,
            //            EmailConfirmed = true
            //        };
            //        await userManager.CreateAsync(newAppUser, "Coding@1234?");
            //        await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            //    }
            //}
        }








    }
}
