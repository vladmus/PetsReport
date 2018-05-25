using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Service
{
    class PrintService
    {
        public static void PrintOwners(Dictionary<string, List<PetsOwner>> ownersMap)
        {
            foreach (KeyValuePair<string, List<PetsOwner>> genderGroup in ownersMap)
            {
                PrintGenderGroup(genderGroup);
            }
        }

        private static void PrintGenderGroup(KeyValuePair<string, List<PetsOwner>> genderGroup)
        {
            Console.WriteLine("\n" + genderGroup.Key + ":");
            genderGroup.Value.ForEach(po =>
            {
                Console.WriteLine("\n\t" + po.Name + " Pets:\n");
                po.Pets.ForEach(p => Console.WriteLine("\t\t" + p.Name));
            });
        }
    }
}
