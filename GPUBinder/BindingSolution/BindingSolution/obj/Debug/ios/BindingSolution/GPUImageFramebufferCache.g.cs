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
	[Register("GPUImageFramebufferCache", true)]
	public unsafe partial class GPUImageFramebufferCache : NSObject {
		
		[CompilerGenerated]
		static readonly IntPtr class_ptr = Class.GetHandle ("GPUImageFramebufferCache");
		
		public override IntPtr ClassHandle { get { return class_ptr; } }
		
		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("init")]
		public GPUImageFramebufferCache () : base (NSObjectFlag.Empty)
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
		protected GPUImageFramebufferCache (NSObjectFlag t) : base (t)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
		}

		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected internal GPUImageFramebufferCache (IntPtr handle) : base (handle)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
		}

		[Export ("addFramebufferToActiveImageCaptureList:")]
		[CompilerGenerated]
		public virtual void AddFramebufferToActiveImageCaptureList (GPUImageFramebuffer framebuffer)
		{
			if (framebuffer == null)
				throw new ArgumentNullException ("framebuffer");
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("addFramebufferToActiveImageCaptureList:"), framebuffer.Handle);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("addFramebufferToActiveImageCaptureList:"), framebuffer.Handle);
			}
		}
		
		[Export ("fetchFramebufferForSize:textureOptions:onlyTexture:")]
		[CompilerGenerated]
		public virtual GPUImageFramebuffer FetchFramebufferForSize (CGSize framebufferSize, GPUTextureOptions textureOptions, bool onlyTexture)
		{
			if (IsDirectBinding) {
				return  Runtime.GetNSObject<GPUImageFramebuffer> (global::ApiDefinition.Messaging.IntPtr_objc_msgSend_CGSize_GPUTextureOptions_bool (this.Handle, Selector.GetHandle ("fetchFramebufferForSize:textureOptions:onlyTexture:"), framebufferSize, textureOptions, onlyTexture));
			} else {
				return  Runtime.GetNSObject<GPUImageFramebuffer> (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_CGSize_GPUTextureOptions_bool (this.SuperHandle, Selector.GetHandle ("fetchFramebufferForSize:textureOptions:onlyTexture:"), framebufferSize, textureOptions, onlyTexture));
			}
		}
		
		[Export ("fetchFramebufferForSize:onlyTexture:")]
		[CompilerGenerated]
		public virtual GPUImageFramebuffer FetchFramebufferForSize (CGSize framebufferSize, bool onlyTexture)
		{
			if (IsDirectBinding) {
				return  Runtime.GetNSObject<GPUImageFramebuffer> (global::ApiDefinition.Messaging.IntPtr_objc_msgSend_CGSize_bool (this.Handle, Selector.GetHandle ("fetchFramebufferForSize:onlyTexture:"), framebufferSize, onlyTexture));
			} else {
				return  Runtime.GetNSObject<GPUImageFramebuffer> (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_CGSize_bool (this.SuperHandle, Selector.GetHandle ("fetchFramebufferForSize:onlyTexture:"), framebufferSize, onlyTexture));
			}
		}
		
		[Export ("purgeAllUnassignedFramebuffers")]
		[CompilerGenerated]
		public virtual void PurgeAllUnassignedFramebuffers ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("purgeAllUnassignedFramebuffers"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("purgeAllUnassignedFramebuffers"));
			}
		}
		
		[Export ("removeFramebufferFromActiveImageCaptureList:")]
		[CompilerGenerated]
		public virtual void RemoveFramebufferFromActiveImageCaptureList (GPUImageFramebuffer framebuffer)
		{
			if (framebuffer == null)
				throw new ArgumentNullException ("framebuffer");
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("removeFramebufferFromActiveImageCaptureList:"), framebuffer.Handle);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("removeFramebufferFromActiveImageCaptureList:"), framebuffer.Handle);
			}
		}
		
		[Export ("returnFramebufferToCache:")]
		[CompilerGenerated]
		public virtual void ReturnFramebufferToCache (GPUImageFramebuffer framebuffer)
		{
			if (framebuffer == null)
				throw new ArgumentNullException ("framebuffer");
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("returnFramebufferToCache:"), framebuffer.Handle);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("returnFramebufferToCache:"), framebuffer.Handle);
			}
		}
		
	} /* class GPUImageFramebufferCache */
}
