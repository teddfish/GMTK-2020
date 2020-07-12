using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager inst;
    public TextMeshProUGUI text;
    int score;
    int total;
    public bool canSwitchLevels;

    GameObject[] totalCoins;
    // Start is called before the first frame update
    void Start()
    {
        if (inst == null)
        {
            inst = this;
        }
        totalCoins = GameObject.FindGameObjectsWithTag("Collectibles");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScore(int coin)
    {
        score += coin;
        text.text = score.ToString() + "/" + totalCoins.Length;

        if (score == totalCoins.Length || Input.GetKeyDown(KeyCode.F9))
        {
            canSwitchLevels = true;
        }
       
    }
}
