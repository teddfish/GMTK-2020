using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraTargets : MonoBehaviour
{
    [SerializeField]
    GameObject target1;
    [SerializeField]
    GameObject target2;
    [SerializeField]
    GameObject target3;
    [SerializeField]
    GameObject target4;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;

        if (currentPos == target4.transform.position)
        {
            if (player.transform.position.x > ScreenUtils.ScreenRight)
            {
                this.transform.position = target1.transform.position;
                currentPos = transform.position;
            }
            else if (player.transform.position.y > ScreenUtils.ScreenTop)
            {
                this.transform.position = target2.transform.position;
                currentPos = transform.position;
            }
            else if (player.transform.position.y > ScreenUtils.ScreenTop && player.transform.position.x > ScreenUtils.ScreenRight)
            {
                this.transform.position = target3.transform.position;
                currentPos = transform.position;
            }
        }


    }
}
