using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BalloonCounter : MonoBehaviour , IDataPersistance
{
    public static BalloonCounter Instance;
    [SerializeField] TextMeshProUGUI countText;
    int bCounter = 0;

    private float dmg = 1;

    [Header("Milestones")]
    public int[] milestones;
    int currentMilestone;
    int milestoneInd = 0;
    [SerializeField] BalloonSpawner balloonSpawner;

    private void Awake()
    {
        Instance = this;
        currentMilestone = milestones[milestoneInd];
        
    }
    private void Start()
    {
        countText.text = "Balloons Popped: " + bCounter;
    }
    public void BalloonPopped()
    {
        bCounter++;
        CheckMilestone();
        countText.text = "Balloons Popped: " + bCounter;
    }

    public float GetDmg()
    {
        return dmg;
    }

    void CheckMilestone() //checks if current milestone is reached if it is go to next milestone
    {
        if (bCounter < currentMilestone)
            return;
        milestoneInd++;
        if (milestoneInd < milestones.Length)
        {
            currentMilestone = milestones[milestoneInd];
            balloonSpawner.IncBalloonsSpawned();
            dmg += .5f;
        }
        //if certain milestones are reached do something maybe unlock buttons?
    }

    public void LoadData(GameData data)
    {
        bCounter = data.balloonCount;
    }
    public void SaveData(ref GameData data)
    {
        data.balloonCount = bCounter;
    }
}
