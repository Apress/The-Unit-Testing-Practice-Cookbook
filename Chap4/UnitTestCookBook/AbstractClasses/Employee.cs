namespace Apress.UnitTests.AbstractClasses;

public abstract class Employee
{
    private string _name;
    private int _employeeId;

    public Employee(string name, int employeeId)
    {
        _name = name;
        _employeeId = employeeId;
    }

    public abstract decimal CalculateSalary();

    public virtual string DisplayInfo()
    {
        return $"Employee Name: {_name}, Id: {_employeeId}";
    }
}