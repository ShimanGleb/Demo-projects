//
// Auto-generated from generator.cs, do not edit
//
// We keep references to objects, so warning 414 is expected

#pragma warning disable 414

using System;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using UIKit;
using GLKit;
using Metal;
using MapKit;
using ModelIO;
using Security;
using SceneKit;
using AudioUnit;
using CoreVideo;
using CoreMedia;
using QuickLook;
using Foundation;
using CoreMotion;
using ObjCRuntime;
using AddressBook;
using CoreGraphics;
using CoreLocation;
using AVFoundation;
using NewsstandKit;
using CoreAnimation;
using CoreFoundation;

namespace BindingSolution {
	[Register("GPUImageContext", true)]
	public unsafe abstract partial class GPUImageContext : NSObject {
		
		[CompilerGenerated]
		static readonly IntPtr class_ptr = Class.GetHandle ("GPUImageContext");
		
		public override IntPtr ClassHandle { get { return class_ptr; } }
		
		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("init")]
		protected GPUImageContext () : base (NSObjectFlag.Empty)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
			if (IsDirectBinding) {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, global::ObjCRuntime.Selector.GetHandle ("init")), "init");
			} else {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, global::ObjCRuntime.Selector.GetHandle ("init")), "init");
			}
		}

		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected GPUImageContext (NSObjectFlag t) : base (t)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
		}

		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected internal GPUImageContext (IntPtr handle) : base (handle)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
		}

		[Export ("endProcessing")]
		[CompilerGenerated]
		public abstract void EndProcessing ();
		[Export ("newFrameReadyAtTime:atIndex:")]
		[CompilerGenerated]
		public abstract void NewFrameReadyAtTime (global::CoreMedia.CMTime frameTime, global::System.nint textureIndex);
		[Export ("setCurrentlyReceivingMonochromeInput:")]
		[CompilerGenerated]
		public abstract void SetCurrentlyReceivingMonochromeInput (bool newValue);
		[Export ("setInputFramebuffer:atIndex:")]
		[CompilerGenerated]
		public abstract void SetInputFramebuffer (GPUImageFramebuffer newInputFramebuffer, global::System.nint textureIndex);
		[Export ("setInputRotation:atIndex:")]
		[CompilerGenerated]
		public abstract void SetInputRotation (GPUImageRotationMode newInputRotation, global::System.nint textureIndex);
		[Export ("setInputSize:atIndex:")]
		[CompilerGenerated]
		public abstract void SetInputSize (CGSize newSize, global::System.nint textureIndex);
		[CompilerGenerated]
		public abstract bool Enabled {
			[Export ("enabled")]
			get; 
		}
		
		[CompilerGenerated]
		public abstract CGSize MaximumOutputSize {
			[Export ("maximumOutputSize")]
			get; 
		}
		
		[CompilerGenerated]
		public abstract global::System.nint NextAvailableTextureIndex {
			[Export ("nextAvailableTextureIndex")]
			get; 
		}
		
		[CompilerGenerated]
		public abstract bool ShouldIgnoreUpdatesToThisTarget {
			[Export ("shouldIgnoreUpdatesToThisTarget")]
			get; 
		}
		
		[CompilerGenerated]
		public abstract bool WantsMonochromeInput {
			[Export ("wantsMonochromeInput")]
			get; 
		}
		
	} /* class GPUImageContext */
}
