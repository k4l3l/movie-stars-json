using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace movie_stars
{
    class MovieStar {
        
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Sex { get; set; }
        private string Nationality { get; set; }
        private DateTime dateOfBirth { get; set; }
        

        public MovieStar (string Name, string Surname, string Sex, string Nationality, string dateOfBirth) {
            this.Name = Name;
            this.Surname = Surname;
            this.Sex = Sex;
            this.Nationality = Nationality;
            this.dateOfBirth = DateTime.Parse(dateOfBirth);
            // try {
            //     this.dateOfBirth = DateTime.Parse(dateOfBirth);
            // } catch {
            //     throw new ArgumentException("Invalid date format!");
            // }
        }

        private int getAge() {
            var now = DateTime.Now;
            return (int)(now.Subtract(this.dateOfBirth).TotalDays / 365);
        }


        public override string ToString() {
            return $"{this.Name} {this.Surname}\n{this.Sex}\n{this.Nationality}\n{this.getAge()} years old";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json = System.IO.File.ReadAllText(@".\input.txt");
            
            List<MovieStar> list = JsonConvert.DeserializeObject<List<MovieStar>>(json);            

            foreach (MovieStar item in list)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine();
            }

        }
    }
}
