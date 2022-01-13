using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemScript : MonoBehaviour
{
    public Color hoverColor;
    public Color baseColor;
    public Image background;
    public GameObject description;

    private void Start()
    {
        background.color = baseColor;
        description.SetActive(false);
    }

    public void Select()
    {
        background.color = hoverColor;
        description.SetActive(true);
    }

    public void Deselect()
    {
        background.color = baseColor;
        description.SetActive(false);
    }
}
