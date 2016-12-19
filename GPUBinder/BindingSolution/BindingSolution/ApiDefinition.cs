using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreMedia;

namespace BindingSolution
{
	[BaseType(typeof(NSObject))]
	interface GPUImagePicture
	{
		// -(id)initWithImage:(UIImage *)newImageSource;
		[Export("initWithImage:")]
		IntPtr Constructor(UIImage newImageSource);
	}

	[BaseType(typeof(NSObject))]
	interface GLProgram
	{
		// @property (readwrite, nonatomic) BOOL initialized;
		[Export("initialized")]
		bool Initialized { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * vertexShaderLog;
		[Export("vertexShaderLog")]
		string VertexShaderLog { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * fragmentShaderLog;
		[Export("fragmentShaderLog")]
		string FragmentShaderLog { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * programLog;
		[Export("programLog")]
		string ProgramLog { get; set; }

		// -(id)initWithVertexShaderString:(NSString *)vShaderString fragmentShaderString:(NSString *)fShaderString;
		[Export("initWithVertexShaderString:fragmentShaderString:")]
		IntPtr Constructor(string vShaderString, string fShaderString);

		// -(void)addAttribute:(NSString *)attributeName;
		[Export("addAttribute:")]
		void AddAttribute(string attributeName);

		// -(GLuint)attributeIndex:(NSString *)attributeName;
		[Export("attributeIndex:")]
		uint AttributeIndex(string attributeName);

		// -(GLuint)uniformIndex:(NSString *)uniformName;
		[Export("uniformIndex:")]
		uint UniformIndex(string uniformName);

		// -(BOOL)link;
		[Export("link")]
		bool Link { get; }

		// -(void)use;
		[Export("use")]
		void Use();

		// -(void)validate;
		[Export("validate")]
		void Validate();
	}

	// @interface GPUImageFramebuffer : NSObject
	[BaseType(typeof(NSObject))]
	interface GPUImageFramebuffer
	{
		
	}

	// @interface GPUImageFramebufferCache : NSObject
	[BaseType(typeof(NSObject))]
	interface GPUImageFramebufferCache
	{
		// -(GPUImageFramebuffer *)fetchFramebufferForSize:(CGSize)framebufferSize textureOptions:(GPUTextureOptions)textureOptions onlyTexture:(BOOL)onlyTexture;
		[Export("fetchFramebufferForSize:textureOptions:onlyTexture:")]
		GPUImageFramebuffer FetchFramebufferForSize(CGSize framebufferSize, GPUTextureOptions textureOptions, bool onlyTexture);

		// -(GPUImageFramebuffer *)fetchFramebufferForSize:(CGSize)framebufferSize onlyTexture:(BOOL)onlyTexture;
		[Export("fetchFramebufferForSize:onlyTexture:")]
		GPUImageFramebuffer FetchFramebufferForSize(CGSize framebufferSize, bool onlyTexture);

		// -(void)returnFramebufferToCache:(GPUImageFramebuffer *)framebuffer;
		[Export("returnFramebufferToCache:")]
		void ReturnFramebufferToCache(GPUImageFramebuffer framebuffer);

		// -(void)purgeAllUnassignedFramebuffers;
		[Export("purgeAllUnassignedFramebuffers")]
		void PurgeAllUnassignedFramebuffers();

		// -(void)addFramebufferToActiveImageCaptureList:(GPUImageFramebuffer *)framebuffer;
		[Export("addFramebufferToActiveImageCaptureList:")]
		void AddFramebufferToActiveImageCaptureList(GPUImageFramebuffer framebuffer);

		// -(void)removeFramebufferFromActiveImageCaptureList:(GPUImageFramebuffer *)framebuffer;
		[Export("removeFramebufferFromActiveImageCaptureList:")]
		void RemoveFramebufferFromActiveImageCaptureList(GPUImageFramebuffer framebuffer);
	}

	// @interface GPUImageContext : NSObject
	[BaseType(typeof(NSObject))]
	interface GPUImageContext
	{

		// @required -(void)newFrameReadyAtTime:(CMTime)frameTime atIndex:(NSInteger)textureIndex;
		[Abstract]
		[Export("newFrameReadyAtTime:atIndex:")]
		void NewFrameReadyAtTime(CMTime frameTime, nint textureIndex);

		// @required -(void)setInputFramebuffer:(GPUImageFramebuffer *)newInputFramebuffer atIndex:(NSInteger)textureIndex;
		[Abstract]
		[Export("setInputFramebuffer:atIndex:")]
		void SetInputFramebuffer(GPUImageFramebuffer newInputFramebuffer, nint textureIndex);

		// @required -(NSInteger)nextAvailableTextureIndex;
		[Abstract]
		[Export("nextAvailableTextureIndex")]
		nint NextAvailableTextureIndex { get; }

		// @required -(void)setInputSize:(CGSize)newSize atIndex:(NSInteger)textureIndex;
		[Abstract]
		[Export("setInputSize:atIndex:")]
		void SetInputSize(CGSize newSize, nint textureIndex);

		// @required -(void)setInputRotation:(GPUImageRotationMode)newInputRotation atIndex:(NSInteger)textureIndex;
		[Abstract]
		[Export("setInputRotation:atIndex:")]
		void SetInputRotation(GPUImageRotationMode newInputRotation, nint textureIndex);

		// @required -(CGSize)maximumOutputSize;
		[Abstract]
		[Export("maximumOutputSize")]
		CGSize MaximumOutputSize { get; }

		// @required -(void)endProcessing;
		[Abstract]
		[Export("endProcessing")]
		void EndProcessing();

		// @required -(BOOL)shouldIgnoreUpdatesToThisTarget;
		[Abstract]
		[Export("shouldIgnoreUpdatesToThisTarget")]
		bool ShouldIgnoreUpdatesToThisTarget { get; }

		// @required -(BOOL)enabled;
		[Abstract]
		[Export("enabled")]
		bool Enabled { get; }

		// @required -(BOOL)wantsMonochromeInput;
		[Abstract]
		[Export("wantsMonochromeInput")]
		bool WantsMonochromeInput { get; }

		// @required -(void)setCurrentlyReceivingMonochromeInput:(BOOL)newValue;
		[Abstract]
		[Export("setCurrentlyReceivingMonochromeInput:")]
		void SetCurrentlyReceivingMonochromeInput(bool newValue);
	}

	// @protocol GPUImageInput <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface GPUImageInput
	{
		
	}

	// @interface GPUImageOutput : NSObject
	[BaseType(typeof(NSObject))]
	interface GPUImageOutput
	{
		// @property (readwrite, nonatomic) BOOL shouldSmoothlyScaleOutput;
		[Export("shouldSmoothlyScaleOutput")]
		bool ShouldSmoothlyScaleOutput { get; set; }

		// @property (readwrite, nonatomic) BOOL shouldIgnoreUpdatesToThisTarget;
		[Export("shouldIgnoreUpdatesToThisTarget")]
		bool ShouldIgnoreUpdatesToThisTarget { get; set; }

		// @property (readwrite, nonatomic, unsafe_unretained) id<GPUImageInput> targetToIgnoreForUpdates;
		[Export("targetToIgnoreForUpdates", ArgumentSemantic.Assign)]
		GPUImageInput TargetToIgnoreForUpdates { get; set; }

		// @property (copy, nonatomic) void (^frameProcessingCompletionBlock)(GPUImageOutput *, CMTime);
		[Export("frameProcessingCompletionBlock", ArgumentSemantic.Copy)]
		Action<GPUImageOutput, CMTime> FrameProcessingCompletionBlock { get; set; }

		// @property (nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { get; set; }

		// -(void)setInputFramebufferForTarget:(id<GPUImageInput>)target atIndex:(NSInteger)inputTextureIndex;
		[Export("setInputFramebufferForTarget:atIndex:")]
		void SetInputFramebufferForTarget(GPUImageInput target, nint inputTextureIndex);

		// -(GPUImageFramebuffer *)framebufferForOutput;
		[Export("framebufferForOutput")]
		GPUImageFramebuffer FramebufferForOutput { get; }

		// -(void)removeOutputFramebuffer;
		[Export("removeOutputFramebuffer")]
		void RemoveOutputFramebuffer();

		// -(void)notifyTargetsAboutNewOutputTexture;
		[Export("notifyTargetsAboutNewOutputTexture")]
		void NotifyTargetsAboutNewOutputTexture();

		// -(NSArray *)targets;
		[Export("targets")]
		NSObject[] Targets { get; }

		// -(void)addTarget:(id<GPUImageInput>)newTarget;
		[Export("addTarget:")]
		void AddTarget(GPUImageInput newTarget);

		// -(void)addTarget:(id<GPUImageInput>)newTarget atTextureLocation:(NSInteger)textureLocation;
		[Export("addTarget:atTextureLocation:")]
		void AddTarget(GPUImageInput newTarget, nint textureLocation);

		// -(void)removeTarget:(id<GPUImageInput>)targetToRemove;
		[Export("removeTarget:")]
		void RemoveTarget(GPUImageInput targetToRemove);

		// -(void)removeAllTargets;
		[Export("removeAllTargets")]
		void RemoveAllTargets();

		// -(void)forceProcessingAtSize:(CGSize)frameSize;
		[Export("forceProcessingAtSize:")]
		void ForceProcessingAtSize(CGSize frameSize);

		// -(void)forceProcessingAtSizeRespectingAspectRatio:(CGSize)frameSize;
		[Export("forceProcessingAtSizeRespectingAspectRatio:")]
		void ForceProcessingAtSizeRespectingAspectRatio(CGSize frameSize);

		// -(void)useNextFrameForImageCapture;
		[Export("useNextFrameForImageCapture")]
		void UseNextFrameForImageCapture();

		// -(CGImageRef)newCGImageFromCurrentlyProcessedOutput;
		[Export("newCGImageFromCurrentlyProcessedOutput")]
		unsafe CGImage NewCGImageFromCurrentlyProcessedOutput { get; }

		// -(CGImageRef)newCGImageByFilteringCGImage:(CGImageRef)imageToFilter;
		[Export("newCGImageByFilteringCGImage:")]
		unsafe CGImage NewCGImageByFilteringCGImage(CGImage imageToFilter);

		// -(UIImage *)imageFromCurrentFramebuffer;
		[Export("imageFromCurrentFramebuffer")]
		UIImage ImageFromCurrentFramebuffer { get; }

		// -(UIImage *)imageFromCurrentFramebufferWithOrientation:(UIImageOrientation)imageOrientation;
		[Export("imageFromCurrentFramebufferWithOrientation:")]
		UIImage ImageFromCurrentFramebufferWithOrientation(UIImageOrientation imageOrientation);

		// -(UIImage *)imageByFilteringImage:(UIImage *)imageToFilter;
		[Export("imageByFilteringImage:")]
		UIImage ImageByFilteringImage(UIImage imageToFilter);

		// -(CGImageRef)newCGImageByFilteringImage:(UIImage *)imageToFilter;
		[Export("newCGImageByFilteringImage:")]
		unsafe CGImage NewCGImageByFilteringImage(UIImage imageToFilter);

		// -(BOOL)providesMonochromeOutput;
		[Export("providesMonochromeOutput")]
		bool ProvidesMonochromeOutput { get; }
	}


	partial interface Constants
	{
		// extern NSString *const kGPUImageVertexShaderString;
		[Field("kGPUImageVertexShaderString", "__Internal")]
		NSString kGPUImageVertexShaderString { get; }

		// extern NSString *const kGPUImagePassthroughFragmentShaderString;
		[Field("kGPUImagePassthroughFragmentShaderString", "__Internal")]
		NSString kGPUImagePassthroughFragmentShaderString { get; }
	}

	// @interface GPUImageFilter : GPUImageOutput <GPUImageInput>
	[BaseType(typeof(GPUImageOutput))]
	interface GPUImageFilter : GPUImageOutput
	{
		[Export("currentlyReceivingMonochromeInput")]
		bool CurrentlyReceivingMonochromeInput { get; set; }

		// -(id)initWithVertexShaderFromString:(NSString *)vertexShaderString fragmentShaderFromString:(NSString *)fragmentShaderString;
		[Export("initWithVertexShaderFromString:fragmentShaderFromString:")]
		IntPtr Constructor(string vertexShaderString, string fragmentShaderString);

		// -(id)initWithFragmentShaderFromString:(NSString *)fragmentShaderString;
		[Export("initWithFragmentShaderFromString:")]
		IntPtr Constructor(string fragmentShaderString);

		// -(void)initializeAttributes;
		[Export("initializeAttributes")]
		void InitializeAttributes();

		// -(void)setupFilterForSize:(CGSize)filterFrameSize;
		[Export("setupFilterForSize:")]
		void SetupFilterForSize(CGSize filterFrameSize);

		// -(CGSize)rotatedSize:(CGSize)sizeToRotate forIndex:(NSInteger)textureIndex;
		[Export("rotatedSize:forIndex:")]
		CGSize RotatedSize(CGSize sizeToRotate, nint textureIndex);

	}

	[Static]
	partial interface Constants
	{
		// extern NSString *const kGPUImageLuminanceFragmentShaderString;
		[Field("kGPUImageLuminanceFragmentShaderString", "__Internal")]
		NSString kGPUImageLuminanceFragmentShaderString { get; }
	}

	// @interface GPUImageGrayscaleFilter : GPUImageFilter
	[BaseType(typeof(GPUImageFilter))]
	interface GPUImageGrayscaleFilter : GPUImageFilter
	{
		// (void)renderToTextureWithVertices:(const GLfloat *)vertices textureCoordinates:(const GLfloat *) textureCoordinates;
		[Export("renderToTextureWithVertices:")]
		void RenderToTextureWithVertices(float vertices);
	}
}

