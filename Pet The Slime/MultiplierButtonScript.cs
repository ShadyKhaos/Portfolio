using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierButtonScript : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    [SerializeField] MultiButton button;

    Transform nextButton;
    [SerializeField] string text;
    Text buttonText;
    int buttonIndex;
    private void OnEnable()
    {
        scoreKeeper = ScoreKeeper.Instance;
        if(buttonIndex < transform.parent.childCount-1)
        {
           nextButton = transform.parent.GetChild(buttonIndex + 1);
        }
    }

    private void Awake()
    {    
        buttonText = transform.GetChild(0).GetComponent<Text>();
        buttonText.text = text + button.GetMulti() + ": " + button.GetCost();
        buttonIndex = transform.GetSiblingIndex();
        if (buttonIndex != 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void Buy()
    {
        if (scoreKeeper.GetScore() < button.GetCost())
            return;
        scoreKeeper.IncMulti(button.GetMulti());
        scoreKeeper.DecScore(button.GetCost());
        NextButtonEnable();
        gameObject.GetComponent<Button>().interactable = false;
    }

    void NextButtonEnable()
    {
        if (nextButton == null) //if there is no next button go away
            return;
        nextButton.gameObject.GetComponent<Button>().interactable = true;
    }
}
