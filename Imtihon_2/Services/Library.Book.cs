using Models;
using System.Text.Json;

namespace Imtihon_2.Services
{
    public partial  class Library
    {
        private List<Book> books = new List<Book>();
        string jsonPathBook = path + "book.json";
        public void AddBook(string name)
        {
            int id = books.Count > 0 ? books.Max(l => l.Id) + 1 : 1;
            books.Add(new Book() { Id = id, Name = name });
            string serialized = JsonSerializer.Serialize(books);
            using (StreamWriter writer = new StreamWriter(jsonPathBook))
            {
                writer.WriteLine(serialized);
            }
        }

        public void UpdateBook(int id, string name)
        {
            var book = books.FirstOrDefault(l => l.Id == id);
            if (book != null)
            {
                book.Name = name;
                Console.WriteLine("Successfully updated");
            }
            else
            {
                Console.WriteLine("Book not found");
            }
            string serialized = JsonSerializer.Serialize<List<Book>>(books);
            using (StreamWriter sw = new StreamWriter(jsonPathBook))
            {
                sw.WriteLine(serialized);
            }
        }

        public void DeleteBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Sucsessfully deleted");
            }
            else
                Console.WriteLine("Book not found");
            string serialized = JsonSerializer.Serialize<List<Book>>(books);
            using (StreamWriter sw = new StreamWriter(jsonPathBook))
            {
                sw.WriteLine(serialized);
            }
        }

        public void ListBooks()
        {
            books = JsonReadBook();
            if (books.Count > 0)
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"Book: {book.Id}  , Name: {book.Name}");
                }
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        public List<Book> JsonReadBook()
        {
            using (StreamReader reader = new StreamReader(jsonPathBook))
            {
                string json = reader.ReadToEnd();
                books = JsonSerializer.Deserialize<List<Book>>(json);
            }
            return books;
        }
    }
}
