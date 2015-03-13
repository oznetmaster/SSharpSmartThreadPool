using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharpPro.CrestronThread;

namespace Crestron.SimplSharpPro.CrestronThread
	{
	public class ThreadEx : Thread
		{
		private static int _lastExIdHigh;
		private static int _lastExId;

		private readonly long _threadExId;

		public ThreadEx (Crestron.SimplSharpPro.CrestronThread.ThreadCallbackFunction threadCallbackFunc, object userDefinedObject)
			: base (threadCallbackFunc, userDefinedObject)
			{
			_threadExId = Interlocked.Increment (ref _lastExId) | (long)(_threadExId == 0 ? Interlocked.Increment (ref _lastExIdHigh) : _lastExIdHigh) << 32;
			}

		public ThreadEx (Crestron.SimplSharpPro.CrestronThread.ThreadCallbackFunction threadCallbackFunc, object userDefinedObject,
		                 Crestron.SimplSharpPro.CrestronThread.Thread.eThreadStartOptions threadStartOption)
			: base (threadCallbackFunc, userDefinedObject, threadStartOption)
			{
			_threadExId = Interlocked.Increment (ref _lastExId) | (long)(_threadExId == 0 ? Interlocked.Increment (ref _lastExIdHigh) : _lastExIdHigh) << 32;
			}

		public long ThreadExId
			{
			get
				{
				return _threadExId;
				}
			}

		public override int GetHashCode ()
			{
			return (int)_threadExId ^ ((int)(_threadExId >> 32));
			}

		public override bool Equals (object obj)
			{
			return obj is long && _threadExId == (long)obj;
			}

		public new void Join ()
			{
			Join (Timeout.Infinite);
			}

		public new bool Join (int millisecondTimeout)
			{
			try
				{
				return base.Join (millisecondTimeout);
				}
			catch (NullReferenceException)
				{
				return true;
				}
			}

		public bool Join (TimeSpan timeout)
			{
			long lmsec = (long)timeout.TotalMilliseconds;
			if (lmsec < 0 || lmsec > Int32.MaxValue)
				throw new ArgumentOutOfRangeException ("timeout", "timeout exceed maximum milliseconds");

			return Join ((int)lmsec);
			}

		public static ThreadEx CurrentThread
			{
			get
				{
				
				}
			}
		}
	}