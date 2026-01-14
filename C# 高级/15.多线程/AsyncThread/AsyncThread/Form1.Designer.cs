namespace AsyncThread
{
    partial class frmThreads
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSync = new Button();
            btnAsync = new Button();
            btnAsyncAdvanced = new Button();
            btnThread = new Button();
            btnThreadPool = new Button();
            SuspendLayout();
            // 
            // btnSync
            // 
            btnSync.Location = new Point(139, 66);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(137, 68);
            btnSync.TabIndex = 0;
            btnSync.Text = "同步方法";
            btnSync.UseVisualStyleBackColor = true;
            btnSync.Click += btnSync_Click;
            // 
            // btnAsync
            // 
            btnAsync.Location = new Point(139, 166);
            btnAsync.Name = "btnAsync";
            btnAsync.Size = new Size(137, 63);
            btnAsync.TabIndex = 1;
            btnAsync.Text = "Async";
            btnAsync.UseVisualStyleBackColor = true;
            btnAsync.Click += btnAsync_Click;
            // 
            // btnAsyncAdvanced
            // 
            btnAsyncAdvanced.Location = new Point(139, 262);
            btnAsyncAdvanced.Name = "btnAsyncAdvanced";
            btnAsyncAdvanced.Size = new Size(174, 63);
            btnAsyncAdvanced.TabIndex = 2;
            btnAsyncAdvanced.Text = "AsyncAdvanced";
            btnAsyncAdvanced.UseVisualStyleBackColor = true;
            btnAsyncAdvanced.Click += btnAsyncAdvanced_Click;
            // 
            // btnThread
            // 
            btnThread.Location = new Point(139, 365);
            btnThread.Name = "btnThread";
            btnThread.Size = new Size(164, 52);
            btnThread.TabIndex = 3;
            btnThread.Text = "Thread";
            btnThread.UseVisualStyleBackColor = true;
            btnThread.Click += btnThread_Click;
            // 
            // btnThreadPool
            // 
            btnThreadPool.Location = new Point(139, 473);
            btnThreadPool.Name = "btnThreadPool";
            btnThreadPool.Size = new Size(164, 46);
            btnThreadPool.TabIndex = 4;
            btnThreadPool.Text = "ThreadPool";
            btnThreadPool.UseVisualStyleBackColor = true;
            btnThreadPool.Click += btnThreadPool_Click;
            // 
            // frmThreads
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 585);
            Controls.Add(btnThreadPool);
            Controls.Add(btnThread);
            Controls.Add(btnAsyncAdvanced);
            Controls.Add(btnAsync);
            Controls.Add(btnSync);
            Name = "frmThreads";
            Text = "frmThreads";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSync;
        private Button btnAsync;
        private Button btnAsyncAdvanced;
        private Button btnThread;
        private Button btnThreadPool;
    }
}
