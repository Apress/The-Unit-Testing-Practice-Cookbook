namespace Apress.UnitTests.AbstractClasses;

public class DerivedEmployee : Employee
{
    public DerivedEmployee(string name, int employeeId) : base(name, employeeId) { }

    public override decimal CalculateSalary()
    {
        throw new NotImplementedException();
    }
}