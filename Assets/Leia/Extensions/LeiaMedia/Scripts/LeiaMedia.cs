using UnityEngine;
using UnityEngine.Video;
using LeiaUnity;

public class LeiaMedia : MonoBehaviour
{
    public enum MediaType
    {
        Image,
        Video
    }

    [SerializeField] private MediaType mediaType;

    [SerializeField] private Texture2D sbsTexture;

    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private LeiaDisplay leiaDisplay;

    private Camera leftEyeCamera;
    private Camera rightEyeCamera;
    private Camera twoDimCamera;

    private Material leftMaterial;
    private Material rightMaterial;
    private Material twoDimMaterial;
    private RenderTrackingDevice.LightfieldMode lastKnownLightfieldMode;

    RenderTexture leftRT;
    RenderTexture rightRT;
    SimulatedRealityCamera srCam;

    private bool RTinitialized = false;

    void Start()
    {
        SetupRig();

        if (mediaType == MediaType.Video)
        {
            videoPlayer.errorReceived += HandleVideoError;
        }
    }

    private void Update()
    {
        if (!RTinitialized && leftEyeCamera.targetTexture != null && rightEyeCamera.targetTexture != null)
        {
            leftRT = new RenderTexture(leftEyeCamera.targetTexture.width, leftEyeCamera.targetTexture.height, leftEyeCamera.targetTexture.depth);
            rightRT = new RenderTexture(rightEyeCamera.targetTexture.width, rightEyeCamera.targetTexture.height, rightEyeCamera.targetTexture.depth);
            RTinitialized = true;
        }

        if (lastKnownLightfieldMode != RenderTrackingDevice.Instance.DesiredLightfieldMode)
        {
            lastKnownLightfieldMode = RenderTrackingDevice.Instance.DesiredLightfieldMode;
            SetupRig();
        }

        if (mediaType == MediaType.Video)
        {
            OnRenderObject();
        }
    }

    void SetupRig()
    {
        leftMaterial = leftMaterial ?? new Material(Shader.Find("Custom/SBS_Left"));
        rightMaterial = rightMaterial ?? new Material(Shader.Find("Custom/SBS_Right"));
        twoDimMaterial = twoDimMaterial ?? new Material(Shader.Find("Custom/SBS_Left"));

#if UNITY_EDITOR || PLATFORM_ANDROID
        leftEyeCamera = leiaDisplay.ViewersHead.eyes[0].eyecamera;
        rightEyeCamera = leiaDisplay.ViewersHead.eyes[1].eyecamera;
        twoDimCamera = leiaDisplay.HeadCamera;
#elif !UNITY_EDITOR && PLATFORM_STANDALONE_WIN
        GameObject srCameraObject = GameObject.Find("SRCamera");
        srCam = srCameraObject.GetComponent<SimulatedRealityCamera>();
        leftEyeCamera = srCam.GetCameraComponents()[0];
        rightEyeCamera = srCam.GetCameraComponents()[1];
#endif

        if (mediaType == MediaType.Image)
        {
            leftMaterial.mainTexture = sbsTexture;
            rightMaterial.mainTexture = sbsTexture;
        }
    }

    void OnRenderObject()
    {
        if (mediaType == MediaType.Video)
        {
            Graphics.Blit(videoPlayer.texture, leftRT, leftMaterial);
            Graphics.Blit(videoPlayer.texture, rightRT, rightMaterial);

        }
        else if (mediaType == MediaType.Image)
        {
            Graphics.Blit(sbsTexture, leftRT, leftMaterial);
            Graphics.Blit(sbsTexture, rightRT, rightMaterial);
        }
#if UNITY_EDITOR || PLATFORM_ANDROID
        if (RenderTrackingDevice.Instance.DesiredLightfieldMode == RenderTrackingDevice.LightfieldMode.On)
        {
            leftEyeCamera.targetTexture = leftRT;
            rightEyeCamera.targetTexture = rightRT;
            twoDimCamera.targetTexture = null;
        }
        else if (RenderTrackingDevice.Instance.DesiredLightfieldMode == RenderTrackingDevice.LightfieldMode.Off)
        {
            leftEyeCamera.targetTexture = leftRT;
            rightEyeCamera.targetTexture = leftRT;
        }
#elif !UNITY_EDITOR && PLATFORM_STANDALONE_WIN
        var compositor = SRUnity.SRRender.Instance.GetCompositor();

        var leftFramebuffer = compositor.GetFrameBuffer(srCam.GetCameraComponents()[0].GetInstanceID().ToString());
        var rightFramebuffer = compositor.GetFrameBuffer(srCam.GetCameraComponents()[1].GetInstanceID().ToString());

        leftFramebuffer.frameBuffer = leftRT;
        rightFramebuffer.frameBuffer = rightRT;
#endif
    }

    void HandleVideoError(VideoPlayer source, string message)
    {
        Debug.LogError("Video Error: " + message);
    }
}