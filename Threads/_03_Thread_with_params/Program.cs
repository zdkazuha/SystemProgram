﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Thread_with_params
{
    class Program
    {
        static void ThreadFunk(object a)
        {
            string ID = (string)a;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(ID + " " +  i);
                //Console.ReadKey();
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            //ParameterizedThreadStart threadstart = new ParameterizedThreadStart(ThreadFunk);
            Thread thread1 = new Thread(ThreadFunk);
            thread1.Start((object)"One");

            Thread thread2 = new Thread(ThreadFunk);
            thread2.Start("\t\tTwo");
            Console.ReadKey();
            Console.WriteLine("End!");
        }
    }
}