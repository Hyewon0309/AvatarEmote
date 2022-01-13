using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isActivated;
    //private bool isEmoting;
    private int selected;

    public GameObject[] expressionItems;
    public GameObject radialMenu;

    private void Start()
    {
        isActivated = false;
        radialMenu.gameObject.SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            expressionItems[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            isActivated=!isActivated;
        }
        if (isActivated && Input.GetMouseButtonDown(0))
        {
            selected = RadialMenuScript.selection;
            StartCoroutine(expressionActive(selected));
            isActivated = !isActivated;
        }
        radialMenuActivate();
    }

    private void radialMenuActivate()
    {
        if (isActivated)
        {
            radialMenu.gameObject.SetActive(true);
        }

        else
        {
            radialMenu.gameObject.SetActive(false);
        }
    }

    IEnumerator expressionActive(int num)
    {
        for (int i = 0; i < 4; i++)
        {
            expressionItems[i].gameObject.SetActive(false);
        }
        expressionItems[num].gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        expressionItems[num].gameObject.SetActive(false);
    }

    /*
    private void checkEmoteOn()
    {
        for (int i = 0; i < 4; i++)
        {
            if (expressionItems[i].gameObject.activeSelf == true)
            {
                isEmoting = true;
                break;
            }
            else
            {
                isEmoting = false;
            }
        }
    }*/

}