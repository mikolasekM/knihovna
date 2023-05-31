class knihovnaProjekt
{
    private class kniha {

        public kniha(string nazev, string autor, int rok)
        {
            this.nazev = nazev;
            this.autor = autor;
            this.rok = rok;
        }

        public string nazev { get; set; }
        public string autor { get; set; }
        public int rok { get; set; }
    } 


    private static class KniHOVNA {
        public static List<kniha> list { get; set; } = new();

        public static void PridejKnihu()
        {
            Console.Clear();
            Console.WriteLine("zadej název knihy");
            string jmenoKnihy = Console.ReadLine();
            Console.WriteLine("zadej autora knihy");
            string autorKnihy = Console.ReadLine();
            Console.WriteLine("zadej rok vydání knihy");
            int rokVydani = int.Parse(Console.ReadLine());

            list.Add(new kniha(jmenoKnihy, autorKnihy, rokVydani));
        }
        public static void vypisKnihy()
        {
            foreach(var kniha in list)
            {
                Console.WriteLine($"Název: {kniha.nazev} od {kniha.autor}, vydáno {kniha.rok}");
            }
            Console.ReadKey();
        }
        public static void vyhledaniAutor()
        {
            Console.WriteLine("napiž jméno autora");
            string autor = Console.ReadLine();

            var nalezeneKnihy = list.FindAll(p => p.autor == autor);

            foreach (var kniha in nalezeneKnihy)
            {
                Console.WriteLine($"Název: {kniha.nazev} od {kniha.autor}, vydáno {kniha.rok}");
            }

            Console.ReadKey();
        }
    }



    public static void main() {

        
        while (true)
        {
            Console.Clear();
            string vyber = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Vyber:")
                .AddChoices(new string[] {"Přidat knihu", "Zobrazit knihu", "Vyhledat knihu podle autora"})
            );
            switch(vyber)
            {
                case "Přidat knihu": {
                        KniHOVNA.PridejKnihu();
                } break;

                case "Zobrazit knihu":
                    {
                        KniHOVNA.vypisKnihy();
                    }
                break;

                case "Vyhledat knihu podle autora":
                    {
                        KniHOVNA.vyhledaniAutor();
                    } break;
            }
        }
    }
}