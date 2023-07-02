namespace Domain.Variant_Full;

/**
 * Таблица, регистраций для связи:
 *    Many Publisher - to - Many Author
 */
public class PublisherAuthor
{
    public int PublisherId { get; set; }
    public Publisher? Publisher { get; set; }

    public int AuthorId { get; set; }
    public Author? Author { get; set; }
}