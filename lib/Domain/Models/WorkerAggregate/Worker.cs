namespace Domain.Models.WorkerAggregate;

using Core.Abstractions;

using Domain.Models.TimesheetAggregate;

using System.ComponentModel.DataAnnotations.Schema;

[Table("Worker")]
public sealed class Worker : DataModelBase
{
    public long WorkerId { get; set; }

    public long BuyerId { get; set; }

    public long UserId { get; set; }

    public required User User { get; set; }

    public required Buyer Buyer { get; set; }

    public ICollection<Timesheet> Timesheets { get; set; } = [];

    public override string GetTableName()
    {
        return "Worker";
    }
}
