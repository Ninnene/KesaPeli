using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]   // Tämän avulla luodaan oma "pudotusmenu" Inspectoriin.
public class Dialogue
{
    public string name;


    [TextArea(3,10)] // Tämä suurentaa tekstilaatikkojen kokoa.
    public string[] sentences;
}
