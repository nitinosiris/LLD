namespace BookMyShow;

public class Address(
    string addressLine1,
    string addressLine2,
    string state,
    string city,
    string zipCode,
    string country)
{
    public string AddressLine1 { get; private set; } = addressLine1;
    public string AddressLine2 { get; private set; } = addressLine2;

    public string State { get; private set; } = state;
    public string City { get; private set; } = city;
    public string ZipCode { get; private set; } = zipCode;
    public string Country { get; private set; } = country;
}