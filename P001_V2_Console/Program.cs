using System;
using P001_V2;

namespace P001_V2_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        
            Console.WriteLine("Etape 2 Le nombre d'instances en mémoire de salariés est toujours de {0}", Salarie.NombreInstances);
            Console.WriteLine("Appuyez sur la touche Entrée pour demander au Garbage Collector de nettoyer le tas");
            Console.ReadLine();
            GC.Collect();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Etape 3 Le nombre d'instances en mémoire de salariés est de {0}", Salarie.NombreInstances);
            Console.ReadLine();

        }
        private static void Test()
        {
            Console.WriteLine("Test de la méthode vérification Matricule");
            Console.WriteLine
                ($"Test nom vide {Salarie.IsMatriculeValide("") == false})");
            Console.WriteLine
                ($"Test longueur > 7 {Salarie.IsMatriculeValide("12345678") == false})");
            Console.WriteLine
               ($"Test caractère spécial {Salarie.IsMatriculeValide("12&FT78") == false})");
            Console.WriteLine
               ($"Test non digit {Salarie.IsMatriculeValide("A2EFT78") == false})");
            Console.WriteLine
              ($"Test nom vide {Salarie.IsMatriculeValide("12EFT78") == true})");

            try
            {

                Salarie sal = new Salarie("Bost", "Vincent", "12aaa55");
                sal.DateNaissance = new DateTime(2000, 05, 29);
                sal.SalaireBrut = 1980.25m;
                sal.TauxCS = .30m;
                Salarie sal1 = new Salarie(sal);
                sal1.DateNaissance = new DateTime(2000, 05, 29);
                sal1.SalaireBrut = 1980.25m;
                sal1.TauxCS = .30m;
                Salarie sal2 = new Salarie("Bost", "Vincent", "12aaa55");
                sal2.DateNaissance = new DateTime(2000, 05, 29);
                sal2.SalaireBrut = 1980.25m;
                sal2.TauxCS = .30m;
                Salarie sal3 = new Salarie("Peyramard", "Florian","25bbb55");
                Console.WriteLine(@"Le salarié {0} {1} a été créé et son salaire net est de {2:n} euros", sal.Prenom, sal.Nom, sal.SalaireNet);
                Console.WriteLine("Etape 1 Le nombre d'instances en mémoire de salariés est de {0}", Salarie.NombreInstances);
                Console.WriteLine("Appuyez sur la touche Entrée pour détruire la référence au salarié");
                // Console.ReadLine();
                bool verif = sal.Equals(sal2);
                int hashcode = sal3.GetHashCode();
                // Console.WriteLine($"equal,{hashcode}");
                // string str = sal.ToString();
                // Console.WriteLine(str);

                Commercial c1 = new Commercial("Dupond", "Michel", "56rrr99");
                Console.WriteLine(c1.ToString());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
