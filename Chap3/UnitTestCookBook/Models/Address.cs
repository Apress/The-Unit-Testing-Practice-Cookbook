namespace Apress.UnitTests.Models;

public class Address
{
    public string Street { get; set; }
    public int StreetNumber { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string ApartmentNumber { get; set; }

    public string Display(Person person)
    {
        var aptNumber = !string.IsNullOrWhiteSpace(ApartmentNumber) ? $" {ApartmentNumber}" : string.Empty;
        // Format the address as a readable string
        return $"{person.FullName} lives at {StreetNumber} {Street}{aptNumber}, {City}, {State}, {ZipCode}, {Country}";
    }
}
