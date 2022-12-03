
using ConsoleApp1;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


var data = new List<TimeData>
{
	new TimeData("1615560000: 1"),
	new TimeData("1615560005: 1"),
	new TimeData("1615560013: 1"),
	new TimeData("1615560018: 1"),
	new TimeData("1615560024: 0"),
	new TimeData("1615560030: 1"),
	new TimeData("1615560037: 0"),
	new TimeData("1615560042: 0")
};

data.OrderBy(x => x.Timestamp).ToList();
TimeData inputPrevious;
inputPrevious = data.First();
new Input(new Logger()).PrintInputPairs(data, inputPrevious);


public class TimeData
{

    public TimeData(string data)
    {
        var split = data.Split(':');
		Timestamp = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(double.Parse(split.First()));
        Message = int.Parse(split.Last().Trim()) == 1;
	}
    public DateTimeOffset Timestamp { get; private set; }

    public bool Message { get; set; }

	public override string ToString()
	{
        return Timestamp.ToUnixTimeSeconds().ToString() + ": " + (Message ? "1" : "0");
	}

}