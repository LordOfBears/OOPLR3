using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace OOPLR3 { }
class DataProcessor<T>
{
    public List<T> DataProcessing(List<IFilm> list)
    {
        var filtredList = list
                .Where(x => x.Mark >= 3)
                .Where(x => x.Mark < 5)
                .OrderBy(x => x.Mark)
                .Take(3)
                .Reverse();
        List<T> top = new List<T>();
        foreach (T item in filtredList)
            top.Add(item);
        return top;
    }
    public List<T> Search(List<IFilm> list)
    {
        bool requestWasReded = false;
        int request = 0;
        while (!requestWasReded)
        {
            try
            {
                request = int.Parse(Console.ReadLine());
                requestWasReded = true;
            }
            catch (FormatException e)
            {
                Console.WriteLine("!!! Ошибка, введите число !!!");
            }
        }
        var foundObjects = list.Where(x => x.Mark == request);
        List<T> result = new List<T>();
        foreach (T item in foundObjects)
            result.Add(item);
        return result;
    }
}
