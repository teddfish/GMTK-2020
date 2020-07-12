using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatrollingScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rayLength;
    bool goingPlus = true;

    [SerializeField] Transform groundDetection;

    AudioSource playerAudio;
    public AudioClip deathSound;

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();    
    }

    private void Update()
    {
        // this code works
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(groundDetection.position, Vector2.down, rayLength);

        if (ground.collider == false)
        {
            if (goingPlus == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                goingPlus = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                goingPlus = true;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(groundDetection.position, Vector2.down);
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
