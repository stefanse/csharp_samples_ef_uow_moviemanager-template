using MovieManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieManager.Core
{
    public class ImportController
    {
        const string Filename = "movies.csv";
        private  static List<Movie> _movies;
        private static Dictionary<string,Category> _categories;

        /// <summary>
        /// Liefert die Movies mit den dazugehörigen Kategorien
        /// </summary>
        public static IEnumerable<Movie> ReadFromCsv()
        {
            _movies = new List<Movie>();
            _categories = new Dictionary<string, Category>();

            string  [] []lines = Utils.MyFile.ReadStringMatrixFromCsv("movies.csv", true);
            foreach(string [] line in lines)
            {

               // Console.WriteLine($"{ line[0]}  { line[1]} { line[2]} { line[3]} ");
                _movies.Add(new Movie
                {
                    Title = line[0],
                    Year = Convert.ToInt32(line[1]),
                    Category = CheckCategory(line[2]),
                    Duration = Convert.ToInt32(line[3])
                });

            }

            return _movies;


           // throw new NotImplementedException();
        }


        public static Category CheckCategory(string categoriy)
        {
            if (!_categories.ContainsKey(categoriy))
            {
                Category newCategory = new Category { CategoryName = categoriy };
               _categories.Add(categoriy, newCategory);
                return newCategory;
            }
            else
            {
                return _categories[categoriy];
            }
        }
    }
}
