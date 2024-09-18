namespace Shared.Models;

public record class Contract(
int Id,
string Name,
string Description,
WorkStatus Status,
ContactInformation PrimaryContact
);