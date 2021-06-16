﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppCore.DbModels;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var db = new BikeStoresContext())
            {
                var discountsTask = GetDiscountsAsync();

                var prods = await db.Products.ToListAsync();

                var discunts = await discountsTask;

            }
        }


        static async Task<List<Discount>> GetDiscountsAsync()
        {
            using (var db = new BikeStoresContext())
            {
                return await db.Discounts.ToListAsync();
            }
        }
    }

    //class Program
    //{
    //    static async Task Main(string[] args)
    //    {
    //        Coffee cup = PourCoffee();
    //        Console.WriteLine("coffee is ready");

    //        var eggsTask = FryEggsAsync(2);
    //        var baconTask = FryBaconAsync(3);
    //        var toastTask = MakeToastWithButterAndJamAsync(2);

    //        var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
    //        while (breakfastTasks.Count > 0)
    //        {
    //            Task finishedTask = await Task.WhenAny(breakfastTasks);
    //            if (finishedTask == eggsTask)
    //            {
    //                Console.WriteLine("eggs are ready");
    //            }
    //            else if (finishedTask == baconTask)
    //            {
    //                Console.WriteLine("bacon is ready");
    //            }
    //            else if (finishedTask == toastTask)
    //            {
    //                Console.WriteLine("toast is ready");
    //            }
    //            breakfastTasks.Remove(finishedTask);
    //        }

    //        Console.ReadLine();
    //    }

    //    static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
    //    {
    //        var toast = await ToastBreadAsync(number);
    //        ApplyButter(toast);
    //        ApplyJam(toast);

    //        return toast;
    //    }

    //    private static Juice PourOJ()
    //    {
    //        Console.WriteLine("Pouring orange juice");
    //        return new Juice();
    //    }

    //    private static void ApplyJam(Toast toast) =>
    //        Console.WriteLine("Putting jam on the toast");

    //    private static void ApplyButter(Toast toast) =>
    //        Console.WriteLine("Putting butter on the toast");

    //    private static async Task<Toast> ToastBreadAsync(int slices)
    //    {
    //        for (int slice = 0; slice < slices; slice++)
    //        {
    //            Console.WriteLine("Putting a slice of bread in the toaster");
    //        }
    //        Console.WriteLine("Start toasting...");
    //        await Task.Delay(2000);
    //       // Console.WriteLine("Fire! Toast is ruined!");
    //      //  throw new InvalidOperationException("The toaster is on fire");
    //      //  await Task.Delay(1000);
    //        Console.WriteLine("Remove toast from toaster");

    //        return new Toast();
    //    }

    //    private static async Task<Bacon> FryBaconAsync(int slices)
    //    {
    //        Console.WriteLine($"putting {slices} slices of bacon in the pan");
    //        Console.WriteLine("cooking first side of bacon...");
    //        await Task.Delay(3000);
    //        for (int slice = 0; slice < slices; slice++)
    //        {
    //            Console.WriteLine("flipping a slice of bacon");
    //        }
    //        Console.WriteLine("cooking the second side of bacon...");
    //        await Task.Delay(3000);
    //        Console.WriteLine("Put bacon on plate");

    //        return new Bacon();
    //    }

    //    private static async Task<Egg> FryEggsAsync(int howMany)
    //    {
    //        Console.WriteLine("Warming the egg pan...");
    //        await Task.Delay(3000);
    //        Console.WriteLine($"cracking {howMany} eggs");
    //        Console.WriteLine("cooking the eggs ...");
    //        await Task.Delay(3000);
    //        Console.WriteLine("Put eggs on plate");

    //        return new Egg();
    //    }

    //    private static Coffee PourCoffee()
    //    {
    //        Console.WriteLine("Pouring coffee");
    //        return new Coffee();
    //    }
    //}
}
