using System;
using CoreFoundation;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using OpenGLES;
using UIKit;

namespace GrayScaleFilter
{
	// @interface GLProgram : NSObject
	[BaseType (typeof(NSObject))]
	interface GLProgram
	{
		// @property (readwrite, nonatomic) BOOL initialized;
		[Export ("initialized")]
		bool Initialized { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * vertexShaderLog;
		[Export ("vertexShaderLog")]
		string VertexShaderLog { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * fragmentShaderLog;
		[Export ("fragmentShaderLog")]
		string FragmentShaderLog { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * programLog;
		[Export ("programLog")]
		string ProgramLog { get; set; }

		// -(id)initWithVertexShaderString:(NSString *)vShaderString fragmentShaderString:(NSString *)fShaderString;
		[Export ("initWithVertexShaderString:fragmentShaderString:")]
		IntPtr Constructor (string vShaderString, string fShaderString);

		// -(id)initWithVertexShaderString:(NSString *)vShaderString fragmentShaderFilename:(NSString *)fShaderFilename;
		[Export ("initWithVertexShaderString:fragmentShaderFilename:")]
		IntPtr Constructor (string vShaderString, string fShaderFilename);

		// -(id)initWithVertexShaderFilename:(NSString *)vShaderFilename fragmentShaderFilename:(NSString *)fShaderFilename;
		[Export ("initWithVertexShaderFilename:fragmentShaderFilename:")]
		IntPtr Constructor (string vShaderFilename, string fShaderFilename);

		// -(void)addAttribute:(NSString *)attributeName;
		[Export ("addAttribute:")]
		void AddAttribute (string attributeName);

		// -(GLuint)attributeIndex:(NSString *)attributeName;
		[Export ("attributeIndex:")]
		uint AttributeIndex (string attributeName);

		// -(GLuint)uniformIndex:(NSString *)uniformName;
		[Export ("uniformIndex:")]
		uint UniformIndex (string uniformName);

		// -(BOOL)link;
		[Export ("link")]
		[Verify (MethodToProperty)]
		bool Link { get; }

		// -(void)use;
		[Export ("use")]
		void Use ();

		// -(void)validate;
		[Export ("validate")]
		void Validate ();
	}

	// @interface GPUImageFramebuffer : NSObject
	[BaseType (typeof(NSObject))]
	interface GPUImageFramebuffer
	{
		// @property (readonly) CGSize size;
		[Export ("size")]
		CGSize Size { get; }

		// @property (readonly) GPUTextureOptions textureOptions;
		[Export ("textureOptions")]
		GPUTextureOptions TextureOptions { get; }

		// @property (readonly) GLuint texture;
		[Export ("texture")]
		uint Texture { get; }

		// @property (readonly) BOOL missingFramebuffer;
		[Export ("missingFramebuffer")]
		bool MissingFramebuffer { get; }

		// -(id)initWithSize:(CGSize)framebufferSize;
		[Export ("initWithSize:")]
		IntPtr Constructor (CGSize framebufferSize);

		// -(id)initWithSize:(CGSize)framebufferSize textureOptions:(GPUTextureOptions)fboTextureOptions onlyTexture:(BOOL)onlyGenerateTexture;
		[Export ("initWithSize:textureOptions:onlyTexture:")]
		IntPtr Constructor (CGSize framebufferSize, GPUTextureOptions fboTextureOptions, bool onlyGenerateTexture);

		// -(id)initWithSize:(CGSize)framebufferSize overriddenTexture:(GLuint)inputTexture;
		[Export ("initWithSize:overriddenTexture:")]
		IntPtr Constructor (CGSize framebufferSize, uint inputTexture);

		// -(void)activateFramebuffer;
		[Export ("activateFramebuffer")]
		void ActivateFramebuffer ();

		// -(void)lock;
		[Export ("lock")]
		void Lock ();

		// -(void)unlock;
		[Export ("unlock")]
		void Unlock ();

		// -(void)clearAllLocks;
		[Export ("clearAllLocks")]
		void ClearAllLocks ();

		// -(void)disableReferenceCounting;
		[Export ("disableReferenceCounting")]
		void DisableReferenceCounting ();

		// -(void)enableReferenceCounting;
		[Export ("enableReferenceCounting")]
		void EnableReferenceCounting ();

		// -(CGImageRef)newCGImageFromFramebufferContents;
		[Export ("newCGImageFromFramebufferContents")]
		[Verify (MethodToProperty)]
		unsafe CGImageRef* NewCGImageFromFramebufferContents { get; }

		// -(void)restoreRenderTarget;
		[Export ("restoreRenderTarget")]
		void RestoreRenderTarget ();

		// -(void)lockForReading;
		[Export ("lockForReading")]
		void LockForReading ();

		// -(void)unlockAfterReading;
		[Export ("unlockAfterReading")]
		void UnlockAfterReading ();

		// -(NSUInteger)bytesPerRow;
		[Export ("bytesPerRow")]
		[Verify (MethodToProperty)]
		nuint BytesPerRow { get; }

		// -(GLubyte *)byteBuffer;
		[Export ("byteBuffer")]
		[Verify (MethodToProperty)]
		unsafe byte* ByteBuffer { get; }

		// -(CVPixelBufferRef)pixelBuffer;
		[Export ("pixelBuffer")]
		[Verify (MethodToProperty)]
		unsafe CVPixelBufferRef* PixelBuffer { get; }
	}

	// @interface GPUImageFramebufferCache : NSObject
	[BaseType (typeof(NSObject))]
	interface GPUImageFramebufferCache
	{
		// -(GPUImageFramebuffer *)fetchFramebufferForSize:(CGSize)framebufferSize textureOptions:(GPUTextureOptions)textureOptions onlyTexture:(BOOL)onlyTexture;
		[Export ("fetchFramebufferForSize:textureOptions:onlyTexture:")]
		GPUImageFramebuffer FetchFramebufferForSize (CGSize framebufferSize, GPUTextureOptions textureOptions, bool onlyTexture);

		// -(GPUImageFramebuffer *)fetchFramebufferForSize:(CGSize)framebufferSize onlyTexture:(BOOL)onlyTexture;
		[Export ("fetchFramebufferForSize:onlyTexture:")]
		GPUImageFramebuffer FetchFramebufferForSize (CGSize framebufferSize, bool onlyTexture);

		// -(void)returnFramebufferToCache:(GPUImageFramebuffer *)framebuffer;
		[Export ("returnFramebufferToCache:")]
		void ReturnFramebufferToCache (GPUImageFramebuffer framebuffer);

		// -(void)purgeAllUnassignedFramebuffers;
		[Export ("purgeAllUnassignedFramebuffers")]
		void PurgeAllUnassignedFramebuffers ();

		// -(void)addFramebufferToActiveImageCaptureList:(GPUImageFramebuffer *)framebuffer;
		[Export ("addFramebufferToActiveImageCaptureList:")]
		void AddFramebufferToActiveImageCaptureList (GPUImageFramebuffer framebuffer);

		// -(void)removeFramebufferFromActiveImageCaptureList:(GPUImageFramebuffer *)framebuffer;
		[Export ("removeFramebufferFromActiveImageCaptureList:")]
		void RemoveFramebufferFromActiveImageCaptureList (GPUImageFramebuffer framebuffer);
	}

	// @interface GPUImageContext : NSObject
	[BaseType (typeof(NSObject))]
	interface GPUImageContext
	{
		// @property (readonly, nonatomic) dispatch_queue_t contextQueue;
		[Export ("contextQueue")]
		DispatchQueue ContextQueue { get; }

		// @property (readwrite, retain, nonatomic) GLProgram * currentShaderProgram;
		[Export ("currentShaderProgram", ArgumentSemantic.Retain)]
		GLProgram CurrentShaderProgram { get; set; }

		// @property (readonly, retain, nonatomic) EAGLContext * context;
		[Export ("context", ArgumentSemantic.Retain)]
		EAGLContext Context { get; }

		// @property (readonly) CVOpenGLESTextureCacheRef coreVideoTextureCache;
		[Export ("coreVideoTextureCache")]
		unsafe CVOpenGLESTextureCacheRef* CoreVideoTextureCache { get; }

		// @property (readonly) GPUImageFramebufferCache * framebufferCache;
		[Export ("framebufferCache")]
		GPUImageFramebufferCache FramebufferCache { get; }

		// +(void *)contextKey;
		[Static]
		[Export ("contextKey")]
		[Verify (MethodToProperty)]
		unsafe void* ContextKey { get; }

		// +(GPUImageContext *)sharedImageProcessingContext;
		[Static]
		[Export ("sharedImageProcessingContext")]
		[Verify (MethodToProperty)]
		GPUImageContext SharedImageProcessingContext { get; }

		// +(dispatch_queue_t)sharedContextQueue;
		[Static]
		[Export ("sharedContextQueue")]
		[Verify (MethodToProperty)]
		DispatchQueue SharedContextQueue { get; }

		// +(GPUImageFramebufferCache *)sharedFramebufferCache;
		[Static]
		[Export ("sharedFramebufferCache")]
		[Verify (MethodToProperty)]
		GPUImageFramebufferCache SharedFramebufferCache { get; }

		// +(void)useImageProcessingContext;
		[Static]
		[Export ("useImageProcessingContext")]
		void UseImageProcessingContext ();

		// -(void)useAsCurrentContext;
		[Export ("useAsCurrentContext")]
		void UseAsCurrentContext ();

		// +(void)setActiveShaderProgram:(GLProgram *)shaderProgram;
		[Static]
		[Export ("setActiveShaderProgram:")]
		void SetActiveShaderProgram (GLProgram shaderProgram);

		// -(void)setContextShaderProgram:(GLProgram *)shaderProgram;
		[Export ("setContextShaderProgram:")]
		void SetContextShaderProgram (GLProgram shaderProgram);

		// +(GLint)maximumTextureSizeForThisDevice;
		[Static]
		[Export ("maximumTextureSizeForThisDevice")]
		[Verify (MethodToProperty)]
		int MaximumTextureSizeForThisDevice { get; }

		// +(GLint)maximumTextureUnitsForThisDevice;
		[Static]
		[Export ("maximumTextureUnitsForThisDevice")]
		[Verify (MethodToProperty)]
		int MaximumTextureUnitsForThisDevice { get; }

		// +(GLint)maximumVaryingVectorsForThisDevice;
		[Static]
		[Export ("maximumVaryingVectorsForThisDevice")]
		[Verify (MethodToProperty)]
		int MaximumVaryingVectorsForThisDevice { get; }

		// +(BOOL)deviceSupportsOpenGLESExtension:(NSString *)extension;
		[Static]
		[Export ("deviceSupportsOpenGLESExtension:")]
		bool DeviceSupportsOpenGLESExtension (string extension);

		// +(BOOL)deviceSupportsRedTextures;
		[Static]
		[Export ("deviceSupportsRedTextures")]
		[Verify (MethodToProperty)]
		bool DeviceSupportsRedTextures { get; }

		// +(BOOL)deviceSupportsFramebufferReads;
		[Static]
		[Export ("deviceSupportsFramebufferReads")]
		[Verify (MethodToProperty)]
		bool DeviceSupportsFramebufferReads { get; }

		// +(CGSize)sizeThatFitsWithinATextureForSize:(CGSize)inputSize;
		[Static]
		[Export ("sizeThatFitsWithinATextureForSize:")]
		CGSize SizeThatFitsWithinATextureForSize (CGSize inputSize);

		// -(void)presentBufferForDisplay;
		[Export ("presentBufferForDisplay")]
		void PresentBufferForDisplay ();

		// -(GLProgram *)programForVertexShaderString:(NSString *)vertexShaderString fragmentShaderString:(NSString *)fragmentShaderString;
		[Export ("programForVertexShaderString:fragmentShaderString:")]
		GLProgram ProgramForVertexShaderString (string vertexShaderString, string fragmentShaderString);

		// -(void)useSharegroup:(EAGLSharegroup *)sharegroup;
		[Export ("useSharegroup:")]
		void UseSharegroup (EAGLSharegroup sharegroup);

		// +(BOOL)supportsFastTextureUpload;
		[Static]
		[Export ("supportsFastTextureUpload")]
		[Verify (MethodToProperty)]
		bool SupportsFastTextureUpload { get; }
	}

	// @protocol GPUImageInput <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GPUImageInput
	{
		// @required -(void)newFrameReadyAtTime:(CMTime)frameTime atIndex:(NSInteger)textureIndex;
		[Abstract]
		[Export ("newFrameReadyAtTime:atIndex:")]
		void NewFrameReadyAtTime (CMTime frameTime, nint textureIndex);

		// @required -(void)setInputFramebuffer:(GPUImageFramebuffer *)newInputFramebuffer atIndex:(NSInteger)textureIndex;
		[Abstract]
		[Export ("setInputFramebuffer:atIndex:")]
		void SetInputFramebuffer (GPUImageFramebuffer newInputFramebuffer, nint textureIndex);

		// @required -(NSInteger)nextAvailableTextureIndex;
		[Abstract]
		[Export ("nextAvailableTextureIndex")]
		[Verify (MethodToProperty)]
		nint NextAvailableTextureIndex { get; }

		// @required -(void)setInputSize:(CGSize)newSize atIndex:(NSInteger)textureIndex;
		[Abstract]
		[Export ("setInputSize:atIndex:")]
		void SetInputSize (CGSize newSize, nint textureIndex);

		// @required -(void)setInputRotation:(GPUImageRotationMode)newInputRotation atIndex:(NSInteger)textureIndex;
		[Abstract]
		[Export ("setInputRotation:atIndex:")]
		void SetInputRotation (GPUImageRotationMode newInputRotation, nint textureIndex);

		// @required -(CGSize)maximumOutputSize;
		[Abstract]
		[Export ("maximumOutputSize")]
		[Verify (MethodToProperty)]
		CGSize MaximumOutputSize { get; }

		// @required -(void)endProcessing;
		[Abstract]
		[Export ("endProcessing")]
		void EndProcessing ();

		// @required -(BOOL)shouldIgnoreUpdatesToThisTarget;
		[Abstract]
		[Export ("shouldIgnoreUpdatesToThisTarget")]
		[Verify (MethodToProperty)]
		bool ShouldIgnoreUpdatesToThisTarget { get; }

		// @required -(BOOL)enabled;
		[Abstract]
		[Export ("enabled")]
		[Verify (MethodToProperty)]
		bool Enabled { get; }

		// @required -(BOOL)wantsMonochromeInput;
		[Abstract]
		[Export ("wantsMonochromeInput")]
		[Verify (MethodToProperty)]
		bool WantsMonochromeInput { get; }

		// @required -(void)setCurrentlyReceivingMonochromeInput:(BOOL)newValue;
		[Abstract]
		[Export ("setCurrentlyReceivingMonochromeInput:")]
		void SetCurrentlyReceivingMonochromeInput (bool newValue);
	}

	// @interface GPUImageOutput : NSObject
	[BaseType (typeof(NSObject))]
	interface GPUImageOutput
	{
		// @property (readwrite, nonatomic) BOOL shouldSmoothlyScaleOutput;
		[Export ("shouldSmoothlyScaleOutput")]
		bool ShouldSmoothlyScaleOutput { get; set; }

		// @property (readwrite, nonatomic) BOOL shouldIgnoreUpdatesToThisTarget;
		[Export ("shouldIgnoreUpdatesToThisTarget")]
		bool ShouldIgnoreUpdatesToThisTarget { get; set; }

		// @property (readwrite, retain, nonatomic) GPUImageMovieWriter * audioEncodingTarget;
		[Export ("audioEncodingTarget", ArgumentSemantic.Retain)]
		GPUImageMovieWriter AudioEncodingTarget { get; set; }

		// @property (readwrite, nonatomic, unsafe_unretained) id<GPUImageInput> targetToIgnoreForUpdates;
		[Export ("targetToIgnoreForUpdates", ArgumentSemantic.Assign)]
		GPUImageInput TargetToIgnoreForUpdates { get; set; }

		// @property (copy, nonatomic) void (^frameProcessingCompletionBlock)(GPUImageOutput *, CMTime);
		[Export ("frameProcessingCompletionBlock", ArgumentSemantic.Copy)]
		Action<GPUImageOutput, CMTime> FrameProcessingCompletionBlock { get; set; }

		// @property (nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { get; set; }

		// @property (readwrite, nonatomic) GPUTextureOptions outputTextureOptions;
		[Export ("outputTextureOptions", ArgumentSemantic.Assign)]
		GPUTextureOptions OutputTextureOptions { get; set; }

		// -(void)setInputFramebufferForTarget:(id<GPUImageInput>)target atIndex:(NSInteger)inputTextureIndex;
		[Export ("setInputFramebufferForTarget:atIndex:")]
		void SetInputFramebufferForTarget (GPUImageInput target, nint inputTextureIndex);

		// -(GPUImageFramebuffer *)framebufferForOutput;
		[Export ("framebufferForOutput")]
		[Verify (MethodToProperty)]
		GPUImageFramebuffer FramebufferForOutput { get; }

		// -(void)removeOutputFramebuffer;
		[Export ("removeOutputFramebuffer")]
		void RemoveOutputFramebuffer ();

		// -(void)notifyTargetsAboutNewOutputTexture;
		[Export ("notifyTargetsAboutNewOutputTexture")]
		void NotifyTargetsAboutNewOutputTexture ();

		// -(NSArray *)targets;
		[Export ("targets")]
		[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] Targets { get; }

		// -(void)addTarget:(id<GPUImageInput>)newTarget;
		[Export ("addTarget:")]
		void AddTarget (GPUImageInput newTarget);

		// -(void)addTarget:(id<GPUImageInput>)newTarget atTextureLocation:(NSInteger)textureLocation;
		[Export ("addTarget:atTextureLocation:")]
		void AddTarget (GPUImageInput newTarget, nint textureLocation);

		// -(void)removeTarget:(id<GPUImageInput>)targetToRemove;
		[Export ("removeTarget:")]
		void RemoveTarget (GPUImageInput targetToRemove);

		// -(void)removeAllTargets;
		[Export ("removeAllTargets")]
		void RemoveAllTargets ();

		// -(void)forceProcessingAtSize:(CGSize)frameSize;
		[Export ("forceProcessingAtSize:")]
		void ForceProcessingAtSize (CGSize frameSize);

		// -(void)forceProcessingAtSizeRespectingAspectRatio:(CGSize)frameSize;
		[Export ("forceProcessingAtSizeRespectingAspectRatio:")]
		void ForceProcessingAtSizeRespectingAspectRatio (CGSize frameSize);

		// -(void)useNextFrameForImageCapture;
		[Export ("useNextFrameForImageCapture")]
		void UseNextFrameForImageCapture ();

		// -(CGImageRef)newCGImageFromCurrentlyProcessedOutput;
		[Export ("newCGImageFromCurrentlyProcessedOutput")]
		[Verify (MethodToProperty)]
		unsafe CGImageRef* NewCGImageFromCurrentlyProcessedOutput { get; }

		// -(CGImageRef)newCGImageByFilteringCGImage:(CGImageRef)imageToFilter;
		[Export ("newCGImageByFilteringCGImage:")]
		unsafe CGImageRef* NewCGImageByFilteringCGImage (CGImageRef* imageToFilter);

		// -(UIImage *)imageFromCurrentFramebuffer;
		[Export ("imageFromCurrentFramebuffer")]
		[Verify (MethodToProperty)]
		UIImage ImageFromCurrentFramebuffer { get; }

		// -(UIImage *)imageFromCurrentFramebufferWithOrientation:(UIImageOrientation)imageOrientation;
		[Export ("imageFromCurrentFramebufferWithOrientation:")]
		UIImage ImageFromCurrentFramebufferWithOrientation (UIImageOrientation imageOrientation);

		// -(UIImage *)imageByFilteringImage:(UIImage *)imageToFilter;
		[Export ("imageByFilteringImage:")]
		UIImage ImageByFilteringImage (UIImage imageToFilter);

		// -(CGImageRef)newCGImageByFilteringImage:(UIImage *)imageToFilter;
		[Export ("newCGImageByFilteringImage:")]
		unsafe CGImageRef* NewCGImageByFilteringImage (UIImage imageToFilter);

		// -(BOOL)providesMonochromeOutput;
		[Export ("providesMonochromeOutput")]
		[Verify (MethodToProperty)]
		bool ProvidesMonochromeOutput { get; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kGPUImageVertexShaderString;
		[Field ("kGPUImageVertexShaderString", "__Internal")]
		NSString kGPUImageVertexShaderString { get; }

		// extern NSString *const kGPUImagePassthroughFragmentShaderString;
		[Field ("kGPUImagePassthroughFragmentShaderString", "__Internal")]
		NSString kGPUImagePassthroughFragmentShaderString { get; }
	}

	// @interface GPUImageFilter : GPUImageOutput <GPUImageInput>
	[BaseType (typeof(GPUImageOutput))]
	interface GPUImageFilter : IGPUImageInput
	{
		// @property (readonly) CVPixelBufferRef renderTarget;
		[Export ("renderTarget")]
		unsafe CVPixelBufferRef* RenderTarget { get; }

		// @property (readwrite, nonatomic) BOOL preventRendering;
		[Export ("preventRendering")]
		bool PreventRendering { get; set; }

		// @property (readwrite, nonatomic) BOOL currentlyReceivingMonochromeInput;
		[Export ("currentlyReceivingMonochromeInput")]
		bool CurrentlyReceivingMonochromeInput { get; set; }

		// -(id)initWithVertexShaderFromString:(NSString *)vertexShaderString fragmentShaderFromString:(NSString *)fragmentShaderString;
		[Export ("initWithVertexShaderFromString:fragmentShaderFromString:")]
		IntPtr Constructor (string vertexShaderString, string fragmentShaderString);

		// -(id)initWithFragmentShaderFromString:(NSString *)fragmentShaderString;
		[Export ("initWithFragmentShaderFromString:")]
		IntPtr Constructor (string fragmentShaderString);

		// -(id)initWithFragmentShaderFromFile:(NSString *)fragmentShaderFilename;
		[Export ("initWithFragmentShaderFromFile:")]
		IntPtr Constructor (string fragmentShaderFilename);

		// -(void)initializeAttributes;
		[Export ("initializeAttributes")]
		void InitializeAttributes ();

		// -(void)setupFilterForSize:(CGSize)filterFrameSize;
		[Export ("setupFilterForSize:")]
		void SetupFilterForSize (CGSize filterFrameSize);

		// -(CGSize)rotatedSize:(CGSize)sizeToRotate forIndex:(NSInteger)textureIndex;
		[Export ("rotatedSize:forIndex:")]
		CGSize RotatedSize (CGSize sizeToRotate, nint textureIndex);

		// -(CGPoint)rotatedPoint:(CGPoint)pointToRotate forRotation:(GPUImageRotationMode)rotation;
		[Export ("rotatedPoint:forRotation:")]
		CGPoint RotatedPoint (CGPoint pointToRotate, GPUImageRotationMode rotation);

		// -(CGSize)sizeOfFBO;
		[Export ("sizeOfFBO")]
		[Verify (MethodToProperty)]
		CGSize SizeOfFBO { get; }

		// +(const GLfloat *)textureCoordinatesForRotation:(GPUImageRotationMode)rotationMode;
		[Static]
		[Export ("textureCoordinatesForRotation:")]
		unsafe float* TextureCoordinatesForRotation (GPUImageRotationMode rotationMode);

		// -(void)renderToTextureWithVertices:(const GLfloat *)vertices textureCoordinates:(const GLfloat *)textureCoordinates;
		[Export ("renderToTextureWithVertices:textureCoordinates:")]
		unsafe void RenderToTextureWithVertices (float* vertices, float* textureCoordinates);

		// -(void)informTargetsAboutNewFrameAtTime:(CMTime)frameTime;
		[Export ("informTargetsAboutNewFrameAtTime:")]
		void InformTargetsAboutNewFrameAtTime (CMTime frameTime);

		// -(CGSize)outputFrameSize;
		[Export ("outputFrameSize")]
		[Verify (MethodToProperty)]
		CGSize OutputFrameSize { get; }

		// -(void)setBackgroundColorRed:(GLfloat)redComponent green:(GLfloat)greenComponent blue:(GLfloat)blueComponent alpha:(GLfloat)alphaComponent;
		[Export ("setBackgroundColorRed:green:blue:alpha:")]
		void SetBackgroundColorRed (float redComponent, float greenComponent, float blueComponent, float alphaComponent);

		// -(void)setInteger:(GLint)newInteger forUniformName:(NSString *)uniformName;
		[Export ("setInteger:forUniformName:")]
		void SetInteger (int newInteger, string uniformName);

		// -(void)setFloat:(GLfloat)newFloat forUniformName:(NSString *)uniformName;
		[Export ("setFloat:forUniformName:")]
		void SetFloat (float newFloat, string uniformName);

		// -(void)setSize:(CGSize)newSize forUniformName:(NSString *)uniformName;
		[Export ("setSize:forUniformName:")]
		void SetSize (CGSize newSize, string uniformName);

		// -(void)setPoint:(CGPoint)newPoint forUniformName:(NSString *)uniformName;
		[Export ("setPoint:forUniformName:")]
		void SetPoint (CGPoint newPoint, string uniformName);

		// -(void)setFloatVec3:(GPUVector3)newVec3 forUniformName:(NSString *)uniformName;
		[Export ("setFloatVec3:forUniformName:")]
		void SetFloatVec3 (GPUVector3 newVec3, string uniformName);

		// -(void)setFloatVec4:(GPUVector4)newVec4 forUniform:(NSString *)uniformName;
		[Export ("setFloatVec4:forUniform:")]
		void SetFloatVec4 (GPUVector4 newVec4, string uniformName);

		// -(void)setFloatArray:(GLfloat *)array length:(GLsizei)count forUniform:(NSString *)uniformName;
		[Export ("setFloatArray:length:forUniform:")]
		unsafe void SetFloatArray (float* array, int count, string uniformName);

		// -(void)setMatrix3f:(GPUMatrix3x3)matrix forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
		[Export ("setMatrix3f:forUniform:program:")]
		void SetMatrix3f (GPUMatrix3x3 matrix, int uniform, GLProgram shaderProgram);

		// -(void)setMatrix4f:(GPUMatrix4x4)matrix forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
		[Export ("setMatrix4f:forUniform:program:")]
		void SetMatrix4f (GPUMatrix4x4 matrix, int uniform, GLProgram shaderProgram);

		// -(void)setFloat:(GLfloat)floatValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
		[Export ("setFloat:forUniform:program:")]
		void SetFloat (float floatValue, int uniform, GLProgram shaderProgram);

		// -(void)setPoint:(CGPoint)pointValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
		[Export ("setPoint:forUniform:program:")]
		void SetPoint (CGPoint pointValue, int uniform, GLProgram shaderProgram);

		// -(void)setSize:(CGSize)sizeValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
		[Export ("setSize:forUniform:program:")]
		void SetSize (CGSize sizeValue, int uniform, GLProgram shaderProgram);

		// -(void)setVec3:(GPUVector3)vectorValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
		[Export ("setVec3:forUniform:program:")]
		void SetVec3 (GPUVector3 vectorValue, int uniform, GLProgram shaderProgram);

		// -(void)setVec4:(GPUVector4)vectorValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
		[Export ("setVec4:forUniform:program:")]
		void SetVec4 (GPUVector4 vectorValue, int uniform, GLProgram shaderProgram);

		// -(void)setFloatArray:(GLfloat *)arrayValue length:(GLsizei)arrayLength forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
		[Export ("setFloatArray:length:forUniform:program:")]
		unsafe void SetFloatArray (float* arrayValue, int arrayLength, int uniform, GLProgram shaderProgram);

		// -(void)setInteger:(GLint)intValue forUniform:(GLint)uniform program:(GLProgram *)shaderProgram;
		[Export ("setInteger:forUniform:program:")]
		void SetInteger (int intValue, int uniform, GLProgram shaderProgram);

		// -(void)setAndExecuteUniformStateCallbackAtIndex:(GLint)uniform forProgram:(GLProgram *)shaderProgram toBlock:(dispatch_block_t)uniformStateBlock;
		[Export ("setAndExecuteUniformStateCallbackAtIndex:forProgram:toBlock:")]
		void SetAndExecuteUniformStateCallbackAtIndex (int uniform, GLProgram shaderProgram, dispatch_block_t uniformStateBlock);

		// -(void)setUniformsForProgramAtIndex:(NSUInteger)programIndex;
		[Export ("setUniformsForProgramAtIndex:")]
		void SetUniformsForProgramAtIndex (nuint programIndex);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kGPUImageLuminanceFragmentShaderString;
		[Field ("kGPUImageLuminanceFragmentShaderString", "__Internal")]
		NSString kGPUImageLuminanceFragmentShaderString { get; }
	}

	// @interface GPUImageGrayscaleFilter : GPUImageFilter
	[BaseType (typeof(GPUImageFilter))]
	interface GPUImageGrayscaleFilter
	{
	}
}
