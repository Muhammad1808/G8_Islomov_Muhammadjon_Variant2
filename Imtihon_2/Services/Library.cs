using Models;


namespace Imtihon_2.Services
{
    public partial  class Library
    {
        
        public void AttachBookAndCategories(int bookId, int categoryId)
        {
            var book=books.FirstOrDefault(b=>b.Id==bookId);
            var category=categories.FirstOrDefault(c=>c.Id==categoryId);

            if(book==null || category == null)
            {
                Console.WriteLine("Invalid book or category Id");
                return;
            }

            var bookCategories = new BookCategories
            {
                BookId = bookId,
                Book = book,
                CategoryId = categoryId,
                Category = category
            };

            book.BookCategories.Add(bookCategories);
            category.BookCategories.Add(bookCategories);
        }

        public void GetList()
        {
            if (books.Count > 0)
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"Book:{book.Name}");
                    foreach(var bc in book.BookCategories)
                    {
                        Console.WriteLine($" Category: {bc.Category.Name}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Book list is empty");
            }

        }
        
        public void Buyurtma(int bookId)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                Console.WriteLine("Invalid book Id");
                return;
            }
            var buyurtmalar = new Buyurtmalar
            {
                Book = book,
                BookId = bookId
            };
            book.Buyurtmalar.Add(buyurtmalar);
        }

        public void GetBuyurtma()
        {
            if (books.Count > 0)
            {
                foreach(var book in books)
                {
                    foreach(var bc in book.Buyurtmalar)
                    {
                        Console.WriteLine($"Book: {bc.Book.Name}");
                    }
                }
            }
        }

    }
}
