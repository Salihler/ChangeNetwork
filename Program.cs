using ChangeNetwork;

string result = "y";

Starter starter = new Starter(new Transactions());

while (result == "y")
{
    result = starter.Start();
}