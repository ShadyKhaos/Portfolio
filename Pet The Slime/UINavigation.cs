using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class UINavigation : MonoBehaviour
{
    [SerializeField] Slime slime;
    [SerializeField] GameObject[] Menus;
    [SerializeField] CustomMouse customMouse;
    static int currentMenuIndex = 0;

    private void Awake()
    {
        foreach(GameObject child in Menus){
            child.GetComponent<Canvas>().enabled = false ;
        }
        Menus[0].GetComponent<Canvas>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && currentMenuIndex != 0)
        {
            SwitchMenu(0); //swaps to default menu if not on it
        }else if( Input.GetKeyDown(KeyCode.Escape)&& currentMenuIndex == 0)
        {
            SwitchMenu(2); //opens option screen only if on default
        }
    }
    public void SwitchMenu(int x)
    {
        if (x != 0)
        {
            Time.timeScale = 0;
            slime.InvertCC();
        }
        else
        {
            slime.InvertCC();
            Time.timeScale = 1;
        }
        DefaultMouse();
        Menus[currentMenuIndex].GetComponent<Canvas>().enabled = false;
        Menus[x].GetComponent<Canvas>().enabled = true;
        currentMenuIndex = x;
    }
    void DefaultMouse()
    {
        customMouse.SwitchToDefault();
    }
}
