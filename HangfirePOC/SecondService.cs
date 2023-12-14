using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangfirePOC
{
    public class SecondService
    {
        public void FirstOfMonthTask(Guid taskId)
        {
            Console.WriteLine($"SecondService - First of Month Task executed at: {DateTime.Now}, Task ID: {taskId}");
        }
    }
}
