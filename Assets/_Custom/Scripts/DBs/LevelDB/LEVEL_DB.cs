using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVEL_DB : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    public List<GameObject> GetLevels() { return levels; }
    public void SetLevels(List<GameObject> levels)
    {
        this.levels.Clear();
        this.levels = levels;
    }
}
