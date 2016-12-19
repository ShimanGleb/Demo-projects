using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace GrayScaleFilter
{
	[StructLayout (LayoutKind.Sequential)]
	public struct GPUTextureOptions
	{
		public uint minFilter;

		public uint magFilter;

		public uint wrapS;

		public uint wrapT;

		public uint internalFormat;

		public uint format;

		public uint type;
	}

	[Native]
	public enum GPUImageRotationMode : nuint
	{
		NoRotation,
		RotateLeft,
		RotateRight,
		FlipVertical,
		FlipHorizonal,
		RotateRightFlipVertical,
		RotateRightFlipHorizontal,
		Rotate180
	}

	static class CFunctions
	{
		// extern dispatch_queue_attr_t GPUImageDefaultQueueAttribute ();
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern OS_dispatch_queue_attr GPUImageDefaultQueueAttribute ();

		// extern void runOnMainQueueWithoutDeadlocking (void (^block)());
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern void runOnMainQueueWithoutDeadlocking (Action block);

		// extern void runSynchronouslyOnVideoProcessingQueue (void (^block)());
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern void runSynchronouslyOnVideoProcessingQueue (Action block);

		// extern void runAsynchronouslyOnVideoProcessingQueue (void (^block)());
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern void runAsynchronouslyOnVideoProcessingQueue (Action block);

		// extern void runSynchronouslyOnContextQueue (GPUImageContext *context, void (^block)());
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern void runSynchronouslyOnContextQueue (GPUImageContext context, Action block);

		// extern void runAsynchronouslyOnContextQueue (GPUImageContext *context, void (^block)());
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern void runAsynchronouslyOnContextQueue (GPUImageContext context, Action block);

		// extern void reportAvailableMemoryForGPUImage (NSString *tag);
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern void reportAvailableMemoryForGPUImage (NSString tag);
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct GPUVector4
	{
		public float one;

		public float two;

		public float three;

		public float four;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct GPUVector3
	{
		public float one;

		public float two;

		public float three;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct GPUMatrix4x4
	{
		public GPUVector4 one;

		public GPUVector4 two;

		public GPUVector4 three;

		public GPUVector4 four;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct GPUMatrix3x3
	{
		public GPUVector3 one;

		public GPUVector3 two;

		public GPUVector3 three;
	}
}
