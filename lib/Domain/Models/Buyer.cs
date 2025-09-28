namespace Domain.Models;

using Core.Abstractions;

using System.ComponentModel.DataAnnotations.Schema;

[Table("Buyer")]
public sealed class Buyer : DataModelBase
{
    public long BuyerId { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<Worker> Workers { get; set; } = [];

    public override string GetTableName()
    {
        return "Buyer";
    }
}
