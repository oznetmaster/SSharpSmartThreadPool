
using System;
using Crestron.SimplSharp;
using Crestron.SimplSharpPro.CrestronThread;
using ThreadPriority = Crestron.SimplSharpPro.CrestronThread.Thread.eThreadPriority;
using WaitHandle = Crestron.SimplSharp.CEventHandle;

using NUnit.Framework;

using Amib.SSharpThreading;

namespace SmartThreadPoolTests
	{
	/// <summary>
	/// Summary description for TestThreadPriority.
	/// </summary>
	[TestFixture]
	[Category ("TestThreadPriority")]
	public class TestThreadPriority
		{
		[Test]
		public void TestDefaultPriority ()
			{
			CheckSinglePriority (SmartThreadPool.DefaultThreadPriority);
			}

		[Test]
		public void TestLowestPriority ()
			{
			CheckSinglePriority (ThreadPriority.LowestPriority);
			}

#if !SSHARP
        [Test]
        public void TestBelowNormalPriority()
		{
            CheckSinglePriority(ThreadPriority.BelowNormal);
		}
#endif
		[Test]
		public void TestNormalPriority ()
			{
			CheckSinglePriority (ThreadPriority.MediumPriority);
			}

#if !SSHARP
		[Test]
		public void TestAboveNormalPriority ()
			{
			CheckSinglePriority (ThreadPriority.AboveNormal);
			}
#endif

		[Test]
		public void TestHighestPriority ()
			{
			CheckSinglePriority (ThreadPriority.HighPriority);
			}

		private void CheckSinglePriority (ThreadPriority threadPriority)
			{
			STPStartInfo stpStartInfo = new STPStartInfo ();
			stpStartInfo.ThreadPriority = threadPriority;

			SmartThreadPool stp = new SmartThreadPool (stpStartInfo);

			IWorkItemResult wir = stp.QueueWorkItem (new WorkItemCallback (GetThreadPriority));
			ThreadPriority currentThreadPriority = (ThreadPriority)wir.GetResult ();

			Assert.AreEqual (threadPriority, currentThreadPriority);
			}

		private object GetThreadPriority (object state)
			{
			return Thread.CurrentThread.Priority;
			}
		}
	}