using Domain.Base;

namespace Domain.Variant_Minimal;

public class Publisher : PublisherBase
{
    public ICollection<Author> Authors { get; }
}