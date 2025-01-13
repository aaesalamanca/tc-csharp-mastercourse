ShowAppInfo();
var firstName = AskUserForFirstName();
var age = AskUserForAge();

var outputMessage =
    "Hello, "
    + firstName.ToLower() switch
    {
        "bob" or "sue" => $"Professor {firstName}",
        _ => firstName,
    }
    + ". ";

outputMessage += age switch
{
    >= 21 => "Welcome to the class.",
    _ => $"You have to wait {21 - age} years to join the class.",
};

Console.WriteLine(outputMessage);

void ShowAppInfo()
{
    Console.WriteLine("####################################");
    Console.WriteLine("####### CSharpStudentCheckTC #######");
    Console.WriteLine("####################################");
    Console.WriteLine();
}

string AskUserForInfo(string message)
{
    Console.Write(message);
    return Console.ReadLine() ?? string.Empty;
}

string AskUserForFirstName()
{
    do
    {
        var firstName = AskUserForInfo("What is your first name: ");

        if (
            string.IsNullOrWhiteSpace(firstName)
            || int.TryParse(firstName, out int intFromName)
            || double.TryParse(firstName, out double doubleFromName)
        )
        {
            Console.WriteLine("Invalid first name.");
            continue;
        }

        return firstName;
    } while (true);
}

int AskUserForAge()
{
    do
    {
        var textAge = AskUserForInfo("What is your age: ");

        if (
            string.IsNullOrWhiteSpace(textAge)
            || !int.TryParse(textAge, out int intFromName)
            || intFromName < 1
            || !double.TryParse(textAge, out double doubleFromName)
        )
        {
            Console.WriteLine("Invalid age.");
            continue;
        }

        return int.Parse(textAge);
    } while (true);
}
