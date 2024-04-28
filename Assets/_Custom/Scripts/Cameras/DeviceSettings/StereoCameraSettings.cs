using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StereoCameraSettings : MonoBehaviour
{
    // Start is called before the first frame update
    private StereoCamera stereoCamera;

    void Awake()
    {
        stereoCamera = GetComponent<StereoCamera>();
        if (stereoCamera != null)
        {
            DeviceSettingsInterface _settings = GetComponent<DeviceSettingsInterface>();
            _settings.AddSettingsUnit(
                new DeviceSettingsUnit(
                    "Separation", setSeparation, stereoCamera.getMinSeparation(), stereoCamera.getMaxSeparation()
                )
            );
            _settings.AddSettingsUnit(
                new DeviceSettingsUnit(
                    "Convergence", setConvergence, stereoCamera.getMinConvergence(), stereoCamera.getMaxConvergence()
                )
            );
        }
    }

    private void setSeparation(float x)
    {
        stereoCamera.separation = x;
    }

    private void setConvergence(float x)
    {
        stereoCamera.convergence = x;
    }
}
