using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour, IDataPersistance
{
    public static ScoreKeeper Instance;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI[] scoreText;
    private float score = 0;
    private float scoreMultiplier = 1;
    [SerializeField] TextMeshProUGUI mulitText;

    [Header("Slime Color")]
    [SerializeField] Slime slime;
    [SerializeField] int[] milestones;
    public int milestoneInd;
    public int currentMilestone;
    bool isDone;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        mulitText.text = "Current Multi: " + GetMulti();
        AllScoreText("Pets: " + Mathf.Floor(score).ToString());
    }

    public void IncScore(float x)
    {
        score += (x*scoreMultiplier);
        AllScoreText("Pets: " + Mathf.Floor(score).ToString());
        if (score >= currentMilestone&&!isDone)
        {
            slime.GetComponent<Slime>().NextSlime();
            milestoneInd++;
            if (milestoneInd >= milestones.Length)
                isDone = true;
            else
                currentMilestone = milestones[milestoneInd];
        }
    }
    public void IncScoreBalloons(float x)
    {
        score += x;
        AllScoreText("Pets: " + Mathf.Floor(score).ToString());
        if (score >= currentMilestone && !isDone)
        {
            slime.GetComponent<Slime>().NextSlime();
            milestoneInd++;
            if (milestoneInd >= milestones.Length)
                isDone = true;
            else
                currentMilestone = milestones[milestoneInd];
        }
    }
    public void DecScore(int x)
    {
        score -= x;
        AllScoreText("Pets: " + Mathf.Floor(score).ToString());
    }
    public float GetScore()
    {
        return score;
    }
    public void IncMulti(float x)
    {
        scoreMultiplier += x;
        mulitText.text = "Current Multi: " + GetMulti();
    }
    public float GetMulti()
    {
        return scoreMultiplier;
    }
    void AllScoreText(string x)
    {
        foreach(TextMeshProUGUI child in scoreText)
        {
            child.text = x;
        }
    }

    public void LoadData(GameData data)
    {
        this.score = data.score;
        currentMilestone = data.currentMilestone;
        milestoneInd = data.milestoneInd;
    }

    public void SaveData(ref GameData data)
    {
        data.score = this.score;
        data.currentMilestone = currentMilestone;
        data.milestoneInd = milestoneInd;
    }
}
