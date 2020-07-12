using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Score").GetComponent<ScoreManager>().canSwitchLevels)
        {

            int newBI = SceneManager.GetActiveScene().buildIndex + 1;

            SceneManager.LoadScene(newBI);
        }
    }
}
