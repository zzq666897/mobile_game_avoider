using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TMP_Text tMP_Text;
    [SerializeField] private float ScoreMultiplier;

    public bool startTimer = true;

    private float score;


    // Update is called once per frame
    void Update()
    {
       if(!startTimer)
       {
           return;
       }
       
       score += ScoreMultiplier * Time.deltaTime;

       tMP_Text.text = Mathf.FloorToInt(score).ToString();
    }

    public int FinalScore()
    {
        //ScoreMultiplier = 0;

        startTimer = false;

        tMP_Text.text = string.Empty;

        int finalscore = Mathf.FloorToInt(score);

       return finalscore;
    }

    public void continueTimer()
    {
        startTimer = true;
    }
}
