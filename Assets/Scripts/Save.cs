using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
    public List<float> xPositions = new List<float>();
    public List<float> yPositions = new List<float>();
    public List<string> tileNames = new List<string>();
    public List<Color> tileColor = new List<Color>();
}
