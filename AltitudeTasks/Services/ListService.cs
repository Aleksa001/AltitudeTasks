using AltitudeTasks.Class;
using AltitudeTasks.Interfaces;

namespace AltitudeTasks.Services
{
    public class ListService : IListService
    {
        public List<int> Proccess(ListInput input)
        {
            List<int> result = new List<int>();
            switch (input.Operation)
            {
                case "deduplicate":
                    result = input.Data.Distinct().OrderBy(x => x).ToList();
                    break;
                case "getPairs":
                    result  = GetPairs(input.Data);
                    break;
                default:
                    throw new NotImplementedException("Invalid operation!");
            }
            return result;
        }

        public List<int> GetPairs(List<int> data)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            List<int> result = new List<int>(); 
            foreach (var value in data)
            {
                if (pairs.ContainsKey(value))
                {
                    pairs[value]++;
                }
                else
                {
                    pairs[value] = 1;
                }
            }
            foreach(var pair in pairs)
            {
                if(pair.Value > 1)
                {
                    result.Add(pair.Key);
                }
               
            }
            return result.Distinct().OrderBy(x => x).ToList();

        }
    }
}
