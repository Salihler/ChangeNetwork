using System.Management;
using System.Linq;

var networks = GetAdapters();

int index = 0;

foreach (var m in networks)
{
    index = networks.IndexOf(m);
    Console.WriteLine("Id : {0} Adapter name : {1}",index, m["Name"]);
}

Console.WriteLine("Select network interface...");

var readedId = Console.ReadLine();

bool isNumber = int.TryParse(readedId, out index);

if (!isNumber)
{
    Console.WriteLine("Please type only index of interface. ('0' , '1' etc.)");
    readedId = Console.ReadLine();
}

Console.WriteLine("Select process...");
Console.WriteLine("0 - Disable");
Console.WriteLine("1 - Enable");

int processId;

var readedProcess = Console.ReadLine();

bool processIsNumber = int.TryParse(readedProcess, out processId);

if (!processIsNumber)
{
    Console.WriteLine("Please type only index of process. ('0' , '1' etc.)");
    readedId = Console.ReadLine();
}

change(networks.ElementAt(index), processId);


List<ManagementObject> GetAdapters()
{
    var query = new ObjectQuery("SELECT * FROM MSFT_NetAdapter");
    ManagementScope scope = new ManagementScope("root\\StandardCimv2");

    using (var searcher = new ManagementObjectSearcher(scope, query))
    {
        ManagementObjectCollection queryCollection = searcher.Get();
        return queryCollection.Cast<ManagementObject>().ToList();
    }
}


void change(ManagementObject changedElement, int process)
{
    var obj = new Object[1];
    string processType = "";

    switch (process)
    {
        case 0:
            processType = "Disable";
            break;
        case 1:
            processType = "Enable";
            break;
    }
    try
    {
        object result = changedElement.InvokeMethod(processType, obj);
        Console.WriteLine("Network interface is successfully " + processType + "d");
    }
    catch (System.Exception e)
    {
        Console.WriteLine("Something whent wrong... Process error is - " + e.Message);
    }
}

Console.WriteLine("Press a key to exit...");

Console.ReadKey();