using ConsoleDemo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Service
{
    public class AsyncTest : IExampleService
    {        
        public void DemoTask()
        {
            var sw = new Stopwatch();

            sw.Start();

            #region Async Thread Trace
            //var Tasks = new List<Task>();

            //Tasks.Add(this.InsertData());

            //Tasks.Add(this.GetData());

            //Task.WaitAll();
            #endregion

            #region Parallel Trace
            this.TestParallel(5);

            this.TestParallel(3);
            #endregion

            sw.Stop();

            Console.WriteLine($"工作總計花費時間:{sw.Elapsed.Seconds}");
        } 

        /// <summary>
        /// 新增資料
        /// </summary>
        /// <returns></returns>
        private async Task InsertData()
        {
            Console.WriteLine($"新增資料開始，執行續ID:{Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(5000);

            Console.WriteLine($"新增資料完成，執行續ID:{Thread.CurrentThread.ManagedThreadId}");
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <returns></returns>
        private async Task GetData()
        {
            Console.WriteLine($"取得資料開始，執行續ID:{Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(5000);

            Console.WriteLine($"取得資料完成，執行續ID:{Thread.CurrentThread.ManagedThreadId}");
        }

        /// <summary>
        /// 測試並列執行
        /// </summary>
        /// <param name="times"></param>
        private void TestParallel(int times)
        {
            var works = new List<int>();

            for(var i = 0; i < times; i++)
            {
                works.Add(i + 1);
            }

            Parallel.ForEach(works, work =>
            {
                Console.WriteLine($"工作開始項目{work}啟動，執行續ID:{Thread.CurrentThread.ManagedThreadId}");

                DelayThreeSecondsWork();

                Console.WriteLine($"完成工作項目{work}，執行續ID:{Thread.CurrentThread.ManagedThreadId}");
            });            
        }

        /// <summary>
        /// 模擬Delay工作
        /// </summary>
        private void DelayThreeSecondsWork()
        {
            Thread.Sleep(3000);
        }
    }
}
