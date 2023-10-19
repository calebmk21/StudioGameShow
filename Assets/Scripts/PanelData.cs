using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PanelData : ScriptableObject
{
    public string panelName;
    public Sprite icon;
    [TextArea]
    public string description;
}
