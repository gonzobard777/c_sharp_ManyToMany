using Domain.Base;

namespace Domain.Variant_Full;

public class Author : AuthorBase
{
    /*
     * Many Publisher - to - Many Author
     */
    public ICollection<Publisher> Publishers { get; set; }
    public ICollection<PublisherAuthor> PublishersAuthors { get; set; } // таблица регистраций для связи
}