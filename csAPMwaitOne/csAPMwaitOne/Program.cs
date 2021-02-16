using System;
using System.IO;
using System.Net;
using System.Threading;

namespace csAPMwaitOne
{
    class Program
    {
        private static void ResponseCallback(IAsyncResult ar)
        {
            HttpWebRequest request = ar.AsyncState as HttpWebRequest;
            Console.WriteLine("Callback 1");
            Thread.Sleep(3000);
            Console.WriteLine("Callback 2");
            HttpWebResponse webResponse = request.EndGetResponse(ar) as HttpWebResponse;//取得資料
            Console.WriteLine("Callback 3");

            Stream ReceiveStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(ReceiveStream);
            string result = reader.ReadToEnd();

            Console.WriteLine("Callback 4");
        }
        static void Main(string[] args)
        {
            try
            {
                string url = $"https://hyperfullstack.azurewebsites.net/api/HandOnLab/Add/1/2/5";

                // 針對非同步請求，產生委派方法，用於處理非同步工作執行完成後的結果
                AsyncCallback callBack = new AsyncCallback(ResponseCallback);

                // 使用 WebRequest.Create 工廠方法建立一個 HttpWebrequest 物件
                HttpWebRequest myHttpWebRequest1 = (HttpWebRequest)WebRequest.Create(url);

                // 呼叫 BeginXXX 啟動非同步工作
                Console.WriteLine("Main 1");
                IAsyncResult asyncResult =
                  (IAsyncResult)myHttpWebRequest1.BeginGetResponse(callBack, myHttpWebRequest1);

                Console.WriteLine("Main 2");
                asyncResult.AsyncWaitHandle.WaitOne();
                Console.WriteLine("Main 3");

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"   處理其他事情");
                    Thread.Sleep(1000);
                }

                // 主執行緒的工作已經完成
                Console.WriteLine("Press any key for continuing...");
                Console.ReadKey();
            }
            catch (WebException e)
            {
                Console.WriteLine("\nException raised!");
                Console.WriteLine("\nMessage:{0}", e.Message);
                Console.WriteLine("\nStatus:{0}", e.Status);
                Console.WriteLine("Press any key to continue..........");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException raised!");
                Console.WriteLine("Source :{0} ", e.Source);
                Console.WriteLine("Message :{0} ", e.Message);
                Console.WriteLine("Press any key to continue..........");
                Console.Read();
            }
        }
    }
}
