namespace Domain.Models.WorkerAggregate.Dtos;

public record HoursWorkedDto
{
    public string FullName { get; set; } = string.Empty;
    public string WorkDate { get; set; } = string.Empty;
    public decimal HoursWorked { get; set; }
}