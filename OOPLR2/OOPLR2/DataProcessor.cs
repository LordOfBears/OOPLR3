using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using OOPLR3;

namespace OOPLR3 { }
class DataProcessor<T>
{
    public List<T> DataProcessing(List<IFilm> list)
    {
        var filtredList = list
                .Where(x => x.Mark >= 3)
                .Where(x => x.Mark < 5)
                .OrderBy(x => x.Mark)
                .Reverse()
                .Take(3);
        List<T> top = new List<T>();
        foreach (T item in filtredList)
            top.Add(item);
        return top;
    }
    public List<T> Search(List<IFilm> list, int request)
    {
        if (request < 1)
        {
            throw new MarkException("!!! Ошибка, число должно быть положительным !!!");
        }
        var foundObjects = list.Where(x => x.Mark == request);
        List<T> result = new List<T>();
        foreach (T item in foundObjects)
            result.Add(item);
        return result;
    }
}
