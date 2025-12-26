namespace AsyncThread
{
    /// <summary>
    /// 1 进程-线程-多线程，同步和异步
    /// 2 委托启动异步调用
    /// 3 多线程特点：不卡主线程、速度快、无序性
    /// 4 异步的回调和状态参数
    /// 5 异步等待三种方式
    /// 6 异步返回值
    /// 
    /// 
    /// 进程：计算机概念，程序在服务器运行时占据全部计算资源综总和
    ///       虚拟的，
    /// 线程：计算机概念，进程在响应操作时最小单位，也包含CPU 内存  网络  硬盘IO
    ///       虚拟的概念，更加看不见摸不着
    /// 一个进程会包含多个线程；线程隶属于某个进程，进程销毁线程也就没了
    /// 句柄：其实是个long数字，是操作系统标识应用程序
    /// 多线程：计算机概念，一个进程有多个线程同时运行
    /// 
    /// C#里面的多线程：
    /// Thread类是C#语言对线程对象的一个封装
    /// 
    /// 为什么可以多线程呢？
    /// 1 多个CPU的核可以并行工作，
    ///   4核8线程，这里的线程指的是模拟核
    ///   
    /// 2 CPU分片，1s的处理能力分成1000份，操作系统调度着去响应不同的任务
    ///   从宏观角度来说，感觉就是多个任务在并发执行
    ///   从微观角度来说，一个物理cpu同一时刻只能为一个任务服务
    /// 
    /// 并行:多核之间叫并行
    /// 并发：CPU分片的并发
    ///   
    /// 同步异步：
    ///       同步方法：发起调用，完成后才继续下一行；非常符合开发思维，有序执行；
    ///                 诚心诚意的请人吃饭，邀请Nick，Nick要忙一会儿，等着Nick完成后，再一起去吃饭
    ///       异步方法：发起调用，不等待完成，直接进入下一行，启动一个新线程来完成方法的计算
    ///                 客气一下的请人吃饭，邀请亡五，亡五要忙一会儿，你忙着我去吃饭了，你忙完自己去吃饭吧
    /// </summary>
    public partial class frmThreads : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public frmThreads()
        {
            InitializeComponent();
            AllocConsole();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnSync_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");

            // 添加计时器
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnSync_Click_{i}");
                this.DoSomethingLong(name);
            }

            stopwatch.Stop();
            Console.WriteLine($"同步方法总耗时: {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"****************btnSync_Click   End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
        }

        #region Private Method
        /// <summary>
        /// 一个比较耗时耗资源的私有方法
        /// </summary>
        /// <param name="name"></param>
        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"****************DoSomethingLong Start  {name}  {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }
            //Thread.Sleep(2000);

            Console.WriteLine($"****************DoSomethingLong   End  {name}  {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {lResult}***************");
        }
        #endregion

        #region Async
        /// <summary>
        /// 异步方法
        /// 1 同步方法卡界面：主线程(UI线程)忙于计算，无暇他顾
        ///   异步多线程方法不卡界面：主线程闲置，计算任务交给子线程完成
        ///   改善用户体验，winform点击个按钮不至于卡死；
        ///   web应用发个短信通知，异步多线程去发短信；
        /// 
        /// 2 同步方法慢，只有一个线程计算
        ///   异步多线程方法快，因为5个线程并发计算
        ///   12658ms   3636ms  不到4倍   CPU密集型计算(资源受限)
        ///   10126ms    2075ms  差不多5倍，也不到5倍，Sleep(资源够用)
        ///   多线程其实是资源换性能，1 资源不是无限的  2 资源调度损耗
        ///   
        ///   一个订单表统计很耗时间，能不能多线程优化下性能？  不能！这就是一个操作，没法并行
        ///   需要查询数据库/调用接口/读硬盘文件/做数据计算，能不能多线程优化下性能？ 可以，多个任务可以并行
        ///   线程不是越多越好，因为资源有限，而且调用有损耗
        ///   
        /// 3 同步方法有序进行，异步多线程无序
        ///   启动无序：线程资源是向操作系统申请的，由操作系统的调度策略决定，所以启动顺序随机
        ///   同一个任务同一个线程，执行时间也不确定，CPU分片
        ///   以上相加，结束也无序
        ///   使用多线程请一定小心，很多事儿不是相当然的，尤其是多线程操作间有顺序要求的时候，
        ///   通过延迟一点启动来控制顺序？或者预计下结束顺序？  这些都不靠谱！
        ///   
        ///   需要控制顺序，晚点分解！
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsync_Click Start {Thread.CurrentThread.ManagedThreadId:00} {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}***************");

            // 添加计时器
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // 将每个耗时操作放到线程池，不阻塞 UI，等待全部完成
            var tasks = Enumerable.Range(0, 5)
                                  .Select(i => Task.Run(() => DoSomethingLong($"btnAsync_Click_{i}")))
                                  .ToArray();

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                // 处理子任务异常（Task.WhenAll 会聚合异常）
                Console.WriteLine($"子任务异常: {ex}");
            }

            stopwatch.Stop();
            Console.WriteLine($"异步方法总耗时: {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"****************btnAsync_Click End   {Thread.CurrentThread.ManagedThreadId:00} {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}***************");
        }
        #endregion


        #region btnAsyncAdvanced_Click
        private void btnAsyncAdvanced_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsync_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");

            //Action<string> action = this.DoSomethingLong;

            ////1 回调：将后续动作通过回调参数传递进去，子线程完成计算后，去调用这个回调委托
            //IAsyncResult asyncResult = null;//是对异步调用操作的描述
            //AsyncCallback callback = ar =>
            //{
            //    Console.WriteLine($"{object.ReferenceEquals(ar, asyncResult)}");
            //    Console.WriteLine($"btnAsyncAdvanced_Click计算成功了。{ar.AsyncState}。{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            //};
            //asyncResult = action.BeginInvoke("btnAsyncAdvanced_Click", callback, "花生");

            //////2 通过IsComplate等待，卡界面--主线程在等待，边等待边提示
            //////（ Thread.Sleep(200);位置变了，少了一句99.9999）
            ////int i = 0;
            ////while (!asyncResult.IsCompleted)
            ////{
            ////    if (i < 9)
            ////    {
            ////        Console.WriteLine($"中华民族复兴完成{++i * 10}%....");
            ////    }
            ////    else
            ////    {
            ////        Console.WriteLine($"中华民族复兴完成99.999999%....");
            ////    }
            ////    Thread.Sleep(200);
            ////}
            ////Console.WriteLine("中华民族复兴已完成，沉睡的东方雄狮已觉醒！");

            ////3 WaitOne等待，即时等待  限时等待
            ////asyncResult.AsyncWaitHandle.WaitOne();//直接等待任务完成
            ////asyncResult.AsyncWaitHandle.WaitOne(-1);//一直等待任务完成
            ////asyncResult.AsyncWaitHandle.WaitOne(1000);//最多等待1000ms，超时就不等了

            ////4 EndInvoke  即时等待,而且可以获取委托的返回值 一个异步操作只能End一次
            ////action.EndInvoke(asyncResult);//等待某次异步调用操作结束

            ////Console.WriteLine("全部计算成功了。。");

            Func<int> func = () =>
            {
                Thread.Sleep(2000);
                return DateTime.Now.Hour;
            };
            int iResult = func.Invoke();//22
            IAsyncResult asyncResult = func.BeginInvoke(ar =>
            {
                //int iEndResultIn = func.EndInvoke(ar);
            }, null);
            int iEndResult = func.EndInvoke(asyncResult);//22

            Console.WriteLine($"****************btnAsync_Click End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
        }
        #endregion
    }
}
