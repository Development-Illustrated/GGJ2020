using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component
{

    public Sprite Icon;
    public string Name;

    public Component(Sprite icon, string name)
    {
        Icon = icon;
        Name = name;
    }
}
