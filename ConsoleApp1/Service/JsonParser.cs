using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Service
{
    class JsonParser
    {
        public static List<PetsOwner> GetPetOwners()
        {
            List<PetsOwner> petsOwners = new List<PetsOwner>();

            using (StreamReader file = File.OpenText(@"C:\Users\vmusienko\source\repos\ConsoleApp1\ConsoleApp1\Resources\testJson.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JArray petsOwnersArray = (JArray)JToken.ReadFrom(reader);

                JsonToPetsOwners(petsOwners, petsOwnersArray);

            }

            return petsOwners;
        }

        private static void JsonToPetsOwners(List<PetsOwner> petsOwners, JArray petsOwnersArray)
        {
            foreach (var po in petsOwnersArray.Children())
            {
                List<Pet> pets = GetPets(po);
                PetsOwner petOwner = CreatePetsOwner(po, pets);

                petsOwners.Add(petOwner);
            }
        }

        private static PetsOwner CreatePetsOwner(JToken po, List<Pet> pets)
        {
            PetsOwner petsOwner = new PetsOwner
            {
                Name = (string)po["name"],
                Gender = (string)po["gender"],
                Age = (string)po["age"],
                Pets = pets.OrderBy(p => p.Name).ToList()
            };

            return petsOwner;
        }

        private static List<Pet> GetPets(JToken po)
        {
            List<Pet> pets = (po["pets"]).Select(p => new Pet
            {
                Name = (string)p["name"],
                Type = (Pet.PetType)Enum.Parse(typeof(Pet.PetType), (string)p["type"], true)
            }).ToList();

            return pets;
        }
    }
}
