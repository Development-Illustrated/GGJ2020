using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponent
{

    public Sprite Icon;
    public string Name;

    public UIComponent(Sprite icon, string name)
    {
        Icon = icon;
        Name = name;
    }
}
