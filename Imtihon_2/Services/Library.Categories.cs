using Models;
using System.Text.Json;

namespace Imtihon_2.Services
{
    public partial  class Library
    {
        private List<Categories> categories=new List<Categories> ();
        string jsonPathCategories = path + "categoria.json";
        public void AddCategories(string name)
        {
            int id = categories.Count > 0 ? categories.Max(k => k.Id) + 1 : 1;
            categories.Add(new Categories() { Id = id, Name = name });
            string serialized = JsonSerializer.Serialize(categories);
            using (StreamWriter writer = new StreamWriter(jsonPathCategories))
            {
                writer.WriteLine(serialized);
            }
        }

        public void UpdateCategories(int id, string name)
        {
            var categoria = categories.FirstOrDefault(l => l.Id == id);
            if (categoria != null)
            {
                categoria.Name = name;
                Console.WriteLine("Successfully updated");
            }
            else
            {
                Console.WriteLine("Categoria not found");
            }
            string serialized = JsonSerializer.Serialize<List<Categories>>(categories);
            using (StreamWriter sw = new StreamWriter(jsonPathCategories))
            {
                sw.WriteLine(serialized);
            }
        }

        public void DeleteCategories(int id)
        {
            var categoria = categories.FirstOrDefault(x => x.Id == id);
            if (categoria != null)
            {
                categories.Remove(categoria);
                Console.WriteLine("Sucsessfully deleted");
            }
            else
                Console.WriteLine("Categoria not found");
            string serialized = JsonSerializer.Serialize<List<Categories>>(categories);
            using (StreamWriter sw = new StreamWriter(jsonPathCategories))
            {
                sw.WriteLine(serialized);
            }
        }

        public void ListCategories()
        {
            categories = JsonReadCategories();
            if (categories.Count > 0)
            {
                foreach (var categoria in categories)
                {
                    Console.WriteLine($"Categoria: {categoria.Id}  , Name: {categoria.Name}");
                }
            }
            else
            {
                Console.WriteLine("Categoria not found");
            }
        }

        public List<Categories> JsonReadCategories()
        {
            using (StreamReader reader = new StreamReader(jsonPathCategories))
            {
                string json = reader.ReadToEnd();
                categories = JsonSerializer.Deserialize<List<Categories>>(json);
            }
            return categories;
        }

    }
}
