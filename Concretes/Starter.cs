using System;
using ChangeNetwork.Abstracts;

namespace ChangeNetwork.Concretes
{
    public class Starter
    {
        private readonly ITransactions _transactions;
        public Starter(ITransactions transactions)
        {
            _transactions = transactions;
        }

        public string Start()
        {
            var networks = _transactions.GetAdapters();

            var selectedNetwork = _transactions.GetSelectedAdapter(networks);

            int process = _transactions.GetProcess();

            string result = _transactions.Change(selectedNetwork, process);

            Console.WriteLine(result);

            Console.WriteLine("Would you like to change another adepter setting? y \\ n");

            return Console.ReadLine();
        }
    }
}