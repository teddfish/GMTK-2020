using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            int newBI = SceneManager.GetActiveScene().buildIndex + 1;

            SceneManager.LoadScene(newBI);
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
