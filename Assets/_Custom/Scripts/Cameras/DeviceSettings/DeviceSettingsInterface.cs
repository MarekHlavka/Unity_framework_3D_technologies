using LeiaUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceSettingsInterface : MonoBehaviour
{
    [SerializeField]
    private List<DeviceSettingsUnit> _settingsUnit = new List<DeviceSettingsUnit>();
    
    public void AddSettingsUnit(DeviceSettingsUnit unit) {  _settingsUnit.Add(unit); }

    public List<DeviceSettingsUnit> GetSettingsUnits()
    {
        return _settingsUnit;
    }
}
