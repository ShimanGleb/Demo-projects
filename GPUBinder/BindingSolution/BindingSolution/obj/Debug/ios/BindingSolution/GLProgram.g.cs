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
	[Register("GLProgram", true)]
	public unsafe partial class GLProgram : NSObject {
		
		[CompilerGenerated]
		static readonly IntPtr class_ptr = Class.GetHandle ("GLProgram");
		
		public override IntPtr ClassHandle { get { return class_ptr; } }
		
		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("init")]
		public GLProgram () : base (NSObjectFlag.Empty)
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
		protected GLProgram (NSObjectFlag t) : base (t)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
		}

		[CompilerGenerated]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		protected internal GLProgram (IntPtr handle) : base (handle)
		{
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
		}

		[Export ("initWithVertexShaderString:fragmentShaderString:")]
		[CompilerGenerated]
		public GLProgram (string vShaderString, string fShaderString)
			: base (NSObjectFlag.Empty)
		{
			if (vShaderString == null)
				throw new ArgumentNullException ("vShaderString");
			if (fShaderString == null)
				throw new ArgumentNullException ("fShaderString");
			var nsvShaderString = NSString.CreateNative (vShaderString);
			var nsfShaderString = NSString.CreateNative (fShaderString);
			
			IsDirectBinding = GetType ().Assembly == global::ApiDefinition.Messaging.this_assembly;
			if (IsDirectBinding) {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSend_IntPtr_IntPtr (this.Handle, Selector.GetHandle ("initWithVertexShaderString:fragmentShaderString:"), nsvShaderString, nsfShaderString), "initWithVertexShaderString:fragmentShaderString:");
			} else {
				InitializeHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper_IntPtr_IntPtr (this.SuperHandle, Selector.GetHandle ("initWithVertexShaderString:fragmentShaderString:"), nsvShaderString, nsfShaderString), "initWithVertexShaderString:fragmentShaderString:");
			}
			NSString.ReleaseNative (nsvShaderString);
			NSString.ReleaseNative (nsfShaderString);
			
		}
		
		[Export ("addAttribute:")]
		[CompilerGenerated]
		public virtual void AddAttribute (string attributeName)
		{
			if (attributeName == null)
				throw new ArgumentNullException ("attributeName");
			var nsattributeName = NSString.CreateNative (attributeName);
			
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("addAttribute:"), nsattributeName);
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("addAttribute:"), nsattributeName);
			}
			NSString.ReleaseNative (nsattributeName);
			
		}
		
		[Export ("attributeIndex:")]
		[CompilerGenerated]
		public virtual global::System.UInt32 AttributeIndex (string attributeName)
		{
			if (attributeName == null)
				throw new ArgumentNullException ("attributeName");
			var nsattributeName = NSString.CreateNative (attributeName);
			
			global::System.UInt32 ret;
			if (IsDirectBinding) {
				ret = global::ApiDefinition.Messaging.UInt32_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("attributeIndex:"), nsattributeName);
			} else {
				ret = global::ApiDefinition.Messaging.UInt32_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("attributeIndex:"), nsattributeName);
			}
			NSString.ReleaseNative (nsattributeName);
			
			return ret;
		}
		
		[Export ("uniformIndex:")]
		[CompilerGenerated]
		public virtual global::System.UInt32 UniformIndex (string uniformName)
		{
			if (uniformName == null)
				throw new ArgumentNullException ("uniformName");
			var nsuniformName = NSString.CreateNative (uniformName);
			
			global::System.UInt32 ret;
			if (IsDirectBinding) {
				ret = global::ApiDefinition.Messaging.UInt32_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("uniformIndex:"), nsuniformName);
			} else {
				ret = global::ApiDefinition.Messaging.UInt32_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("uniformIndex:"), nsuniformName);
			}
			NSString.ReleaseNative (nsuniformName);
			
			return ret;
		}
		
		[Export ("use")]
		[CompilerGenerated]
		public virtual void Use ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("use"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("use"));
			}
		}
		
		[Export ("validate")]
		[CompilerGenerated]
		public virtual void Validate ()
		{
			if (IsDirectBinding) {
				global::ApiDefinition.Messaging.void_objc_msgSend (this.Handle, Selector.GetHandle ("validate"));
			} else {
				global::ApiDefinition.Messaging.void_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("validate"));
			}
		}
		
		[CompilerGenerated]
		public virtual string FragmentShaderLog {
			[Export ("fragmentShaderLog")]
			get {
				if (IsDirectBinding) {
					return NSString.FromHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.GetHandle ("fragmentShaderLog")));
				} else {
					return NSString.FromHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("fragmentShaderLog")));
				}
			}
			
			[Export ("setFragmentShaderLog:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				var nsvalue = NSString.CreateNative (value);
				
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("setFragmentShaderLog:"), nsvalue);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("setFragmentShaderLog:"), nsvalue);
				}
				NSString.ReleaseNative (nsvalue);
				
			}
		}
		
		[CompilerGenerated]
		public virtual bool Initialized {
			[Export ("initialized")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("initialized"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("initialized"));
				}
			}
			
			[Export ("setInitialized:")]
			set {
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_bool (this.Handle, Selector.GetHandle ("setInitialized:"), value);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_bool (this.SuperHandle, Selector.GetHandle ("setInitialized:"), value);
				}
			}
		}
		
		[CompilerGenerated]
		public virtual bool Link {
			[Export ("link")]
			get {
				if (IsDirectBinding) {
					return global::ApiDefinition.Messaging.bool_objc_msgSend (this.Handle, Selector.GetHandle ("link"));
				} else {
					return global::ApiDefinition.Messaging.bool_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("link"));
				}
			}
			
		}
		
		[CompilerGenerated]
		public virtual string ProgramLog {
			[Export ("programLog")]
			get {
				if (IsDirectBinding) {
					return NSString.FromHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.GetHandle ("programLog")));
				} else {
					return NSString.FromHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("programLog")));
				}
			}
			
			[Export ("setProgramLog:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				var nsvalue = NSString.CreateNative (value);
				
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("setProgramLog:"), nsvalue);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("setProgramLog:"), nsvalue);
				}
				NSString.ReleaseNative (nsvalue);
				
			}
		}
		
		[CompilerGenerated]
		public virtual string VertexShaderLog {
			[Export ("vertexShaderLog")]
			get {
				if (IsDirectBinding) {
					return NSString.FromHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSend (this.Handle, Selector.GetHandle ("vertexShaderLog")));
				} else {
					return NSString.FromHandle (global::ApiDefinition.Messaging.IntPtr_objc_msgSendSuper (this.SuperHandle, Selector.GetHandle ("vertexShaderLog")));
				}
			}
			
			[Export ("setVertexShaderLog:")]
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				var nsvalue = NSString.CreateNative (value);
				
				if (IsDirectBinding) {
					global::ApiDefinition.Messaging.void_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("setVertexShaderLog:"), nsvalue);
				} else {
					global::ApiDefinition.Messaging.void_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("setVertexShaderLog:"), nsvalue);
				}
				NSString.ReleaseNative (nsvalue);
				
			}
		}
		
	} /* class GLProgram */
}
