namespace Domain.Models;

using Core.Abstractions;

using System.ComponentModel.DataAnnotations.Schema;

[Table("Users")]
public sealed class User : DataModelBase
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public ICollection<Worker> Workers { get; set; } = [];

    public override string GetTableName()
    {
        return "Users";
    }
}
