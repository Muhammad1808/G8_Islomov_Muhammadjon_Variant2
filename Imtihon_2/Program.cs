using Imtihon_2.Services;

public static class Program
{
    static void Main()
    {
        var service = new Library();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Kutubxona admini");
            Console.WriteLine("2. Kitobxon");
            Console.WriteLine("3. Exit");
            Console.Write("Tanlang: ");
            var choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    LibraryAdmin(service);
                    Console.Clear();
                    break;
                case "2":
                    Student(service);
                    Console.Clear();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Xato, qaytadan urinib ko`ring");
                    break;
            }
        }
    }

    static void LibraryAdmin(Library library)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("1. Kutubxona haqida");
            Console.WriteLine("2. Kategoriyalar");
            Console.WriteLine("3. Kitoblar");
            Console.WriteLine("4. Kitob va kategoriyalarni ulash");
            Console.WriteLine("5. Kitob va kategoriyalarni chiqarish");
            Console.WriteLine("6. Buyurtmalar");
            Console.WriteLine("7. Back");
            Console.Write("Tanlang: ");
            var choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    bool back1 = false;
                    while (!back1)
                    {
                        Console.WriteLine("1. Add Kutubxona");
                        Console.WriteLine("2. Update Kutubxona");
                        Console.WriteLine("3. Delete Kutubxona");
                        Console.WriteLine("4. List Kutubxona");
                        Console.WriteLine("5. Back");
                        Console.Write("Tanlang: ");
                        var choise1 = Console.ReadLine();

                        switch (choise1)
                        {
                            case "1":
                                Console.Write("Kutubxona nomini kiriting: ");
                                var kName = Console.ReadLine();
                                library.AddLibrary(kName);
                                Console.WriteLine("Successfully added");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                Console.Write("Kutubxona Id sini kiriting: ");
                                var kId = int.Parse(Console.ReadLine());
                                Console.Write("Kutubxona nomini kiriting: ");
                                var newKName = Console.ReadLine();
                                library.UpdateLibrary(kId, newKName);
                                Console.Clear();
                                break;
                            case "3":
                                Console.Write("Kutubxona Id sini kiriting: ");
                                var deleteTId = int.Parse(Console.ReadLine());
                                library.DeleteLibrary(deleteTId);
                                Console.Clear();
                                break;
                            case "4":
                                library.ListLibrary();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "5":
                                back1 = true;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Xato,qaytadan urinib ko`ring");
                                break;
                        }
                    }
                    break;
                case "2":
                    bool back2 = false;
                    while (!back2)
                    {
                        Console.WriteLine("1. Add Kategoriya");
                        Console.WriteLine("2. Update Kategoriya");
                        Console.WriteLine("3. Delete Kategoriya");
                        Console.WriteLine("4. List Kategoriya");
                        Console.WriteLine("5. Back");
                        Console.Write("Tanlang: ");
                        var choise2 = Console.ReadLine();

                        switch (choise2)
                        {
                            case "1":
                                Console.Write("Kategoriya nomini kiriting: ");
                                var kName = Console.ReadLine();
                                library.AddCategories(kName);
                                Console.WriteLine("Successfully added");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                Console.Write("Kategoriya Id sini kiriting: ");
                                var kId = int.Parse(Console.ReadLine());
                                Console.Write("Kategoriya nomini kiriting: ");
                                var newKName = Console.ReadLine();
                                library.UpdateCategories(kId, newKName);
                                Console.Clear();
                                break;
                            case "3":
                                Console.Write("Kategoriya Id sini kiriting: ");
                                var deleteTId = int.Parse(Console.ReadLine());
                                library.DeleteCategories(deleteTId);
                                Console.Clear();
                                break;
                            case "4":
                                library.ListCategories();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "5":
                                back2 = true;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Xato,qaytadan urinib ko`ring");
                                break;
                        }
                    }
                    break;
                case "3":
                    bool back3 = false;
                    while (!back3)
                    {
                        Console.WriteLine("1. Add Kitob");
                        Console.WriteLine("2. Update Kitob");
                        Console.WriteLine("3. Delete Kitob");
                        Console.WriteLine("4. List Kitob");
                        Console.WriteLine("5. Back");
                        Console.Write("Tanlang: ");
                        var choise3 = Console.ReadLine();

                        switch (choise3)
                        {
                            case "1":
                                Console.Write("Kitob nomini kiriting: ");
                                var kName = Console.ReadLine();
                                library.AddBook(kName);
                                Console.WriteLine("Successfully added");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                Console.Write("Kitob Id sini kiriting: ");
                                var kId = int.Parse(Console.ReadLine());
                                Console.Write("Kitob nomini kiriting: ");
                                var newKName = Console.ReadLine();
                                library.UpdateBook(kId, newKName);
                                Console.Clear();
                                break;
                            case "3":
                                Console.Write("Kitob Id sini kiriting: ");
                                var deleteTId = int.Parse(Console.ReadLine());
                                library.DeleteBook(deleteTId);
                                Console.Clear();
                                break;
                            case "4":
                                library.ListBooks();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "5":
                                back3 = true;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Xato,qaytadan urinib ko`ring");
                                break;
                        }
                    }
                    break;
                case "4":
                    Console.Write("Enter Book Id: ");
                    var attTId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Categories Id: ");
                    var attSId = int.Parse(Console.ReadLine());
                    library.AttachBookAndCategories(attTId, attSId);
                    Console.WriteLine("Successfully added");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    library.GetList();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "6":
                    library.GetBuyurtma();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "7":
                    back = true; Console.Clear(); break;
                default:
                    Console.WriteLine("Xato qaytadan urinib ko`ring");
                    break;


            }
        }
    }

    static void Student(Library library)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("1. Kutubxona haqida");
            Console.WriteLine("2. Buyurtma");
            Console.WriteLine("3. Back");
            Console.Write("Tanlang: ");
            var choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    library.ListLibrary();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    library .ListBooks();
                    Console.Write("Tanlang: ");
                    var bId=int.Parse(Console.ReadLine());
                    library.Buyurtma(bId);
                    Console.WriteLine("Successfully added");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    back = true; Console.Clear(); break;
                default:
                    Console.WriteLine("Xato qaytadan urining");
                    break;
            }

        }
    }
}