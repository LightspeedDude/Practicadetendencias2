using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicatendencias2
{
    class Program
    {
        static void Main(string[] args)
        {
            string read = Console.ReadLine();

            int num = Convert.ToInt32(read);

            Team[] teams = new Team[num];

            int name = 0;

            for (int i = 0; i < num; i++)
            {
                Team temp;
                name = i + 1;
                temp = new Team(name);
                teams[i] = temp;
            }

 
            string[] Students = File.ReadAllLines("Students.txt").OrderBy(s => Guid.NewGuid()).ToArray();

            string[] Topics = File.ReadAllLines("Topics.txt").OrderBy(s => Guid.NewGuid()).ToArray();

            //Add students and topics
            int counter = 0;
            int scount = Students.Length;
            int tcount = Topics.Length;

            //Students counter
            while (scount > 0)
            {
                var s = Students[scount - 1];
                if(counter == num)
                {
                    counter = 0;
                }
                teams[counter].Students.Add(s);

                counter++;
                scount--;
            }


            //Topics counter
            while (tcount > 0)
            {
                var t = Topics[tcount - 1];
                if (counter == num)
                {
                    counter = 0;
                }
                teams[counter].Topics.Add(t);

                counter++;
                tcount--;
            }

            //Imprimir datos
            foreach(Team t in teams)
            {
                Console.WriteLine($" +Grupo {t.Name}");
                Console.WriteLine($"     -Estudiantes: {t.Students.Count}");
                foreach(String st in t.Students)
                {
                    Console.WriteLine(st);
                }

                Console.WriteLine($"     -Temas: {t.Topics.Count}");
                foreach (String top in t.Topics)
                {
                    Console.WriteLine(top);
                }
            }
            Console.ReadKey();


        }
    }
    class Team
    {
        public int Name { get; set; }
        public List<string> Students { get; set; }

        public List<string> Topics { get; set; }

        public Team(int name)
        {
            Name = name;
            Students = new List<string>();
            Topics = new List<string>();
        }

      
    }
}
