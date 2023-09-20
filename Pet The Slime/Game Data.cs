using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class GameData 
{
    [Header("ScoreKeeper")]
    public float score; //done
    public float currentMulti; //

    [Header("BalloonCounter")]
    public int balloonCount; //done

    [Header("WardrobeManager")]
    public Sprite[] currentHat; //issue
    public Sprite[] currentWings; //issue
    public Button wingsButton; //done?
    public Button hatButton; //

    [Header("Shop Buttons")]
    public List<WardrobeButton> hButtons;
    public List<WardrobeButton> wButtons;

    [Header("Slime")]
    public Sprite currentSlime; //done
    public int currentMilestone; //done
    public int milestoneInd; //done

    public GameData()
    {
        score = 0;
        currentMulti = 1;

        balloonCount = 0;

        currentHat = new Sprite[1];
        currentWings = new Sprite[2];
        wingsButton = null;
        hatButton = null;

        hButtons = new List<WardrobeButton>();
        wButtons = new List<WardrobeButton>();

        currentSlime = null;
        milestoneInd = 0;
        currentMilestone = 5;
    }
}
