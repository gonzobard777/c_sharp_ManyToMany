using Domain.Base;

namespace Domain.Variant_Full;

public class Publisher : PublisherBase
{
    /*
     * Many Publisher - to - Many Author
     */
    public ICollection<Author> Authors { get; }
    public ICollection<PublisherAuthor> PublishersAuthors { get; set; } // таблица регистраций для связи
}