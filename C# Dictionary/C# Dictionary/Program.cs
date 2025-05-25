// See https://aka.ms/new-console-template for more information

// Create Dictionary
Dictionary<int, string> countries = new Dictionary<int, string>();


// Add Elements To the Dictionary
countries.Add(0, "Yemen");
countries.Add(1, "Oman");
countries.Add(2, "Qatar");
countries.Add(3, "Saudi Arabia");
countries.Add(4, "Iraq");
countries[5] = "Egipt";

// Display Dictionary Elements
foreach (var dectionaryParis in countries)
{
    Console.WriteLine($" {dectionaryParis.Key} : {dectionaryParis.Value}");
}
// Access Dictionary Elements

Console.WriteLine(countries[4]);

// Remove Elements
countries.Remove(0);
// Display Dictionary Elements
foreach (var dectionaryParis in countries)
{
    Console.WriteLine($" {dectionaryParis.Key} : {dectionaryParis.Value}");
}
// Check Dictionary Elements using key
if (countries.ContainsKey(1))
{
    Console.WriteLine("Yes It Does Contain The key");
}
else
{
    Console.WriteLine("No It Does Not Contain The key");

}
// Check Dictionary  using vlaue
if (countries.ContainsValue("Qatar"))
{
    Console.WriteLine("Yes It Does Contain Value");
}
else
{
    Console.WriteLine("No It Does Not Contain The Value");

}


