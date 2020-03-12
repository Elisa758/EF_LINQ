using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework_WindowsForm_LINQ
{
    class Program
    {
        static void Main()
        {
            using(var context = new AnimalContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine("Creation species and animals");

                var species = new List<Species>();

                species.Add(GenerateSpecies("cougar", "white cougar", 3));
                species.Add(GenerateSpecies("tiger", "white tiger", 100));
                species.Add(GenerateSpecies("turtle", "white turtle", 15));


                context.AddRange(species);
                context.SaveChanges();

                var whiteCougarSpecies = from s in context.Species
                                         where s.Name == "cougar"
                                         select s;

                var whiteCougar = from a in context.Animals
                                  where a.Species == whiteCougarSpecies.FirstOrDefault()
                                  select a;

                int nbOfWhiteCougar = whiteCougar.Count();


                var whiteTigerSpecies = from s in context.Species
                                        where s.Name == "tiger"
                                        select s;

                var whiteTiger = from a in context.Animals
                                 where a.Species == whiteTigerSpecies.FirstOrDefault()
                                 select a;

                int nbOfWhiteTiger = whiteTiger.Count();

                var whiteTurtleSpecies = from s in context.Species
                                        where s.Name == "turtle"
                                        select s;

                var whiteTurtle = from a in context.Animals
                                 where a.Species == whiteTurtleSpecies.FirstOrDefault()
                                 select a;

                int nbOfWhiteTurtle = whiteTurtle.Count();


              
                
                var nbOfAnimalsBySpecies = from a in context.Animals.AsEnumerable()
                                           group a.Name by a.Species.SpeciesId into AnimalGroup
                                           select AnimalGroup;

                String message = String.Empty;
                foreach(var animalS in nbOfAnimalsBySpecies )
                {
                    message += animalS.Key +"\n"  + "  " + animalS.Count() +"\n";
                }

                MessageBox.Show(message.ToString(), "Number of animals", MessageBoxButtons.OK, MessageBoxIcon.Information);






            }
        }
        static Species GenerateSpecies(string species, string animal, int animalsCount)
        {
            var newSpecies = new Species();
            newSpecies.Name = species;
            ICollection<Animal> animalsSpecies = new List<Animal>();
            for (int i =1; i<=animalsCount;i++)
            {
                var newAnimal = new Animal();
                newAnimal.Name = animal + i;
                animalsSpecies.Add(newAnimal);
            }
            newSpecies.Animals = animalsSpecies;
            return newSpecies;


        }
            
    }
}
