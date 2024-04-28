using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingGlassCameraSettings : MonoBehaviour
{

    [SerializeField] private LKG_Interface _interface;

    private void Awake()
    {
        _interface = GetComponent<LKG_Interface>();
        if (_interface != null)
        {
            DeviceSettingsInterface _settings = GetComponent<DeviceSettingsInterface>();
            _settings.AddSettingsUnit(
                new DeviceSettingsUnit(
                    "Near plane", setNearPlane, 1.0f, 5.0f
                )
            );
            _settings.AddSettingsUnit(
                new DeviceSettingsUnit(
                    "Far plane", setFarPlane, 5.0f, 40.0f, 30.0f
                )
            );
        }
    }

    private void setNearPlane(float x)
    {
        _interface.setNearPlane(x);
    }

    private void setFarPlane(float x)
    {
        _interface.setFarPlane(x);
    }
}
