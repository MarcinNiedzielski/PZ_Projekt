using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PZ_Projekt.Models;

namespace PZ_Projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PZ_Projekt.Models.Item> Item { get; set; } = default!;
        public DbSet<PZ_Projekt.Models.Cart> Cart { get; set; }
        public DbSet<PZ_Projekt.Models.CartItem> CartItem { get; set; }
        public DbSet<PZ_Projekt.Models.Order> Order { get; set; }
        public DbSet<PZ_Projekt.Models.OrderItem> OrderItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });


            modelBuilder.Entity<IdentityUser>().HasData(
        new IdentityUser
        {
            Id = "e70a9c29-ca05-41d6-aa4a-f876f9ed833f",
            UserName = "a@a.com",
            NormalizedUserName = "A@A.COM",
            Email = "a@a.com",
            NormalizedEmail = "A@A.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEAwVc2aVRiKlYfqvPyiY6ZobmecB15it3IRUmboduoLCvZlZPiKhaJPrtVSbjXcxVQ==",
            SecurityStamp = "BBXP2X4LWHMYHRI33EGOAGAX4TK5KR56",
            ConcurrencyStamp = "d25bb904-d2ad-489d-906b-f58fcf737e6e",
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = true,
            AccessFailedCount = 0,


        },
        new IdentityUser
        {
            Id = "f274a51c-071b-457b-8918-2264d7342b04",
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEMwDf+gJp4KV3KrBQDzbMOJN0HNOAGZi51iqGZ82qFr1cuXkxqKAy5D7oCPcA1O+mw==",
            SecurityStamp = "DPZHW7DGCJFC6ZF6WYKNBF2IJBOI6WXZ",
            ConcurrencyStamp = "849a9e5f-4516-430e-acfd-864e1cea920f",
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = true,
            AccessFailedCount = 0,
        }
    );

            // Dodanie roli Administrator
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "03542356-7e04-4799-9124-a1e927d63628",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                    
                }
            );

            // Powiązanie użytkownika admin@admin.com z rolą Administrator
             modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
               {
                   UserId = "f274a51c-071b-457b-8918-2264d7342b04",
                   RoleId = "03542356-7e04-4799-9124-a1e927d63628"
              }
              );


            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Karta graficzna MSI GeForce RTX 4070",
                    Category = "GPU",
                    Description = "Szukasz uniwersalnej karty graficznej w przystępnej cenie, która wykazywać się " +
                        "będzie wysokim standardem? MSI GeForce RTX 4070 Ti Ventus 2X 12G jest bardzo przyzwoitą opcją, która spełni oczekiwania praktycznie każdego użytkownika – " +
                        "niezależnie od tego, czy Twój PC ma służyć do profesjonalnego grania, pracy, czy też do tworzenia kreatywnych projektów.",
                    Price = 3300M,
                    ImageUrl = "/uploads/503414e8-2efb-4cbb-8e1c-fcca2bd46612.jpg"
                },
                new Item
                {
                    Id = 2,
                    Name = "Karta graficzna Gigabyte GeForce RTX 4060 Eagle OC 8GB GDDR6",
                    Category = "GPU",
                    Description = "Wciąż poszukujesz karty graficznej, która nie zawiedzie Cię, bez względu na to, " +
                    "czego będziesz od niej oczekiwał? Pora zapoznać się z prawdziwym tytanem wydajności, który przeniesie Cię " +
                    "do świata bezkompromisowych osiągów. Gigabyte GeForce RTX 4060 EAGLE OC 8G to układ graficzny, którego możliwości " +
                    "wprawią Cię osłupienie. Grafika generowana grach jeszcze nigdy nie była tak realistyczna, a zadanie związane " +
                    "z koniecznością wykonania skomplikowanych obliczeń – tak szybko wykonane. Sprawdź i przekonaj się na własnej skórze.",
                    Price = 1400M,
                    ImageUrl = "/uploads/0ccbc04e-2d4a-447b-be7b-17eea24c4722.jpg"
                },
                new Item
                {
                    Id = 3,
                    Name = "Karta graficzna MSI GeForce RTX 3060 Ventus 2X OC 12GB GDDR6",
                    Category = "GPU",
                    Description = "Daj się zaskoczyć karcie graficznej MSI GeForce RTX 3060 VENTUS, której procesor graficzny zapewni Ci " +
                    "wydajność, o jakiej marzyłeś. Model z serii GeForce 30 w porównaniu z egzemplarzami poprzedniej serii (GeForce 20) " +
                    "charakteryzują o wiele większe zaawansowanie technologiczne i imponująca ilość funkcji. Karta posiada 12 GB najszybszej " +
                    "dostępnej pamięci GDDR6, pozwalającej na obsługę nawet bardzo wymagających zadań",
                    Price = 1300M,
                    ImageUrl = "/uploads/1119750d-42b6-4f4b-9a43-c70b6a780eb4.jpg"
                },
                // Dodaj resztę produktów tutaj
                new Item
                {
                    Id = 4,
                    Name = "Procesor Intel Core i5-12400F, 2.5 GHz, 18 MB, BOX",
                    Category = "CPU",
                    Description = "Dwunasta generacja procesorów Intel Core dla komputerów stacjonarnych - Alder Lake, opracowana została " +
                    "przede wszystkim po to, by sprostać wymaganiom graczy, oczekujących od zestawów komputerowych niezrównanej wydajności " +
                    "zarówno w rozrywce, jak i pracy wielozadaniowej.  Dwa rodzaje rdzeni procesora Intel Core i5-12400F zadbają o to, by " +
                    "wydajności nie zabrakło nawet w najbardziej wymagających produkcjach. Łącznie procesor wyposażony został w aż 6 rdzeni i " +
                    "12 wątków.",
                    Price = 489M,
                    ImageUrl = "/uploads/7e0dc800-3893-4e7f-8708-078087cc65bb.jpg"
                },
                new Item
                {
                    Id = 5,
                    Name = "Procesor Intel Core i7-14700K, 3.4 GHz, 33 MB, BOX",
                    Category = "CPU",
                    Description = "Od grupowych starć do niezapomnianych przygód — zanurz się w środek akcji jak nigdy dotąd! Wszystko " +
                    "to zapewni Ci najnowocześniejszy procesor Intel Core i7-14700k. Osiąga on prędkość do 5.6 GHz i posiada 8 rdzeni " +
                    "wysokiej wydajności oraz 12 rdzeni energooszczędnych. Ten zaawansowany procesor Intel Core i7 nowej generacji jest " +
                    "również gotowy do tuningu. Podkręć swoje gry, nie martwiąc się o procesy w tle obciążające system.",
                    Price = 1779M,
                    ImageUrl = "/uploads/7c38da4a-698f-4b64-a10d-63ec5d216a46.jpg"
                },
                new Item
                {
                    Id = 6,
                    Name = "Procesor AMD Ryzen 5 5600, 3.5 GHz, 32 MB, BOX",
                    Category = "CPU",
                    Description = "AMD Ryzen 5 5600 to procesor stanowiący odpowiedź producenta na potrzeby wszystkich tych, którzy szukają" +
                    " wydajnego układu do komputerów dla graczy i stanowisk pracy profesjonalistów. Wysoka wydajność gwarantowana przez " +
                    "najnowszą architekturę - AMD Zen 3, to jego największy atut.",
                    Price = 519M,
                    ImageUrl = "/uploads/1c89fa01-b4b4-4fc1-9761-6c4ce35c4c1c.jpg"
                },
                new Item
                {
                    Id = 7,
                    Name = "Pamięć Lexar Thor, DDR4, 32 GB, 3600MHz, CL18",
                    Category = "RAM",
                    Description = "Pamięć Lexar® THOR DDR4 UDIMM do komputerów stacjonarnych zwiększa wydajność komputera dzięki pamięci " +
                    "DDR4 i jest przeznaczona dla entuzjastów komputerów PC i ekstremalnych graczy. Charakteryzuje się wysoką wydajnością " +
                    "pamięci DDR4 i kosmicznym aluminiowym radiatorem zapewniającym doskonałe wykończenie i wysoce wydajne odprowadzanie " +
                    "ciepła, aby system działał w niskiej temperaturze.",
                    Price = 299M,
                    ImageUrl = "/uploads/d75c3c10-c765-4a05-ae7c-09ead448ef73.jpg"
                },
                new Item
                {
                    Id = 8,
                    Name = "Pamięć Kingston Fury Beast, DDR4, 16 GB, 3200MHz, CL16",
                    Category = "RAM",
                    Description = "Pamięć Kingston FURY™ Beast DDR4 o częstotliwości taktowania do 3733MHz to potężny ładunek wydajności " +
                    "w grach, edycji materiałów wideo i renderowaniu grafiki. Pamięć o częstotliwości taktowania od 2666MHz do 3733MHz i " +
                    "opóźnieniu od CL15 do CL19 to niedrogi sposób na modernizację komputera. Pojemność pojedynczego modułu wynosi od 4GB" +
                    " do 32GB, a pojemność zestawów od 8GB do 128GB. Pamięć jest wyposażona w funkcję automatycznego przetaktowania " +
                    "Plug N Play do częstotliwości 2666MHz, a także zgodna z technologią Intel XMP i procesorami AMD Ryzen. Chłodzenie " +
                    "pamięci FURY Beast DDR4 zapewnia stylowy, niskoprofilowy radiator. Każdy moduł pamięci przechodzi testy przy pełnej " +
                    "szybkości i jest objęty wieczystą gwarancją. To bezproblemowe i przystępne cenowo rozwiązanie przeznaczone do " +
                    "modernizacji systemu z procesorem Intel lub AMD.",
                    Price = 199M,
                    ImageUrl = "/uploads/54f6eaf6-3d98-4bab-8b2f-9e229f4bce1d.jpg"
                },
                new Item
                {
                    Id = 9,
                    Name = "Pamięć Patriot Viper Venom, DDR5, 32 GB, 6000MHz, CL36",
                    Category = "RAM",
                    Description = "Seria pamięci Viper Venom DDR5 jest najszybszą dostępną pamięcią firmy Patriot  dla najnowszych platform " +
                    "DDR5, zapewniając gracom szaloną wydajność systemu! Moduły pamięci Viper Venom DDR5 zostały zaprojektowane w oparciu o " +
                    "przełomową technologię, aby wyznaczać standardy wyższe niż większość ekstremalnie przetaktowanych modułów DDR4 oraz " +
                    "zapewniać dwukrotnie większą szybkość, podwajając obecną przepustowość DDR4.",
                    Price = 459M,
                    ImageUrl = "/uploads/8a259862-04cc-4fe8-a2a3-978181492897.jpg"
                },
                new Item
                {
                    Id = 10,
                    Name = "Zasilacz Endorfy Supremo FM5 Gold 850W",
                    Category = "zasilacze",
                    Description = "Endorfy Supremo FM5 Gold 850 W jest wydajnym zasilaczem, który spokojnie udźwignie wyśrubowane wymagania " +
                    "podzespołów Twojego peceta. Przygotuj się na wsparcie z najwyższej półki – bez niespodziewanych resetów.",
                    Price = 599M,
                    ImageUrl = "/uploads/5dfb79fe-d215-4e97-a3b8-65325cfd45d4.jpg"
                },
                new Item
                {
                    Id = 11,
                    Name = "Zasilacz Gigabyte P650G 650W",
                    Category = "zasilacze",
                    Description = "Kondensatory główne pochodzą od najwyższej klasy japońskich producentów, zapewniając wysokiej jakości i " +
                    "stabilne zasilanie, które skutecznie wydłuża żywotność produktu.",
                    Price = 252M,
                    ImageUrl = "/uploads/868ca153-7add-4457-91fb-808ad6f60662.jpg"
                },
                new Item
                {
                    Id = 12,
                    Name = "Zasilacz Corsair RM850x SHIFT 850W",
                    Category = "zasilacze",
                    Description = "Innowacyjny, zgłoszony do opatentowania boczny panel zasilacza z modułowymi złączami umożliwia " +
                    "wygodne podłączanie przewodów z boku. Dzięki temu kable można porządkować i podłączać łatwiej niż kiedykolwiek przedtem.",
                    Price = 705M,
                    ImageUrl = "/uploads/c0e4f85d-5cdf-4823-9af7-69abd8a3d575.jpg"
                },
                new Item
                {
                    Id = 13,
                    Name = "Dysk SSD Samsung 990 EVO 1TB M.2 2280 PCI-E x4 Gen4 NVMe",
                    Category = "dysk",
                    Description = "Model 990 EVO oferuje większe prędkości odczytu i zapisu sekwencyjnego (do 5 000 i 4 200 MB/s) " +
                    "oraz losowego (do 700 i 800 K IOPS), czyli o 43% więcej niż w 970 EVO Plus 2TB. Krótszy czas oczekiwania na gry " +
                    "i szybki dostęp do dużych plików.",
                    Price = 632M,
                    ImageUrl = "/uploads/ac1384bd-bd91-4d8a-b5fd-7371603b1176.jpg"
                },
                new Item
                {
                    Id = 14,
                    Name = "Dysk SSD Gigabyte 256GB 2.5\" SATA III",
                    Category = "dysk",
                    Description = "Dyski SSD o formacie 2,5 cala to niewielkie i lekkie sprzęty często instalowane w laptopach. " +
                    "Znalazły również zastosowanie, jako urządzenia zewnętrzne. To pierwszy format dysków SSD, który nadal cieszy " +
                    "się ogromną popularnością. Do największych zalet można zaliczyć kompaktowe rozmiary i prosty montaż w obudowach. " +
                    "Bardzo atrakcyjna oferta pozwoli na wybór sprzętu różnych producentów. Szeroki zakres parametrów technicznych " +
                    "pozwoli idealnie dobrać dysk do osobistych preferencji i oczekiwanych funkcji.",
                    Price = 100M,
                    ImageUrl = "/uploads/f791c5ed-c21e-4066-aea9-78086d5c13b8.jpg"
                },
                new Item
                {
                    Id = 15,
                    Name = "Dysk SSD ADATA Ultimate SU650 1TB 2.5\" SATA III",
                    Category = "dysk",
                    Description = "Dzięki pamięci Flash NAND 3D NAND dysk SU650 zapewnia większą wydajność i lepszą niezawodność " +
                    "w porównaniu do dysków SSD NAND 2D z lepszym stosunkiem ceny do wydajności.",
                    Price = 250M,
                    ImageUrl = "/uploads/c9dd6451-cc80-4146-b7b5-1bf02c3316dc.jpg"
                },
                new Item
                {
                    Id = 16,
                    Name = "Chłodzenie CPU Endorfy Fera 5 Black",
                    Category = "chłodzenie",
                    Description = "Fera 5 Black bez problemu utrzymuje niską temperaturę procesora nawet wtedy, " +
                    "kiedy komputer pracuje na najwyższych obrotach. To zasługa asymetrycznego radiatora z gęstym " +
                    "użebrowaniem, który dobrze zbiera energię cieplną – jego podstawa dokładnie styka się z powierzchnią " +
                    "procesora, a cztery ciepłowody poprawiają odbieranie wysokich temperatur. Cooler jest też zoptymalizowany " +
                    "do jednokierunkowego przepływu powietrza, co zapewnia najlepszą w swojej klasie wydajność chłodzenia.",
                    Price = 149M,
                    ImageUrl = "/uploads/20271e79-9c9d-4a8e-a7ce-d2fd488f901a.jpg"

                },
                new Item
                {
                    Id = 17,
                    Name = "Chłodzenie CPU be quiet! Dark Rock Pro 5",
                    Category = "chłodzenie",
                    Description = "Dark Rock Pro 5 posiada 7 wysokowydajnych miedzianych rurek cieplnych oraz specjalną " +
                    "czarną powłokę z cząsteczkami ceramicznymi. Dzięki temu ten wysokiej klasy cooler utrzymuje procesor w " +
                    "najwyższej wydajności przez cały czas, nawet w mocno podkręconych systemach i wymagających stacjach roboczych.",
                    Price = 367M,
                    ImageUrl = "/uploads/0fc6b1c7-afff-4887-ac36-1cfd4966006e.jpg"
                },
                new Item
                {
                    Id = 18,
                    Name = "Chłodzenie CPU Deepcool AK620 Digital",
                    Category = "chłodzenie",
                    Description = "Nadeszła era cyfrowych chłodzeń powietrza, a DeepCool z dumą przedstawia AK620 Digital." +
                    " Wszystko, co kochałeś w AK620 Zero Dark, ale z eleganckim niskoprofilowym magnetycznym wyświetlaczem " +
                    "statusu i paskami LED ARGB.",
                    Price = 299M,
                    ImageUrl = "/uploads/54b35329-7d38-4e8b-93e2-9926926cc020.jpg"
                }
            );


        }
    }
}
