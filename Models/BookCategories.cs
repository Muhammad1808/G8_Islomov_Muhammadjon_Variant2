namespace Models;

public  class BookCategories
{
    public int BookId {  get; set; }
    public Book Book { get; set; }
    public int CategoryId { get; set; }
    public Categories Category { get; set; }
}
