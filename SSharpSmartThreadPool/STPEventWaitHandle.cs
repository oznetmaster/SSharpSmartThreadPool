#if !(_WINDOWS_CE) || SSHARP

using System;
using Crestron.SimplSharp;
using Crestron.SimplSharpPro.CrestronThread;
using SSharp.Threading;

namespace Amib.SSharpThreading.Internal
	{
#if _WINDOWS ||  WINDOWS_PHONE || SSHARP
	internal static class STPEventWaitHandle
		{
		public const int WaitTimeout = Timeout.Infinite;

		internal static bool WaitAll (WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext)
			{
			return WaitHandle.WaitAll (waitHandles, millisecondsTimeout);
			}

		internal static int WaitAny (WaitHandle[] waitHandles)
			{
			return WaitHandle.WaitAny (waitHandles);
			}

		internal static int WaitAny (WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext)
			{
			return WaitHandle.WaitAny (waitHandles, millisecondsTimeout);
			}

		internal static bool WaitOne (WaitHandle waitHandle, int millisecondsTimeout, bool exitContext)
			{
			return waitHandle.WaitOne (millisecondsTimeout);
			}
		}
#else
    internal static class STPEventWaitHandle
    {
        public const int WaitTimeout = Timeout.Infinite;

        internal static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext)
        {
            return WaitHandle.WaitAll(waitHandles, millisecondsTimeout, exitContext);
        }

        internal static int WaitAny(WaitHandle[] waitHandles)
        {
            return WaitHandle.WaitAny(waitHandles);
        }

        internal static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext)
        {
            return WaitHandle.WaitAny(waitHandles, millisecondsTimeout, exitContext);
        }

        internal static bool WaitOne(WaitHandle waitHandle, int millisecondsTimeout, bool exitContext)
        {
            return waitHandle.WaitOne(millisecondsTimeout, exitContext);
        }
    }
#endif

	}

#endif