﻿using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    public static void Main()
    {
        bool gogo = true;
        int lastValueAll = 0, lastValueFilms = 0, lastValueBooks = 0; ;
        List<IArt> all = new List<IArt>();

        List<IFilm> filmsAndSerials = new List<IFilm>();
        List<Book> books = new List<Book>();

        while (gogo)
        {
            int n_sortedStyle = 1000;
            Console.WriteLine("================================");
            Console.WriteLine("------- Сколько фильмов? -------");
            int countFilms = int.Parse(Console.ReadLine());
            Console.WriteLine("------- Сколько сериалов? ------");
            int countSerials = int.Parse(Console.ReadLine());
            Console.WriteLine("------- Сколько книг? ----------");
            int countBooks = int.Parse(Console.ReadLine());
            Console.WriteLine("================================");

            for (int i = lastValueFilms; i < lastValueFilms + countFilms + countSerials; i++)
            {
                if (i < lastValueFilms + countFilms)
                {
                    Console.WriteLine("------------ Фильм " + (i + 1 - lastValueFilms) + " -----------");
                    Console.WriteLine("--- Введите название фильма " + (i + 1 - lastValueFilms) + " --");
                    string name = Console.ReadLine();
                    Console.WriteLine("---- Введите оценку фильма " + (i + 1 - lastValueFilms) + " ---");
                    int mark = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("----- Укажите жанр фильма " + (i + 1 - lastValueFilms) + " ----");
                    int style = Convert.ToInt32(Console.ReadLine());
                    filmsAndSerials.Add(new Film(name, mark, style));
                }
                if (i == lastValueFilms + countFilms) Console.WriteLine("================================");
                if ((i >= lastValueFilms + countFilms) && (i < lastValueFilms + countSerials + countFilms))
                {
                    Console.WriteLine("----------- Сериал " + (i + 1 - countFilms - lastValueFilms) + " -----------");
                    Console.WriteLine("-- Введите название сериала " + (i + 1 - countFilms - lastValueFilms) + " --");
                    string name = Console.ReadLine();
                    Console.WriteLine("--- Введите оценку сериала " + (i + 1 - countFilms - lastValueFilms) + " ---");
                    int mark = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("---- Укажите жанр сериала " + (i + 1 - countFilms - lastValueFilms) + " ----");
                    int style = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("-- Укажите количество серий " + (i + 1 - countFilms - lastValueFilms) + " --");
                    int numberParts = Convert.ToInt32(Console.ReadLine());
                    filmsAndSerials.Add(new Serial(name, mark, style, numberParts));
                }
            }
            Console.WriteLine("================================");
            for (int i = lastValueBooks; i < lastValueBooks + countBooks; i++)
            {
                Console.WriteLine("------------ Книга " + (i + 1 - lastValueBooks) + " -----------");
                Console.WriteLine("Введите название книги " + (i + 1 - lastValueBooks));
                string name = Console.ReadLine();
                books.Add(new Book(name));
            }
            lastValueFilms += countFilms + countSerials;
            lastValueBooks += countBooks;
            Console.WriteLine("================================");
            double middleMark = 0;
            int maxMark = 0, minMark = 1000000, gettedMark;
            for (int i = 0; i < lastValueFilms; i++)
            {
                gettedMark = filmsAndSerials[i].Mark;
                middleMark += gettedMark;
                if (maxMark < gettedMark)
                {
                    maxMark = gettedMark;
                }
                if (minMark > gettedMark)
                {
                    minMark = gettedMark;
                }
            }
            middleMark /= lastValueFilms;
            if (middleMark % 1 > 0)
                middleMark = middleMark - middleMark % 0.001;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("--->>> Средняя оценка:   " + middleMark);
            Console.WriteLine("--->>> Максимальная оценка: " + maxMark);
            Console.WriteLine("--->>> Минимальная оценка: " + minMark);
            Console.WriteLine("================================");
            Console.WriteLine();
            int[] sortedStyle = new int[n_sortedStyle];
            for (int i = 0; i < n_sortedStyle; i++)
                sortedStyle[i] = 0;
            for (int i = 0; i < lastValueFilms; i++)
            {
                sortedStyle[filmsAndSerials[i].Style]++;
            }

            int count_1;
            double middleMarkStyle;
            for (int i = 0; i < sortedStyle.Length; i++)
            {
                if (sortedStyle[i] != 0)
                {
                    count_1 = 0;
                    middleMarkStyle = 0;
                    for (int j = 0; j < lastValueFilms; j++)
                    {
                        if (filmsAndSerials[j].Style == i)
                        {
                            count_1++;
                            middleMarkStyle += filmsAndSerials[j].Mark;
                        }
                    }
                    middleMarkStyle /= count_1;
                    if (middleMarkStyle % 1 > 0)
                        middleMarkStyle = middleMarkStyle - middleMarkStyle % 0.001;
                    Console.WriteLine("================================");
                    Console.WriteLine("-->> Жанр " + i + ": просмотрено " + sortedStyle[i]);
                    Console.WriteLine("-->> Средняя оценка: " + middleMarkStyle);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("================================");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("================================");
            Console.WriteLine("----- Информация обо всём ------");

            for (int i = lastValueAll; i < lastValueAll + countFilms; i++)
            {
                all.Add(filmsAndSerials[i - lastValueAll]);
            }
            for (int i = lastValueAll + countFilms; i < lastValueAll + countFilms + countSerials; i++)
            {
                all.Add(filmsAndSerials[i - lastValueAll]);
            }
            for (int i = lastValueAll + countFilms + countSerials; i < lastValueAll + countFilms + countSerials + countBooks; i++)
            {
                all.Add(books[i - (countFilms + countSerials + lastValueAll)]);
            }

            lastValueAll += countFilms + countSerials + countBooks;

            for (int i = 0; i < lastValueAll; i++)
            {
                Console.WriteLine("================================");
                Console.WriteLine("<<<--- Объект: " + (i + 1));
                all[i].PrintInfo();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("-------- Рейтинг фильмов -------");
            var filtred = filmsAndSerials.Where(x => x.Mark >= 3).Where(x => x.Mark < 5);
            int k = 0, topOneMark = 0, topTwoMark = 0, topThreeMark = 0;
            List<IFilm> top = new List<IFilm>();
            top.Add(new Film("", 0, 0));
            top.Add(new Film("", 0, 0));
            top.Add(new Film("", 0, 0));
            foreach (var item in filtred)
            {
                if (item.Mark > topThreeMark)
                {
                    if (item.Mark > topTwoMark)
                    {
                        if (item.Mark > topOneMark)
                        {
                            top[1] = top[0];
                            top[0] = item;
                            topTwoMark = topOneMark;
                            topOneMark = item.Mark;
                        }
                        else
                        {
                            top[2] = top[1];
                            top[1] = item;
                            topThreeMark = topTwoMark;
                            topTwoMark = item.Mark;
                        }
                    }
                    else
                    {
                        top[2] = item;
                        topThreeMark = item.Mark;
                    }
                }
            }
            top.Reverse();
            foreach (var item in top)
            {
                if ((k < 3) && (item.Mark > 0))
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("------------- ТОП " + (3 - k) + " ------------");
                    item.PrintInfo();
                }
                else if (k > 2)
                    break;
                k++;
            }
            bool getAnswer = false;
            while (!getAnswer)
            {
                Console.WriteLine("================================");
                Console.WriteLine("---------- Что делать? ---------");
                Console.WriteLine("-->> 1. Найти фильм/сериал");
                Console.WriteLine("-->> 2. Перезапустить программу");
                Console.WriteLine("-->> 3. Дополнить данные");
                Console.WriteLine("-->> 4. Завершить работу");
                int usersAnswer = int.Parse(Console.ReadLine());
                switch (usersAnswer)
                {
                    case 1:
                        Console.WriteLine("================================");
                        Console.WriteLine("-------- Введите оценку --------");
                        int request = int.Parse(Console.ReadLine());
                        var result = filmsAndSerials.Where(x => x.Mark == request);
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
                        break;
                    case 2:
                        getAnswer = true;
                        Console.Clear();
                        lastValueAll = 0;
                        lastValueFilms = 0;
                        lastValueBooks = 0;
                        break;
                    case 3:
                        getAnswer = true;
                        Console.Clear();
                        break;
                    case 4:
                        getAnswer = true;
                        gogo = false;
                        break;
                }
            }
        }
    }
}