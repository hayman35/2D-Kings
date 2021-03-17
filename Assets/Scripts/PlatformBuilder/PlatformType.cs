using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlatformType : ScriptableObject
{
    //Prefab of the actual platform.
    public Transform platformPrefab;
    //Prefab of the visual ghost. Should be same prefab as the actual platform. But a different entity.
    public Transform GUIGhost;
}
