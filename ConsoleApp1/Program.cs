using ConsoleApp1.Control;
using ConsoleApp1.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<PetsOwner>> ownersMap = Mapper.GetOwnersMapByGender();

            PrintService.PrintOwners(ownersMap);
        }              
    }
}
