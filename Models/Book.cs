namespace Models;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<BookCategories> BookCategories { get; set; }=new List<BookCategories>();
    public List<Buyurtmalar> Buyurtmalar { get; set; } = new List<Buyurtmalar>();
}
