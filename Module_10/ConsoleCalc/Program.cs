using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //Synchroon();
            //ASyncOldStyle();
            //TaskDemos();
            //MetFouten();
            //IetsLeuks();
            // MultiTask();
            //MoreFun();
            ParallellePret();
            Console.WriteLine("Klaar");
            Console.ReadLine();
        }

        static object stokje = new object();

        private static void ParallellePret()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            int counter = 0;
            //Random rnd = new Random();
            SemaphoreSlim garage = new SemaphoreSlim(10, 10);
            Parallel.For(0, 50, idx => {
                //Console.WriteLine($"Auto {idx} Staat voor de garage");
                //garage.Wait();
                //Console.WriteLine($"Auto {idx} rijdt in");
                // Task.Delay(10000 + rnd.Next(2000, 5000)).Wait();
                //garage.Release();
                //Console.WriteLine($"Auto {idx} rijdt eruit");

                lock (stokje)
                {
                    int tmp = counter;
                    Task.Delay(1000).Wait();
                    counter = ++tmp;
                    Console.WriteLine(counter);
                }
            });
            Console.WriteLine("Alle threads zijn nu klaar");
        }

        private static void MoreFun()
        {
            CancellationTokenSource nikko = new CancellationTokenSource();

            CancellationToken bommetje = nikko.Token;
            Task.Run(() => { 
                for(;;)
                {
                    Task.Delay(500).Wait();
                    Console.WriteLine($"Leuke text  ({Thread.CurrentThread.ManagedThreadId})");
                    if (bommetje.IsCancellationRequested)
                    {
                        Console.WriteLine("Kabooom");
                        return;
                    }
                }
            });


            Console.ReadLine();
            nikko.Cancel();

            
        }

        private static async void MultiTask()
        {
            int a = 0;
            int b = 0;

            var t1 = Task.Run(async () => {
                await Task.Delay(5000);
                a = 20;
            });
            var t2 = Task.Run(async () =>
            {
                await Task.Delay(3000);
                b = 20;
            });

            await Task.WhenAll(t1, t2);
            int result = a + b;
            Console.WriteLine(result);
        }

        private static async void IetsLeuks()
        {
            //Task<int> t1 = Task.Run<int>(() => {
            //    int res = Add(4, 3);
            //    return res;
            //});

            int res = await AddAsync(4,5);
            Console.WriteLine(res);
            Console.WriteLine("Grappig");
            res = await AddAsync(4, 5);
            Console.WriteLine(res);
            Console.WriteLine("Grappig");
            res = await AddAsync(4, 5);
            Console.WriteLine(res);
            Console.WriteLine("Grappig");

        }

        private static async void MetFouten()
        {
            try
            {
                int result = await Task.Run<int>(() =>
                {
                    int res = Add(4, 3);
                    return res;
                });
                Console.WriteLine(result);
                //.ContinueWith(pt =>
                //{
                //   if ( pt.Exception != null)
                //    {
                //        Console.WriteLine(pt.Exception.InnerException.Message);
                //        return;
                //    }
                //    int result = pt.Result;
                //    Console.WriteLine(result);
                //});
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void TaskDemos()
        {
            Task<int> t1 = new Task<int>(() => {
                int res = Add(4, 3);
                return res;
            });

            t1.ContinueWith(pt => {
                int result = pt.Result;
                Console.WriteLine(result);
            });

            t1.Start();
            //int result = t1.Result;
            //Console.WriteLine(result);
        }

        private static void ASyncOldStyle()
        {
            Func<int, int, int> fn = Add;
            IAsyncResult ar = fn.BeginInvoke(2, 3, ar2=> {
                var result = fn.EndInvoke(ar2);
                Console.WriteLine(result);
            }, null);

            
        }

        private static void Synchroon()
        {
            var result = Add(2, 3);
            Console.WriteLine(result);
        }

        static int Add(int a, int b)
        {
            Task.Delay(5000).Wait();
            //throw new Exception("Ooops");
            return a + b;
        }
        static Task<int> AddAsync(int a, int b)
        {
            return Task.Run(() => Add(a, b));
        }
    }
}
