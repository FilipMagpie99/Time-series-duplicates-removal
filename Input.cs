using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class Input
	{
		public Input(ILogger logger) 
		{
		 Logger = logger;
		}
		public ILogger Logger { get; set; }

		public int PrintInputPairs(List<TimeData> dataStorage, TimeData inputPrevious)
		{
			int changes = 0;
			Console.WriteLine(inputPrevious.ToString());
			foreach (var inputCurrent in dataStorage.Skip(1))
			{
				if (inputCurrent.Message != inputPrevious.Message)
				{
					inputPrevious = inputCurrent;
					Logger.Log(inputCurrent.ToString());
					changes++;
				}

			}
			return changes;
		}
	}
}
