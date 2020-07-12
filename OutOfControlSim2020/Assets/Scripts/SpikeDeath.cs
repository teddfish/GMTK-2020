using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeDeath : MonoBehaviour
{
    AudioSource playerAudio;
    public AudioClip deathSound;

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            playerAudio.PlayOneShot(deathSound, 0.8f);

            StartCoroutine(ResetLevel());
        }
    }

    public IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
