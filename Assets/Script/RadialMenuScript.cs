using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuScript : MonoBehaviour
{
    public Vector2 normalisedMousePosition;
    public float currentAngle;
    public static int selection;
    private int previousSelection;

    public GameObject[] menuItems;

    private MenuItemScript menuItemSc;
    private MenuItemScript previousmenuItemSc;
    private void Start()
    {

    }

    private void Update()
    {
        normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg;
        currentAngle = (currentAngle + 360) % 360;

        selection = (int)currentAngle / 90;

        if (selection != previousSelection)
        {
            previousmenuItemSc = menuItems[previousSelection].GetComponent<MenuItemScript>();
            previousmenuItemSc.Deselect();
            previousSelection = selection;

            menuItemSc = menuItems[selection].GetComponent<MenuItemScript>();
            menuItemSc.Select();
        }

        Debug.Log(selection);

        
    }

}
