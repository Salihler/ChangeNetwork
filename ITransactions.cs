using System.Collections.Generic;
using System.Management;

namespace ChangeNetwork
{
    public interface ITransactions
    {
        public List<ManagementObject> GetAdapters();
        public ManagementObject GetSelectedAdapter(List<ManagementObject> networks);
        public int GetProcess();
        public string Change(ManagementObject changedElement, int process);
    }
}