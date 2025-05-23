using listasligadas;
using System.ComponentModel.Design;

var list = new DoublyLinkedList<string>();
var opc = "0";
do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
            Console.Write("Enter the data to insert at the beginning: ");
            var dataAtBeginning = Console.ReadLine();
            if (dataAtBeginning != null)
            {
                list.InsertAtBeginning(dataAtBeginning);
            }
            break;

        case "2":
            Console.Write("Enter the data to insert at the end: ");
            var dataAtEnd = Console.ReadLine();
            if (dataAtEnd != null)
            {
                list.InsertAtEnd(dataAtEnd);
            }
            break;

        case "3":
            Console.WriteLine(list.Getforward());
            break;
        case "4":

            Console.WriteLine(list.GetBackward());
            break;

        case "5":
            Console.Write("Enter the date to remove: ");
            var remove = Console.ReadLine();
            if (remove != null)
            {
                list.Remove(remove);
                Console.WriteLine("Item removed.");
            }
            break;
    }
}
while  (opc != "0");

string Menu()
{
    Console.WriteLine("1. Insert at beginning");
    Console.WriteLine("2. Insert at end");
    Console.WriteLine("3. Show list forward");
    Console.WriteLine("4. Show list backward");
    Console.WriteLine("5. Remove");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Choose an option: ");
    return Console.ReadLine() ?? "0";
}
