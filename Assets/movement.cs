using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float racketspeed = 10f;
    private GameObject racket1;
    private GameObject racket2;
    private float ymax = 3.91f;
    private float ymin = -3.91f;

    private void Awake()
    {
        racket1 = GameObject.Find("raqueteA");
        racket2 = GameObject.Find("raqueteB");
    }

    void Update()
    {

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, ymin, ymax));
        
        //player 1
        float player1 = Input.GetAxisRaw("Vertical2");
        racket1.transform.position += new Vector3(0, player1 * Time.deltaTime * racketspeed);
        
        //player 2
        float player2 = Input.GetAxisRaw("Vertical");
        racket2.transform.position += new Vector3(0, player2 * Time.deltaTime * racketspeed);
    }
}
