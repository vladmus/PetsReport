using ConsoleApp1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Control
{
    class Mapper
    {
        public static Dictionary<string, List<PetsOwner>> GetOwnersMapByGender()
        {
            List<PetsOwner> petsOwners = JsonParser.GetPetOwners();

            var ownersMap = new Dictionary<string, List<PetsOwner>>();

            ownersMap.Add("Male", petsOwners.Where(po => po.Gender == "Male").OrderBy(po => po.Name).ToList());
            ownersMap.Add("Female", petsOwners.Where(po => po.Gender == "Female").OrderBy(po => po.Name).ToList());

            return ownersMap;
        }



    }
}
