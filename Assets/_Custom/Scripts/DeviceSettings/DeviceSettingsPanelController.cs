using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeviceSettingsPanelController : MonoBehaviour
{

    [SerializeField]
    private DeviceSettingsInterface settings;
    [SerializeField]
    private GameObject prefab;
    

    // Start is called before the first frame update
    public void Load(DeviceSettingsInterface activeCameraSettings)
    {
        if (activeCameraSettings != null)
        {
            settings = activeCameraSettings;
            List<DeviceSettingsUnit> units = settings.GetSettingsUnits();

            if (units == null)
            {
                return;
            }

            // TODO LOOP

            //DeviceSettingsUnit unit = units[0];

            foreach (DeviceSettingsUnit unit in units)
            {
                GameObject newPanel = Instantiate(prefab, transform);
                DisplaySettingsSliderPanel newSettings = newPanel.GetComponent<DisplaySettingsSliderPanel>();
                newSettings.Init(unit.GetName(),unit.GetDef(), unit.GetAction(), unit.GetMin(), unit.GetMax());
            }
        }
    }

    public void ClearUI()
    {
        foreach (Transform t in transform.GetComponentInChildren<Transform>())
        {
            Destroy(t.gameObject);
        }
    }

    public void unsetDeviseSettingsInterface()
    {
        settings = null;
    }
}
