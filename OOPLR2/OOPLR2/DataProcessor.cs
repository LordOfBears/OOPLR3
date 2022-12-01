using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace OOPLR3 { }
class DataProcessor<T>
{
    public void DataProcessing(List<IFilm> list)
    {
        Console.WriteLine("================================");
        Console.WriteLine("-------- Рейтинг фильмов -------");
        var top = list
                .Where(x => x.Mark >= 3)
                .Where(x => x.Mark < 5)
                .OrderBy(x => x.Mark)
                .Take(3);
        foreach (IFilm item in top)
        {
            item.PrintInfo();
        }
    }
}
