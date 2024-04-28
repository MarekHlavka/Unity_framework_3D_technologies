using LeiaUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeiaDisplaySettings : MonoBehaviour
{

    [SerializeField]
    private LeiaDisplay cameraInterface;

    // Start is called before the first frame update
    void Awake()
    {
        DeviceSettingsInterface _settings = GetComponent<DeviceSettingsInterface>();
           _settings.AddSettingsUnit(new DeviceSettingsUnit(
            "test", setDepthFactor, 0.001f, 1.0f
        ));
    }

    private void setDepthFactor(float x)
    {
        cameraInterface.DepthFactor = x;
    }
}
