ShowAppInfo();

var partyGroups = new List<(string, int)>();

do
{
    Console.WriteLine();

    var partyName = AskForPartyName();
    var numberOfGuests = AskForNumberOfGuests();

    partyGroups.Add((partyName, numberOfGuests));

    Console.WriteLine();
} while (AskForContinueLooping());

ShowGroups(partyGroups);
ShowTotalNumberOfGuests(partyGroups);

void ShowAppInfo()
{
    Console.WriteLine("##########################");
    Console.WriteLine("####### Guest Book #######");
    Console.WriteLine("##########################");
}

string AskForUserInfo(string message)
{
    Console.WriteLine(message);
    return Console.ReadLine() ?? string.Empty;
}

string AskForPartyName()
{
    do
    {
        var partyName = AskForUserInfo("What is your party name: ");

        if (
            string.IsNullOrWhiteSpace(partyName)
            || int.TryParse(partyName, out _)
            || double.TryParse(partyName, out _)
        )
        {
            Console.WriteLine("Invalid party name.");
            continue;
        }

        return partyName;
    } while (true);
}

int AskForNumberOfGuests()
{
    do
    {
        var numberOfGuests = AskForUserInfo("What is the number of your party: ");
        if (
            string.IsNullOrWhiteSpace(numberOfGuests)
            || !int.TryParse(numberOfGuests, out _)
            || !double.TryParse(numberOfGuests, out _)
        )
        {
            Console.WriteLine("Invalid number of guests.");
            continue;
        }

        return int.Parse(numberOfGuests);
    } while (true);
}

bool AskForContinueLooping()
{
    var continueLooping = AskForUserInfo("Do you want to continue (yes/no): ");

    return string.IsNullOrWhiteSpace(continueLooping) || continueLooping.ToLower() == "yes";
}

void ShowGroups(List<(string, int)> partyGroups)
{
    foreach (var (partyName, numberOfGuests) in partyGroups)
    {
        Console.WriteLine($"Party name: {partyName} - Number of guests: {numberOfGuests}");
    }
}

void ShowTotalNumberOfGuests(List<(string, int)> partyGroups) =>
    Console.WriteLine($"The total number of guests is {partyGroups.Sum(group => group.Item2)}");
