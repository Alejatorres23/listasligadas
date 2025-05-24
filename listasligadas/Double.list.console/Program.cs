using listasligadas;

var list = new DoublyLinkedList<string>();
string? opc;

do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
            Console.Write("Enter data to insert (ordered): ");
            var ordered = Console.ReadLine();
            if (ordered != null)
                list.InsertOrdered(ordered);
            break;

        case "2":
            Console.WriteLine("Forward: " + list.Getforward());
            break;

        case "3":
            Console.WriteLine("Backward: " + list.GetBackward());
            break;

        case "4":
            list.SortDescending();
            Console.WriteLine("List sorted descending:");
            Console.WriteLine(list.Getforward());
            break;

        case "5":
            var modes = list.GetModes();
            Console.WriteLine("Mode(s): " + string.Join(", ", modes));
            break;

        case "6":
            Console.WriteLine("Graph:");
            foreach (var kv in list.GetFrequency())
                Console.WriteLine($"{kv.Key} {new string('*', kv.Value)}");
            break;

        case "7":
            Console.Write("Enter value to check: ");
            var exists = Console.ReadLine();
            Console.WriteLine(list.Exists(exists!) ? "Exists" : "Does not exist");
            break;

        case "8":
            Console.Write("Enter value to remove one occurrence: ");
            var r1 = Console.ReadLine();
            list.RemoveOne(r1!);
            Console.WriteLine("Updated list:");
            Console.WriteLine(list.Getforward());
            break;

        case "9":
            Console.Write("Enter value to remove all occurrences: ");
            var r2 = Console.ReadLine();
            list.RemoveAll(r2!);
            Console.WriteLine("Updated list:");
            Console.WriteLine(list.Getforward());
            break;
    }
}
while (opc != "0");

string Menu()
{
    Console.WriteLine("\n--- MENU ---");
    Console.WriteLine("1. Add (Ordered)");
    Console.WriteLine("2. Show Forward");
    Console.WriteLine("3. Show Backward");
    Console.WriteLine("4. Sort Descending and Show");
    Console.WriteLine("5. Show Mode(s)");
    Console.WriteLine("6. Show Graph");
    Console.WriteLine("7. Exists?");
    Console.WriteLine("8. Remove One Occurrence");
    Console.WriteLine("9. Remove All Occurrences");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    return Console.ReadLine() ?? "0";
}
