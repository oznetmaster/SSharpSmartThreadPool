
using NUnit.Framework;
using Amib.SSharpThreading;

namespace SmartThreadPoolTests
{
	/// <summary>
    /// Tests for QueueWorkItem.
	/// </summary>
	[TestFixture]
    [Category("TestQueueWorkItem")]
    public class TestQueueWorkItem
	{
        private SmartThreadPool _stp;

        [SetUp]
        public void Init()
        {
            _stp = new SmartThreadPool();
        }

        [TearDown]
        public void Fini()
        {
            _stp.Shutdown();
        }

        //IWorkItemResult QueueWorkItem(WorkItemCallback callback);
        [Test]
        public void TestQueueWorkItemCall()
        {
            QueueWorkItemHelper.TestQueueWorkItemCall(_stp);
        }

        //IWorkItemResult QueueWorkItem(WorkItemCallback callback, WorkItemPriority workItemPriority);
        [Test]
        public void TestQueueWorkItemCallPrio()
        {
            QueueWorkItemHelper.TestQueueWorkItemCallPrio(_stp);
        }

        //IWorkItemResult QueueWorkItem(WorkItemCallback callback, object state);
        [Test]
        public void TestQueueWorkItemCallStat()
        {
            QueueWorkItemHelper.TestQueueWorkItemCallStat(_stp);
        }

        //IWorkItemResult QueueWorkItem(WorkItemCallback callback, object state, WorkItemPriority workItemPriority);
        [Test]
        public void TestQueueWorkItemCallStatPrio()
        {
            QueueWorkItemHelper.TestQueueWorkItemCallStatPrio(_stp);
        }

        //IWorkItemResult QueueWorkItem(WorkItemCallback callback, object state, PostExecuteWorkItemCallback postExecuteWorkItemCallback);
        [Test]
        public void TestQueueWorkItemCallStatPost()
        {
            QueueWorkItemHelper.TestQueueWorkItemCallStatPost(_stp);
        }

        //IWorkItemResult QueueWorkItem(WorkItemCallback callback, object state, PostExecuteWorkItemCallback postExecuteWorkItemCallback, WorkItemPriority workItemPriority);
        [Test]
        public void TestQueueWorkItemCallStatPostPrio()
        {
            QueueWorkItemHelper.TestQueueWorkItemCallStatPostPrio(_stp);
        }

        //IWorkItemResult QueueWorkItem(WorkItemCallback callback, object state, PostExecuteWorkItemCallback postExecuteWorkItemCallback, CallToPostExecute callToPostExecute);
        [Test]
        public void TestQueueWorkItemCallStatPostPflg()
        {
            QueueWorkItemHelper.TestQueueWorkItemCallStatPostPflg(_stp);
        }
        
        //IWorkItemResult QueueWorkItem(WorkItemCallback callback, object state, PostExecuteWorkItemCallback postExecuteWorkItemCallback, CallToPostExecute callToPostExecute, WorkItemPriority workItemPriority);
        [Test]
        public void TestQueueWorkItemCallStatPostPflgPrio()
        {
            QueueWorkItemHelper.TestQueueWorkItemCallStatPostPflgPrio(_stp);
        }

        //IWorkItemResult QueueWorkItem(WorkItemInfo workItemInfo, WorkItemCallback callback);
        [Test]
        public void TestQueueWorkItemInfoCall()
        {
            QueueWorkItemHelper.TestQueueWorkItemInfoCall(_stp);
        }

        //IWorkItemResult QueueWorkItem(WorkItemInfo workItemInfo, WorkItemCallback callback, object state);
        [Test]
        public void TestQueueWorkItemInfoCallStat()
        {
            QueueWorkItemHelper.TestQueueWorkItemInfoCallStat(_stp);
        }
	}
}
