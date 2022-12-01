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
    public void Search(List<IFilm> list)
    {
        Console.WriteLine("================================");
        Console.WriteLine("-------- Введите оценку --------");
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
        var result = list.Where(x => x.Mark == request);
        if (result.Count() > 0)
        {
            foreach (var item in result)
            {
                item.PrintInfo();
                break;
            }
        }
        else
        {
            Console.WriteLine("================================");
            Console.WriteLine("------- Объект не найден -------");
        }
    }
}
