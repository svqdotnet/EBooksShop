using System;
using System.Collections.Generic;

namespace SwaggerDemo.PetConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            const string BASE_URL = "http://localhost:3412/api/v2";

            Console.WriteLine("Press KEY to continue when server is up and runing!");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("PET List");
            Console.WriteLine("--------");

            Client petClient = new Client() { BaseUrl = BASE_URL };
            var pets = petClient.FindPetsByStatusAsync(new List<Anonymous>() { Anonymous.Available }).GetAwaiter().GetResult();

            foreach (var pet in pets)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(pet));
            }


            Console.WriteLine();
            Console.WriteLine("Press ENTER to finish...");
            Console.ReadLine();
        }
    }
}
