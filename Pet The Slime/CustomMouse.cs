using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomMouse : MonoBehaviour
{
    [Header("Normal Cursor")]
    public Texture2D normalMouse;
    public Vector3 normalDisplacement;
    public Texture2D clickMouse;
    public Vector3 clickDisplacement;
    [Header("Custom Cursor")]
    public GameObject petMouse;
    public Vector3 petDisplacement;
    Animator animator;
    public bool isPetting;
    [SerializeField] Texture2D dartMouse;
    
    // maybe make another for balloons

    void Start()
    {
        isPetting = false;
        animator = petMouse.GetComponent<Animator>();
        petMouse.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!isPetting) //&& mouse hovering over slime
        {
            StartCoroutine(PetDelay());
        }
        petMouse.transform.position = Input.mousePosition + petDisplacement;
    }


    IEnumerator PetDelay()
    {
        isPetting = true;
        animator.SetBool("isPetting", true);
        yield return new WaitForSeconds(.2f);
        animator.SetBool("isPetting", false);
        isPetting = false;
    }

    public void OnButtonCursorEnter(GameObject gameObject)
    {
        //if (!gameObject.GetComponent<Button>().interactable)
            //return;
        Cursor.SetCursor(clickMouse, normalDisplacement, CursorMode.Auto);
    }
    public void OnButtonCursorExit()
    {
        SwitchToDefault();
    }

    public void OnSlimeEnter()
    {
        Cursor.visible = false;
        petMouse.gameObject.SetActive(true);
    }
    public void OnSlimeExit()
    {
        isPetting = false;
        petMouse.gameObject.SetActive(false);
        Cursor.visible = true;
    }

    public void OnBalloonEnter()
    {
        Cursor.SetCursor(dartMouse, normalDisplacement, CursorMode.Auto);
    }
    public void OnBalloonExit()
    {
        SwitchToDefault();
    }

    public void SwitchToDefault()
    {
        Cursor.SetCursor(normalMouse, clickDisplacement, CursorMode.Auto);
    }

}
