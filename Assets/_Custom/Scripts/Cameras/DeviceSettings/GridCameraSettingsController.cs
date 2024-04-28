using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCameraSettingsController : MonoBehaviour
{

    [SerializeField] private GridCamera _camera;

    void Awake()
    {
        _camera = GetComponent<GridCamera>();
        if (_camera != null)
        {
            DeviceSettingsInterface _settings = GetComponent<DeviceSettingsInterface>();
            _settings.AddSettingsUnit(
                new DeviceSettingsUnit(
                    "Separation", setSeparation, _camera.getMinSeparation(), _camera.getMaxSeparation()
                )
            );
            _settings.AddSettingsUnit(
                new DeviceSettingsUnit(
                    "Convergence", setConvergence, _camera.getMinConvergence(), _camera.getMaxConvergence()
                )
            );
        }
    }

    private void setSeparation(float x)
    {
        _camera.separation = x;
    }

    private void setConvergence(float x)
    {
        _camera.convergence = x;
    }
}
