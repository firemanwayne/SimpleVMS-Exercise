namespace Domain.Models.TimesheetAggregate.Queries;

public record TimesheetsByBuyerWithDateRangeQuery
{
    public const string StoredProcedure = "GetTimesheetsByBuyerIDForDateRange";

    public required long BuyerID { get; init; }
    public required DateTime StartDate { get; init; }
    public required DateTime EndDate { get; init; }
}