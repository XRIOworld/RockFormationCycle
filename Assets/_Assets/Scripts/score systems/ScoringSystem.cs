using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour {

    public GameObject scoreText;
    public static int theScore;
    public AudioSource gameClip;
    bool didWin = false;


    void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;

        if (theScore >= 50 && !didWin)
        {
            didWin = true;
            YouWin();
            WinSong();

        }

    }

    void YouWin() {
        scoreText.GetComponent<Text>().text = "You Win!";
        Time.timeScale = 0f;
        
    }

    void WinSong() {
        gameClip.Play();
        didWin = true;
    }


}
