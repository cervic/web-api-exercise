using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hola");
            Console.ReadKey();

            using (var db = new bd_usersEntities())
            {
                var users = db.users.Select(x => x).ToList();
                Console.WriteLine(users[0].apellido);
                Console.ReadKey(true);
            }
        }
    }
}
