using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeButtonScript : MonoBehaviour,IDataPersistance
{
    WardrobeManager wardrobeManager;

    [SerializeField] WardrobeButton button;
    int buttonType;
    Text buttonText;

    Image image;

    [SerializeField] string bString;

    bool isWearing = false;
    Button buttonComp;

    private void Awake()
    {
        buttonType = button.GetSpriteType();
        buttonText = transform.GetChild(0).GetComponent<Text>();
        image = transform.GetChild(1).GetComponent<Image>();
        buttonComp = GetComponent<Button>();
        wardrobeManager = WardrobeManager.Instance;
        buttonText.text = bString + button.GetCost();
    }
    

    public void Buy()
    {
        if (button.IsPurchased() && !wardrobeManager.SameSprite(button.GetSprite(),button.GetSpriteType()) ) 
        {
            wardrobeManager.ChangeSprite(button.GetSprite(),button.GetSpriteType(), buttonComp);
            return;
        }

        var cost = button.GetCost();

        if (wardrobeManager.GetScore() >= cost && !button.IsPurchased())
        {
            image.gameObject.SetActive(true);
            buttonText.gameObject.SetActive(false);
            wardrobeManager.DecScore(cost);
            wardrobeManager.ChangeSprite(button.GetSprite(),button.GetSpriteType(),buttonComp);
            button.setPurchased();
        }
    }
    public void LoadData(GameData data)
    {
        if (buttonType == 0)
        {
            foreach(WardrobeButton b in data.hButtons)
            {
                if (b == button && b.IsPurchased()) //if the button in gamedata is this button && been purchased before
                {
                    SetButton(data);
                }
            }
        }
        else
        {
            foreach (WardrobeButton b in data.wButtons)
            {
                if (b == button && b.IsPurchased()) //if the button in gamedata is this button && been purchased before
                {
                    SetButton(data);
                }
            }
        }
    }
    public void SetButton(GameData data)
    {
        image = transform.GetChild(1).GetComponent<Image>();
        image.gameObject.SetActive(true);
        buttonText = transform.GetChild(0).GetComponent<Text>();
        buttonText.gameObject.SetActive(false);
        if ( (data.currentHat[0] == button.GetSprite()[0] && buttonType == 0) || ( data.currentWings[0] == button.GetSprite()[0] && buttonType == 1)) 
        {
            wardrobeManager = WardrobeManager.Instance;
            buttonComp = GetComponent<Button>();
            buttonComp.interactable = false;
            wardrobeManager.setPreviousButton(buttonComp, buttonType);
        }
    }
    public void SaveData(ref GameData data) 
    {
        if (data.hButtons.Contains(button))
            return;
        if (data.wButtons.Contains(button))
            return;
        switch (buttonType)
        {
            case 0:
                data.hButtons.Add(button);
                break;
            case 1:
                data.wButtons.Add(button);
                break;
        }
    }
}
