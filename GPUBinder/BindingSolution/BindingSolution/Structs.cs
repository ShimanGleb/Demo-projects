using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace BindingSolution
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
	public enum GPUImageRotationMode : ulong
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
		// extern void runOnMainQueueWithoutDeadlocking (void (^block)());
		[DllImport ("__Internal")]
		static extern void runOnMainQueueWithoutDeadlocking (Action block);

		// extern void runSynchronouslyOnVideoProcessingQueue (void (^block)());
		[DllImport ("__Internal")]
		static extern void runSynchronouslyOnVideoProcessingQueue (Action block);

		// extern void runAsynchronouslyOnVideoProcessingQueue (void (^block)());
		[DllImport ("__Internal")]
		static extern void runAsynchronouslyOnVideoProcessingQueue (Action block);

		// extern void runSynchronouslyOnContextQueue (GPUImageContext *context, void (^block)());
		[DllImport ("__Internal")]
		static extern void runSynchronouslyOnContextQueue (GPUImageContext context, Action block);

		// extern void runAsynchronouslyOnContextQueue (GPUImageContext *context, void (^block)());
		[DllImport ("__Internal")]
		static extern void runAsynchronouslyOnContextQueue (GPUImageContext context, Action block);

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

