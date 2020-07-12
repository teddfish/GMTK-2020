using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingLevels : MonoBehaviour
{
    public GameObject EndScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Score").GetComponent<ScoreManager>().canSwitchLevels || Input.GetKeyDown(KeyCode.Delete))
        {
            EndScreen.gameObject.SetActive(true);

            StartCoroutine(ChangeLevels());
        }
    }

    public IEnumerator ChangeLevels()
    {
        yield return new WaitForSeconds(3f);

        int newBI = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(newBI);


    }

}
