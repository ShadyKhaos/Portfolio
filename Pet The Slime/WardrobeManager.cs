using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WardrobeManager : MonoBehaviour, IDataPersistance
{
    SpriteRenderer hatSprite;
    SpriteRenderer[] wingsSprite = new SpriteRenderer[2];

    Sprite[] currentHat = new Sprite[1];
    Sprite[] currentWings = new Sprite[2];

    public static WardrobeManager Instance;
    ScoreKeeper scoreKeeper;

    public Button wingsButton;
    public Button hatButton;

    [SerializeField] Button defaultHatButton;
    [SerializeField] Button defaultWingsButton;

    private void Awake()
    {
        Instance = this;
        hatSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            wingsSprite[i] = transform.GetChild(1).GetChild(i).GetComponent<SpriteRenderer>();
        }
       
    }

    void Start()
    {
        scoreKeeper = ScoreKeeper.Instance;
        if (hatButton == null)
        {
            hatButton = defaultHatButton;
            hatButton.interactable = false;
        }
        if (wingsButton == null)
        {
            wingsButton = defaultWingsButton;
            wingsButton.interactable = false;
        }
    }

    public void ChangeSprite(Sprite[] x, int y, Button button)
    {
        switch (y)
        {
            case 0:
                hatSprite.sprite = x[0];
                currentHat[0] = hatSprite.sprite;
                changePreviousButton(y, button);
                break;
            case 1:
                for(int i = 0; i < wingsSprite.Length; i++)
                {
                    wingsSprite[i].sprite = x[i];
                    currentWings[i] = x[i];
                }
                changePreviousButton(y, button);
                break;
        }
    }
    
    public bool SameSprite(Sprite[] x, int y)
    {
        switch (y) 
        {
            case 0:
                return x[0] == currentHat[0];
            case 1:
                return x == currentWings;
        }
            return false;
    }

    public void setPreviousButton(Button button, int y)
    {
        switch (y)
        {
            case 0:
                hatButton = button;
                break;
            case 1:
                wingsButton = button;
                break;
        }
    }

    void changePreviousButton(int y, Button button)
    {
        switch (y)
        {
            case 0:
                    hatButton.interactable = true;
                    hatButton = button;
                    hatButton.interactable = false;
                break;
            case 1:
                wingsButton.interactable = true;
                wingsButton = button;
                wingsButton.interactable = false;
                break;
        }
    }
    //ScoreKeeperInteractions
    public float GetScore()
    {
        return scoreKeeper.GetScore();
    }
    public void DecScore(int x)
    {
        scoreKeeper.DecScore(x);
    }

    public void LoadData(GameData data)
    {
        currentHat[0] = data.currentHat[0];
        currentWings = data.currentWings;
        hatSprite.sprite = currentHat[0];
        wingsSprite[0].sprite = currentWings[0];
        wingsSprite[1].sprite = currentWings[1];
    }

    public void SaveData(ref GameData data)
    {
        for (int i = 0; i > currentWings.Length; i++)
        {
            data.currentWings[i] = currentWings[i];
        }
        data.currentHat = currentHat;

        data.hatButton = hatButton;
        data.wingsButton = wingsButton;
    }

}
