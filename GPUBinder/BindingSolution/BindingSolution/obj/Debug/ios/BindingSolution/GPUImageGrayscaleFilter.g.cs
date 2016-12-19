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
	[Register("GPUImageGrayscaleFilter", true)]
	public unsafe partial class GPUImageGrayscaleFilter : GPUImageFilter {
		
		[CompilerGenerated]
		static readonly IntPtr class_ptr = Class.GetHandle ("GPUImageGrayscaleFilter");
		
		public override IntPtr ClassHandle { get { return class_ptr; } }
		
		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("init")]
		public GPUImageGrayscaleFilter () : base (NSObjectFlag.Empty)
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
		protected GPUImageGrayscaleFilter (NSObjectFlag t) : base (t)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
		}

		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected internal GPUImageGrayscaleFilter (IntPtr handle) : base (handle)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
		}

		[Export ("addTarget:")]
		[CompilerGenerated]
		public new virtual void AddTarget (GPUImageInput newTarget)
		{
			if (newTarget == null)
				throw new ArgumentNullException ("newTarget");
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("addTarget:"), newTarget.Handle);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("addTarget:"), newTarget.Handle);
			}
		}
		
		[Export ("addTarget:atTextureLocation:")]
		[CompilerGenerated]
		public new virtual void AddTarget (GPUImageInput newTarget, global::System.nint textureLocation)
		{
			if (newTarget == null)
				throw new ArgumentNullException ("newTarget");
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr_nint (this.Handle, Selector.GetHandle ("addTarget:atTextureLocation:"), newTarget.Handle, textureLocation);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr_nint (this.SuperHandle, Selector.GetHandle ("addTarget:atTextureLocation:"), newTarget.Handle, textureLocation);
			}
		}
		
		[Export ("forceProcessingAtSize:")]
		[CompilerGenerated]
		public new virtual void ForceProcessingAtSize (CGSize frameSize)
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_CGSize (this.Handle, Selector.GetHandle ("forceProcessingAtSize:"), frameSize);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_CGSize (this.SuperHandle, Selector.GetHandle ("forceProcessingAtSize:"), frameSize);
			}
		}
		
		[Export ("forceProcessingAtSizeRespectingAspectRatio:")]
		[CompilerGenerated]
		public new virtual void ForceProcessingAtSizeRespectingAspectRatio (CGSize frameSize)
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_CGSize (this.Handle, Selector.GetHandle ("forceProcessingAtSizeRespectingAspectRatio:"), frameSize);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_CGSize (this.SuperHandle, Selector.GetHandle ("forceProcessingAtSizeRespectingAspectRatio:"), frameSize);
			}
		}
		
		[Export ("imageByFilteringImage:")]
		[CompilerGenerated]
		public new virtual global::UIKit.UIImage ImageByFilteringImage (global::UIKit.UIImage imageToFilter)
		{
			if (imageToFilter == null)
				throw new ArgumentNullException ("imageToFilter");
			if (IsDirectBinding) {
				return  Runtime.GetNSObject<global::UIKit.UIImage> (global::ApiDefinition.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("imageByFilteringImage:"), imageToFilter.Handle));
			} else {
				return  Runtime.GetNSObject<global::UIKit.UIImage> (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("imageByFilteringImage:"), imageToFilter.Handle));
			}
		}
		
		[Export ("imageFromCurrentFramebufferWithOrientation:")]
		[CompilerGenerated]
		public new virtual global::UIKit.UIImage ImageFromCurrentFramebufferWithOrientation (global::UIKit.UIImageOrientation imageOrientation)
		{
			if (IsDirectBinding) {
				if (IntPtr.Size == 8) {
					return  Runtime.GetNSObject<global::UIKit.UIImage> (global::ApiDefinition.Messaging.IntPtr_objc_msgSend_Int64 (this.Handle, Selector.GetHandle ("imageFromCurrentFramebufferWithOrientation:"), (Int64)imageOrientation));
				} else {
					return  Runtime.GetNSObject<global::UIKit.UIImage> (global::ApiDefinition.Messaging.IntPtr_objc_msgSend_int (this.Handle, Selector.GetHandle ("imageFromCurrentFramebufferWithOrientation:"), (int)imageOrientation));
				}
			} else {
				if (IntPtr.Size == 8) {
					return  Runtime.GetNSObject<global::UIKit.UIImage> (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_Int64 (this.SuperHandle, Selector.GetHandle ("imageFromCurrentFramebufferWithOrientation:"), (Int64)imageOrientation));
				} else {
					return  Runtime.GetNSObject<global::UIKit.UIImage> (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_int (this.SuperHandle, Selector.GetHandle ("imageFromCurrentFramebufferWithOrientation:"), (int)imageOrientation));
				}
			}
		}
		
		[Export ("initializeAttributes")]
		[CompilerGenerated]
		public virtual void InitializeAttributes ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("initializeAttributes"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("initializeAttributes"));
			}
		}
		
		[Export ("newCGImageByFilteringCGImage:")]
		[CompilerGenerated]
		public new virtual CGImage NewCGImageByFilteringCGImage (CGImage imageToFilter)
		{
			if (imageToFilter == null)
				throw new ArgumentNullException ("imageToFilter");
			IntPtr ret;
			if (IsDirectBinding) {
				ret = global::ApiDefinition.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("newCGImageByFilteringCGImage:"), imageToFilter.Handle);
			} else {
				ret = global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("newCGImageByFilteringCGImage:"), imageToFilter.Handle);
			}
			return ret == IntPtr.Zero ? null : new global::CoreGraphics.CGImage (ret);
		}
		
		[Export ("newCGImageByFilteringImage:")]
		[CompilerGenerated]
		public new virtual CGImage NewCGImageByFilteringImage (global::UIKit.UIImage imageToFilter)
		{
			if (imageToFilter == null)
				throw new ArgumentNullException ("imageToFilter");
			IntPtr ret;
			if (IsDirectBinding) {
				ret = global::ApiDefinition.Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("newCGImageByFilteringImage:"), imageToFilter.Handle);
			} else {
				ret = global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("newCGImageByFilteringImage:"), imageToFilter.Handle);
			}
			return ret == IntPtr.Zero ? null : new global::CoreGraphics.CGImage (ret);
		}
		
		[Export ("notifyTargetsAboutNewOutputTexture")]
		[CompilerGenerated]
		public new virtual void NotifyTargetsAboutNewOutputTexture ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("notifyTargetsAboutNewOutputTexture"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("notifyTargetsAboutNewOutputTexture"));
			}
		}
		
		[Export ("removeAllTargets")]
		[CompilerGenerated]
		public new virtual void RemoveAllTargets ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("removeAllTargets"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("removeAllTargets"));
			}
		}
		
		[Export ("removeOutputFramebuffer")]
		[CompilerGenerated]
		public new virtual void RemoveOutputFramebuffer ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("removeOutputFramebuffer"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("removeOutputFramebuffer"));
			}
		}
		
		[Export ("removeTarget:")]
		[CompilerGenerated]
		public new virtual void RemoveTarget (GPUImageInput targetToRemove)
		{
			if (targetToRemove == null)
				throw new ArgumentNullException ("targetToRemove");
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("removeTarget:"), targetToRemove.Handle);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("removeTarget:"), targetToRemove.Handle);
			}
		}
		
		[Export ("renderToTextureWithVertices:")]
		[CompilerGenerated]
		public virtual void RenderToTextureWithVertices (float vertices)
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_float (this.Handle, Selector.GetHandle ("renderToTextureWithVertices:"), vertices);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_float (this.SuperHandle, Selector.GetHandle ("renderToTextureWithVertices:"), vertices);
			}
		}
		
		[Export ("rotatedSize:forIndex:")]
		[CompilerGenerated]
		public virtual CGSize RotatedSize (CGSize sizeToRotate, global::System.nint textureIndex)
		{
			CGSize ret;
			if (IsDirectBinding) {
				if (Runtime.Arch == Arch.DEVICE) {
					if (IntPtr.Size == 8) {
						ret = global::ApiDefinition.Messaging.CGSize_objc_msgSend_CGSize_nint (this.Handle, Selector.GetHandle ("rotatedSize:forIndex:"), sizeToRotate, textureIndex);
					} else {
						global::ApiDefinition.Messaging.CGSize_objc_msgSend_stret_CGSize_nint (out ret, this.Handle, Selector.GetHandle ("rotatedSize:forIndex:"), sizeToRotate, textureIndex);
					}
				} else if (IntPtr.Size == 8) {
					ret = global::ApiDefinition.Messaging.CGSize_objc_msgSend_CGSize_nint (this.Handle, Selector.GetHandle ("rotatedSize:forIndex:"), sizeToRotate, textureIndex);
				} else {
					ret = global::ApiDefinition.Messaging.CGSize_objc_msgSend_CGSize_nint (this.Handle, Selector.GetHandle ("rotatedSize:forIndex:"), sizeToRotate, textureIndex);
				}
			} else {
				if (Runtime.Arch == Arch.DEVICE) {
					if (IntPtr.Size == 8) {
						ret = global::ApiDefinition.Messaging.CGSize_objc_msgSendSuper_CGSize_nint (this.SuperHandle, Selector.GetHandle ("rotatedSize:forIndex:"), sizeToRotate, textureIndex);
					} else {
						global::ApiDefinition.Messaging.CGSize_objc_msgSendSuper_stret_CGSize_nint (out ret, this.SuperHandle, Selector.GetHandle ("rotatedSize:forIndex:"), sizeToRotate, textureIndex);
					}
				} else if (IntPtr.Size == 8) {
					ret = global::ApiDefinition.Messaging.CGSize_objc_msgSendSuper_CGSize_nint (this.SuperHandle, Selector.GetHandle ("rotatedSize:forIndex:"), sizeToRotate, textureIndex);
				} else {
					ret = global::ApiDefinition.Messaging.CGSize_objc_msgSendSuper_CGSize_nint (this.SuperHandle, Selector.GetHandle ("rotatedSize:forIndex:"), sizeToRotate, textureIndex);
				}
			}
			return ret;
		}
		
		[Export ("setInputFramebufferForTarget:atIndex:")]
		[CompilerGenerated]
		public new virtual void SetInputFramebufferForTarget (GPUImageInput target, global::System.nint inputTextureIndex)
		{
			if (target == null)
				throw new ArgumentNullException ("target");
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr_nint (this.Handle, Selector.GetHandle ("setInputFramebufferForTarget:atIndex:"), target.Handle, inputTextureIndex);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr_nint (this.SuperHandle, Selector.GetHandle ("setInputFramebufferForTarget:atIndex:"), target.Handle, inputTextureIndex);
			}
		}
		
		[Export ("setupFilterForSize:")]
		[CompilerGenerated]
		public virtual void SetupFilterForSize (CGSize filterFrameSize)
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_CGSize (this.Handle, Selector.GetHandle ("setupFilterForSize:"), filterFrameSize);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_CGSize (this.SuperHandle, Selector.GetHandle ("setupFilterForSize:"), filterFrameSize);
			}
		}
		
		[Export ("useNextFrameForImageCapture")]
		[CompilerGenerated]
		public new virtual void UseNextFrameForImageCapture ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("useNextFrameForImageCapture"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("useNextFrameForImageCapture"));
			}
		}
		
		[CompilerGenerated]
		public virtual bool CurrentlyReceivingMonochromeInput {
			[Export ("currentlyReceivingMonochromeInput")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("currentlyReceivingMonochromeInput"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("currentlyReceivingMonochromeInput"));
				}
			}
			
			[Export ("setCurrentlyReceivingMonochromeInput:")]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_bool (this.Handle, Selector.GetHandle ("setCurrentlyReceivingMonochromeInput:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, Selector.GetHandle ("setCurrentlyReceivingMonochromeInput:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual bool Enabled {
			[Export ("enabled")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("enabled"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("enabled"));
				}
			}
			
			[Export ("setEnabled:")]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_bool (this.Handle, Selector.GetHandle ("setEnabled:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, Selector.GetHandle ("setEnabled:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual GPUImageFramebuffer FramebufferForOutput {
			[Export ("framebufferForOutput")]
			get {
				GPUImageFramebuffer ret;
				if (IsDirectBinding) {
					ret =  Runtime.GetNSObject<GPUImageFramebuffer> (global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.GetHandle ("framebufferForOutput")));
				} else {
					ret =  Runtime.GetNSObject<GPUImageFramebuffer> (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("framebufferForOutput")));
				}
				return ret;
			}
			
		}
		
		[CompilerGenerated]
		public unsafe virtual global::System.Action<GPUImageOutput, global::CoreMedia.CMTime> FrameProcessingCompletionBlock {
			[return: DelegateProxy (typeof (ObjCRuntime.Trampolines.SDActionArity2V0))]
			[Export ("frameProcessingCompletionBlock", ArgumentSemantic.Copy)]
			get {
				IntPtr ret;
				if (IsDirectBinding) {
					ret = global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.GetHandle ("frameProcessingCompletionBlock"));
				} else {
					ret = global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("frameProcessingCompletionBlock"));
				}
				return global::ObjCRuntime.Trampolines.NIDActionArity2V0.Create (ret);
			}
			
			[Export ("setFrameProcessingCompletionBlock:", ArgumentSemantic.Copy)]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				BlockLiteral *block_ptr_value;
				BlockLiteral block_value;
				block_value = new BlockLiteral ();
				block_ptr_value = &block_value;
				block_value.SetupBlock (Trampolines.SDActionArity2V0.Handler, value);
				
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("setFrameProcessingCompletionBlock:"), (IntPtr) block_ptr_value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("setFrameProcessingCompletionBlock:"), (IntPtr) block_ptr_value);
				}
				block_ptr_value->CleanupBlock ();
				
			}
		}
		
		[CompilerGenerated]
		public virtual global::UIKit.UIImage ImageFromCurrentFramebuffer {
			[Export ("imageFromCurrentFramebuffer")]
			get {
				global::UIKit.UIImage ret;
				if (IsDirectBinding) {
					ret =  Runtime.GetNSObject<global::UIKit.UIImage> (global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.GetHandle ("imageFromCurrentFramebuffer")));
				} else {
					ret =  Runtime.GetNSObject<global::UIKit.UIImage> (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("imageFromCurrentFramebuffer")));
				}
				return ret;
			}
			
		}
		
		[CompilerGenerated]
		public virtual CGImage NewCGImageFromCurrentlyProcessedOutput {
			[Export ("newCGImageFromCurrentlyProcessedOutput")]
			get {
				IntPtr ret;
				if (IsDirectBinding) {
					ret = global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.GetHandle ("newCGImageFromCurrentlyProcessedOutput"));
				} else {
					ret = global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("newCGImageFromCurrentlyProcessedOutput"));
				}
				return ret == IntPtr.Zero ? null : new global::CoreGraphics.CGImage (ret);
			}
			
		}
		
		[CompilerGenerated]
		public virtual bool ProvidesMonochromeOutput {
			[Export ("providesMonochromeOutput")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("providesMonochromeOutput"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("providesMonochromeOutput"));
				}
			}
			
		}
		
		[CompilerGenerated]
		public virtual bool ShouldIgnoreUpdatesToThisTarget {
			[Export ("shouldIgnoreUpdatesToThisTarget")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("shouldIgnoreUpdatesToThisTarget"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("shouldIgnoreUpdatesToThisTarget"));
				}
			}
			
			[Export ("setShouldIgnoreUpdatesToThisTarget:")]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_bool (this.Handle, Selector.GetHandle ("setShouldIgnoreUpdatesToThisTarget:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, Selector.GetHandle ("setShouldIgnoreUpdatesToThisTarget:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual bool ShouldSmoothlyScaleOutput {
			[Export ("shouldSmoothlyScaleOutput")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("shouldSmoothlyScaleOutput"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("shouldSmoothlyScaleOutput"));
				}
			}
			
			[Export ("setShouldSmoothlyScaleOutput:")]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_bool (this.Handle, Selector.GetHandle ("setShouldSmoothlyScaleOutput:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, Selector.GetHandle ("setShouldSmoothlyScaleOutput:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual NSObject[] Targets {
			[Export ("targets")]
			get {
				NSObject[] ret;
				if (IsDirectBinding) {
					ret = NSArray.ArrayFromHandle<NSObject>(global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.GetHandle ("targets")));
				} else {
					ret = NSArray.ArrayFromHandle<NSObject>(global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("targets")));
				}
				return ret;
			}
			
		}
		
		[CompilerGenerated]
		object __mt_TargetToIgnoreForUpdates_var;
		[CompilerGenerated]
		public virtual GPUImageInput TargetToIgnoreForUpdates {
			[Export ("targetToIgnoreForUpdates", ArgumentSemantic.UnsafeUnretained)]
			get {
				GPUImageInput ret;
				if (IsDirectBinding) {
					ret =  Runtime.GetNSObject<GPUImageInput> (global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.GetHandle ("targetToIgnoreForUpdates")));
				} else {
					ret =  Runtime.GetNSObject<GPUImageInput> (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("targetToIgnoreForUpdates")));
				}
				MarkDirty ();
				__mt_TargetToIgnoreForUpdates_var = ret;
				return ret;
			}
			
			[Export ("setTargetToIgnoreForUpdates:", ArgumentSemantic.UnsafeUnretained)]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("setTargetToIgnoreForUpdates:"), value.Handle);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("setTargetToIgnoreForUpdates:"), value.Handle);
				}
				MarkDirty ();
				__mt_TargetToIgnoreForUpdates_var = value;
			}
		}
		
		[CompilerGenerated]
		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
			if (Handle == IntPtr.Zero) {
				__mt_TargetToIgnoreForUpdates_var = null;
			}
		}
	} /* class GPUImageGrayscaleFilter */
}
