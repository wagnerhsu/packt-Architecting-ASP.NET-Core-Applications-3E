namespace Shared.Models;

public record class Customer(
int Id,
string Name,
List<Contract> Contracts
);