namespace Domain.Models;

using Core.Abstractions;

using System.ComponentModel.DataAnnotations.Schema;

[Table("Timesheet")]
public sealed class Timesheet : DataModelBase
{
    public long TimesheetId { get; set; }

    public long WorkerId { get; set; }

    public DateOnly PeriodStartDate { get; set; }

    public decimal Hours1 { get; set; }

    public decimal Hours2 { get; set; }

    public decimal Hours3 { get; set; }

    public decimal Hours4 { get; set; }

    public decimal Hours5 { get; set; }

    public decimal Hours6 { get; set; }

    public decimal Hours7 { get; set; }

    public required Worker Worker { get; set; }

    public override string GetTableName()
    {
        return "Timesheet";
    }
}
