using System.Linq;
namespace zadachinaseminar
{
    public class log
    {
        public int number { get; private set; }
        public int day { get; private set; }

        public log(int num,int d) 
        { 
            number = num;
            day = d;
        }
    }
    
    public static class all
    {
        public static void Main()
        {
            var start = new Random();
            List<log> c = new List<log>();
            Dictionary<int,string> daysofweek = new Dictionary<int,string>();
            daysofweek.Add(1, DayOfWeek.Monday.ToString());
            daysofweek.Add(2, DayOfWeek.Tuesday.ToString());
            daysofweek.Add(3, DayOfWeek.Wednesday.ToString());
            daysofweek.Add(4, DayOfWeek.Thursday.ToString());
            daysofweek.Add(5, DayOfWeek.Friday.ToString());
            daysofweek.Add(6, DayOfWeek.Saturday.ToString());
            daysofweek.Add(7, DayOfWeek.Sunday.ToString());
            for (int i = 0; i < 365; i++) c.Add(new log(start.Next(0, 1000),i%7));
            var l=c.GroupBy(x => x.day);
            foreach(var x in l) 
            {
                var sum=x.Sum(x=>x.number)/x.Count();
                Console.Write(daysofweek[x.Key+1] + ": ");
                Console.Write(sum+"\n");
            }
            Console.WriteLine("FP2 is done");
            var newmethod = Generate(Console.ReadLine);
            Func<string, bool> foo1 = g => g == string.Empty;
            Func<string, bool> foo2 =null;
            var allstrings=newmethod.TakeUntil(foo1).ToList();
            Console.WriteLine("FP3/2 is done");
            var allstrings_1= newmethod.TakeUntil(foo2).ToList();
            Console.WriteLine("FP3/1 is done");
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var e in enumerable)
                if (predicate(e))
                    yield return e;
        }

        static IEnumerable<T> Generate<T>(Func<T> makeNext)
        {
            while (true)
            {
                yield return makeNext();
            }

        }
        static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, bool> shouldStop)
        {
            if(shouldStop==null)
            {
                foreach (var e in source)
                {
                    if (e.ToString()==string.Empty) yield break;
                    yield return e;
                }
                yield break;
            }
            bool t = false;
            Func<T, bool> newfoo=null;
            foreach (var e in source) 
            {         
                newfoo = r => shouldStop(e) && t;
                if (newfoo(e))
                {
                        yield break;
                }              
                t = e.ToString() == string.Empty;
                yield return e;
            }
        }
    }
}