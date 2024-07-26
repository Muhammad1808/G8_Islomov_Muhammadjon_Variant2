using Models;
using System.Text.Json;

namespace Imtihon_2.Services
{
    public partial class Library
    {
        private List<AboutLibrary> libraries=new List<AboutLibrary> ();
        private static string path=Directory.GetCurrentDirectory();
        string jsonPathLibrary = path + "library.json";
        public void AddLibrary(string name)
        {
            int id = libraries.Count > 0 ? libraries.Max(l => l.Id)+1: 1;
            libraries.Add(new AboutLibrary() { Id=id, Name=name});
            string serialized = JsonSerializer.Serialize(libraries);
            using (StreamWriter writer = new StreamWriter(jsonPathLibrary))
            {
                writer.WriteLine(serialized);
            }
        }

        public void UpdateLibrary(int id,string name)
        {
            var library=libraries.FirstOrDefault(l => l.Id==id);
            if (library!=null)
            {
                library.Name=name;
                Console.WriteLine("Successfully updated");
            }
            else
            {
                Console.WriteLine("Library not found");
            }
            string serialized = JsonSerializer.Serialize<List<AboutLibrary>>(libraries);
            using (StreamWriter sw = new StreamWriter(jsonPathLibrary))
            {
                sw.WriteLine(serialized);
            }
        }

        public void DeleteLibrary(int id)
        {
            var library = libraries.FirstOrDefault(x => x.Id == id);
            if (library != null)
            {
                libraries.Remove(library);
                Console.WriteLine("Sucsessfully deleted");
            }
            else
                Console.WriteLine("Library not found");
            string serialized = JsonSerializer.Serialize<List<AboutLibrary>>(libraries);
            using (StreamWriter sw = new StreamWriter(jsonPathLibrary))
            {
                sw.WriteLine(serialized);
            }
        }

        public void ListLibrary()
        {
            libraries = JsonReadLibrary();
            if (libraries .Count > 0)
            {
                foreach (var library in libraries)
                {
                    Console.WriteLine($"Library: {library.Id}  , Name: {library.Name}");
                }
            }
            else
            {
                Console.WriteLine("Library not found");
            }
        }

        public List<AboutLibrary> JsonReadLibrary()
        {
            using (StreamReader reader = new StreamReader(jsonPathLibrary))
            {
                string json = reader.ReadToEnd();
                libraries = JsonSerializer.Deserialize<List<AboutLibrary>>(json);
            }
            return libraries;
        }
    }
}
