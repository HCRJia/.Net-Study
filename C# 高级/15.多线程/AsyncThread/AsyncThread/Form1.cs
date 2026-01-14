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
        private async void btnAsyncAdvanced_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsyncAdvanced_Click Start {Thread.CurrentThread.ManagedThreadId:00} {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}***************");

            // 下面把原来基于 Delegate.BeginInvoke/EndInvoke 的示例全部用 Task/async-await/ContinueWith 重写，
            // 并保留为注释形式以供对比学习（运行时不要使用 BeginInvoke，因为在 .NET Core/.NET 5+ 平台上不受支持）。

            // 旧：通过委托 BeginInvoke 回调示例 (已移除)
            //Action<string> action = this.DoSomethingLong;
            //IAsyncResult asyncResult = null;
            //AsyncCallback callback = ar =>
            //{
            //    Console.WriteLine($"{object.ReferenceEquals(ar, asyncResult)}");
            //    Console.WriteLine($"btnAsyncAdvanced_Click计算成功了。{ar.AsyncState}。{Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            //};
            //asyncResult = action.BeginInvoke("btnAsyncAdvanced_Click", callback, "花生");

            // 新（等价的 Task/回调 写法，注释以保留示例）：
            //Action<string> action = this.DoSomethingLong;
            //var t = Task.Run(() => action("btnAsyncAdvanced_Click"));
            //t.ContinueWith(t2 =>
            //{
            //    if (t2.IsCompletedSuccessfully)
            //    {
            //        Console.WriteLine($"btnAsyncAdvanced_Click 计算成功（回调）. {Thread.CurrentThread.ManagedThreadId:00}");
            //    }
            //    else if (t2.IsFaulted)
            //    {
            //        Console.WriteLine($"子任务异常: {t2.Exception}");
            //    }
            //}, TaskScheduler.FromCurrentSynchronizationContext()); // 回到 UI 线程执行回调

            ////// 旧：通过 IsCompleted 轮询等待（会卡界面示例，已注释）
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

            // 新（不阻塞 UI 的轮询示例，注释保留）：
            //var pollingTask = Task.Run(async () =>
            //{
            //    int i = 0;
            //    while (!t.IsCompleted)
            //    {
            //        if (i < 9) Console.WriteLine($"完成{++i * 10}%....");
            //        else Console.WriteLine($"完成99.999999%....");
            //        await Task.Delay(200); // 不阻塞 UI 线程
            //    }
            //    Console.WriteLine("已完成");
            //});

            ////// 旧：使用 AsyncWaitHandle.WaitOne 等待（已注释）
            ////asyncResult.AsyncWaitHandle.WaitOne();
            ////asyncResult.AsyncWaitHandle.WaitOne(-1);
            ////asyncResult.AsyncWaitHandle.WaitOne(1000);

            // 新（替代等待/限时等待，注释保留）：
            //var completed = await Task.WhenAny(t, Task.Delay(1000));
            //if (completed == t) Console.WriteLine("任务在超时时间内完成");
            //else Console.WriteLine("等待超时，未等到任务完成");

            ////// 旧：EndInvoke 阻塞等待并获取返回值（已注释）
            ////action.EndInvoke(asyncResult);

            // 新（使用 await 获取返回值，注释保留）：
            Func<int> func = () =>
            {
                Thread.Sleep(2000);
                return DateTime.Now.Hour;
            };
            var task = Task.Run(func);
            task.ContinueWith(t2 =>
            {
                if (t2.IsCompletedSuccessfully) Console.WriteLine($"回调（UI）结果: {t2.Result}");
                else Console.WriteLine($"子任务异常: {t2.Exception}");
            }, TaskScheduler.FromCurrentSynchronizationContext());
            int result = await task; // await 取代 EndInvoke

            // ------- 活动示例（使用 Task 替代 BeginInvoke/EndInvoke） -------
            Func<int> funcActive = () =>
            {
                Thread.Sleep(2000);
                return DateTime.Now.Hour;
            };

            // 保留同步调用示例（立即返回结果）
            int iResult = funcActive.Invoke(); // 同步调用示例

            // 异步启动任务，放到线程池执行
            var runningTask = Task.Run(funcActive);

            // 如果需要在子任务完成时在 UI 线程执行回调，使用 ContinueWith + FromCurrentSynchronizationContext
            runningTask.ContinueWith(t =>
            {
                if (t.IsCompletedSuccessfully)
                {
                    Console.WriteLine($"回调（UI线程）结果: {t.Result}");
                }
                else if (t.IsFaulted)
                {
                    Console.WriteLine($"子任务异常: {t.Exception}");
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());

            // await 获取最终结果（替代 EndInvoke）
            int iEndResult = await runningTask;

            Console.WriteLine($"****************btnAsyncAdvanced_Click End   {Thread.CurrentThread.ManagedThreadId:00} {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} 结果:{iEndResult}***************");
        }
        #endregion

        #region Thread
        /// <summary>
        /// 多线程1.0
        /// Thread:C#对线程对象的一个封装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThread_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnThread_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            {
                ParameterizedThreadStart method = o => this.DoSomethingLong("btnThread_Click");
                Thread thread = new Thread(method);
                thread.Start("123");//开启线程，执行委托的内容
            }
            {
                ThreadStart method = () =>
                {
                    Thread.Sleep(5000);
                    this.DoSomethingLong("btnThread_Click");
                    Thread.Sleep(5000);
                };
                Thread thread = new Thread(method);
                thread.Start();//开启线程，执行委托的内容
                //thread.Suspend();//暂停
                //thread.Resume();//恢复    真的不该要的，暂停不一定马上暂停；让线程操作太复杂了
                //thread.Abort();
                ////线程是计算机资源，程序想停下线程，只能向操作系统通知(线程抛异常)，
                ////会有延时/不一定能真的停下来
                //Thread.ResetAbort();
                //1等待
                //while (thread.ThreadState != ThreadState.Stopped)
                //{
                //    Thread.Sleep(200);//当前线程休息200ms
                //}
                //2 Join等待
                //thread.Join();//运行这句代码的线程，等待thread的完成
                //thread.Join(1000);//最多等待1000ms

                //Console.WriteLine("这里是线程执行完之后才操作。。。");

                //thread.Priority = ThreadPriority.Highest;
                ////最高优先级：优先执行，但不代表优先完成  甚至说极端情况下，还有意外发生，不能通过这个来控制线程的执行先后顺序
                thread.IsBackground = false;//默认是false 前台线程，进程关闭，线程需要计算完后才退出
                //thread.IsBackground = true;//关闭进程，线程退出
            }

            {
                ThreadStart threadStart = () => this.DoSomethingLong("btnThread_Click");
                Action actionCallBack = () =>
                  {
                      Thread.Sleep(2000);
                      Console.WriteLine($"This is Calllback {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                  };
                this.ThreadWithCallBack(threadStart, actionCallBack);
            }
            {
                Func<int> func = () =>
                    {
                        Thread.Sleep(5000);
                        return DateTime.Now.Year;
                    };
                Func<int> funcThread = this.ThreadWithReturn(func);//非阻塞
                Console.WriteLine("do something else/////");
                Console.WriteLine("do something else/////");
                Console.WriteLine("do something else/////");
                Console.WriteLine("do something else/////");
                Console.WriteLine("do something else/////");

                int iResult = funcThread.Invoke();//阻塞
            }
            {
                //List<Thread> threads = new List<Thread>();
                //for (int i = 0; i < 100; i++)
                //{
                //    if (threads.Count(t => t.ThreadState == ThreadState.Running) < 10)
                //    {
                //        Thread thread = new Thread(new ThreadStart(() => { }));
                //        thread.Start();
                //        threads.Add(thread);
                //    }
                //    else
                //    {
                //        Thread.Sleep(200);
                //    }
                //}
            }
            {
                //问题：比如有10个任务，每个任务都启动一个线程，每个线程都需要执行一段时间，最用要等待10个线程都执行完成，然后触发另外一个任务将前10个任务执行的结果打包返回，这样的场景怎么处理
                //启动10个thread---返回值保存到一个公开的集合(注意线程安全)---等待10个线程--都完成list就已经包含了全部结果
            }
            Console.WriteLine($"****************btnThread_Click End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
        }
        //线程等待Join    回调？  获取返回值？

        //基于thread封装一个回调
        //回调：启动子线程执行动作A--不阻塞--A执行完后子线程会执行动作B
        /// <summary>
        /// 
        /// </summary>
        /// <param name="threadStart">多线程执行的操作</param>
        /// <param name="actionCallback">线程完成后，回调的动作</param>
        private void ThreadWithCallBack(ThreadStart threadStart, Action actionCallback)
        {
            //Thread thread = new Thread(threadStart);
            //thread.Start();
            //thread.Join();//错了，因为方法被阻塞了
            //actionCallback.Invoke();

            ThreadStart method = new ThreadStart(() =>
            {
                threadStart.Invoke();
                actionCallback.Invoke();
            });
            new Thread(method).Start();
        }



        /// <summary>
        /// 1 异步，非阻塞的
        /// 2 还能获取到最终计算结果
        /// 
        /// 既要不阻塞，又要计算结果？不可能！
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        private Func<T> ThreadWithReturn<T>(Func<T> func)
        {
            T t = default(T);
            ThreadStart threadStart = new ThreadStart(() =>
            {
                t = func.Invoke();
            });
            Thread thread = new Thread(threadStart);
            thread.Start();

            return new Func<T>(() =>
            {
                thread.Join();
                //thread.ThreadState
                return t;
            });
        }


        #endregion

        #region ThreadPool
        /// <summary>
        /// Thread--功能繁多，反而用不好--就像给4岁小孩一把热武器，反而会造成更大的伤害
        /// 对线程数量是没有管控的
        /// 
        /// 线程池.NetFramework2.0
        /// 如果某个对象创建和销毁代价比较高，同时这个对象还可以反复使用的，就需要一个池子
        /// 保存多个这样的对象，需要用的时候从池子里面获取；用完之后不用销毁，放回池子；(享元模式)
        /// 节约资源提升性能；此外，还能管控总数量，防止滥用；
        /// 
        /// ThreadPool的线程都是后台线程
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnThreadPool_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            {
                //ThreadPool.QueueUserWorkItem(o => this.DoSomethingLong("btnThreadPool_Click1"));
                //ThreadPool.QueueUserWorkItem(o => this.DoSomethingLong("btnThreadPool_Click2"), "昔梦");
            }

            {
                //ThreadPool.GetMaxThreads(out int workerThreads, out int completionPortThreads);
                //Console.WriteLine($"当前电脑最大workerThreads={workerThreads} 最大completionPortThreads={completionPortThreads}");

                //ThreadPool.GetMinThreads(out int workerThreadsMin, out int completionPortThreadsMin);
                //Console.WriteLine($"当前电脑最小workerThreads={workerThreadsMin} 最大completionPortThreads={completionPortThreadsMin}");

                ////设置的线程池数量是进程全局的，
                ////委托异步调用--Task--Parrallel--async/await 全部都是线程池的线程
                ////直接new Thread不受这个数量限制的(但是会占用线程池的线程数量)
                //ThreadPool.SetMaxThreads(8, 8);//设置的最大值，必须大于CPU核数，否则设置无效
                //ThreadPool.SetMinThreads(2, 2);
                //Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&设置最大最小&&&&&&&&&&&&&&&&&&&&&&&&&&&");

                //ThreadPool.GetMaxThreads(out int workerThreads1, out int completionPortThreads1);
                //Console.WriteLine($"当前电脑最大workerThreads={workerThreads1} 最大completionPortThreads={completionPortThreads1}");

                //ThreadPool.GetMinThreads(out int workerThreadsMin1, out int completionPortThreadsMin1);
                //Console.WriteLine($"当前电脑最大workerThreads={workerThreadsMin1} 最大completionPortThreads={completionPortThreadsMin1}");
            }

            {
                ////等待
                //ManualResetEvent mre = new ManualResetEvent(false);
                ////false---关闭---Set打开---true---WaitOne就能通过
                ////true---打开--ReSet关闭---false--WaitOne就只能等待
                //ThreadPool.QueueUserWorkItem(o =>
                //{
                //    this.DoSomethingLong("btnThreadPool_Click1");
                //    mre.Set();
                //});
                //Console.WriteLine("Do Something else...");
                //Console.WriteLine("Do Something else...");
                //Console.WriteLine("Do Something else...");

                //mre.WaitOne();
                //Console.WriteLine("任务已经完成了。。。");
            }
            {
                //不要阻塞线程池里面的线程
                ThreadPool.SetMaxThreads(8, 8);
                ManualResetEvent mre = new ManualResetEvent(false);
                for (int i = 0; i < 10; i++)
                {
                    int k = i;
                    ThreadPool.QueueUserWorkItem(t =>
                    {
                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId.ToString("00")} show {k}");
                        if (k == 9)
                        {
                            mre.Set();
                        }
                        else
                        {
                            mre.WaitOne();
                        }
                    });
                }
                if (mre.WaitOne())
                {
                    Console.WriteLine("任务全部执行成功！");
                }
            }

            Console.WriteLine($"****************btnThreadPool_Click End   {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
        }
        #endregion
    }
}
