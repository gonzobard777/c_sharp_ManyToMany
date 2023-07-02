using Domain.Base;

namespace Domain.Variant_Minimal;

public class Author : AuthorBase
{
    public ICollection<Publisher> Publishers { get; set; }
}