namespace DelegateHomework.CustomExtensionDelegateMethod;

public class UseMaxExtensionMethod
{
    public UseMaxExtensionMethod()
    {

    }

    public void RunMaxExtensionMethodExample()
    {
        var listOfFloats = new List<float>
        {
            5.678f,
            2.367f,
            12.798f,
            43.123f,
            78.321f,
            6.243f,
            9.1234f,
            2.567f
        };

        var maxValue = listOfFloats.GetMax(x => x);

        Console.WriteLine($"Max value in List of floats = {maxValue}");

        var listOfPerson = new List<Person>
        {
            new Person { Id = 1, Name = "Пётр", Age = 23 },
            new Person { Id = 2, Name = "Василий", Age = 28 },
            new Person { Id = 3, Name = "Анна", Age = 25 },
            new Person { Id = 4, Name = "Дмитрий", Age = 34 },
            new Person { Id = 5, Name = "Геннадий", Age = 65 },
            new Person { Id = 6, Name = "Владимир", Age = 42 },
            new Person { Id = 7, Name = "Александр", Age = 38 },
            new Person { Id = 8, Name = "Борис", Age = 54 }
        };

        var maxPersonAge = listOfPerson.GetMax(x => x.Age);

        Console.WriteLine($"Max person's age in List of Person = {maxPersonAge.Age}, name = {maxPersonAge.Name}");
    }
}