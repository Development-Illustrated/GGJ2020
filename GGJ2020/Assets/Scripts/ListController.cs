using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListController : MonoBehaviour
{
    public Sprite [] ComponentImages;
    public GameObject ContentPanel;
    public GameObject ListItemPrefab;
    
    ArrayList Components;
    
    void Start () {
    
        // 1. Get the data to be displayed
        Components = new ArrayList (){
            new UIComponent(ComponentImages[0], "Hammer"),
            new UIComponent(ComponentImages[0], "Axe"),
            new UIComponent(ComponentImages[0], "Sword")
        };
        
        // 2. Iterate through the data, 
        //	  instantiate prefab, 
        //	  set the data, 
        //	  add it to panel
        foreach(UIComponent c in Components){
        GameObject newComponent = Instantiate(ListItemPrefab) as GameObject;
        ListItemController controller = newComponent.GetComponent<ListItemController>();
        controller.Icon.sprite = c.Icon;
        controller.Name.text = c.Name;
        newComponent.transform.parent = ContentPanel.transform;
        newComponent.transform.localScale = Vector3.one;
        }
    }
}