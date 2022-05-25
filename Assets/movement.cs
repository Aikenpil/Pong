using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float racketspeed = 7f;
    private GameObject racket1;
    private GameObject racket2;
    private float ymax = 3.91f;
    private float ymin = -3.91f;

    private void Awake()
    {
        racket1 = GameObject.Find("raqueteA");
        racket2 = GameObject.Find("raqueteB");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, ymin, ymax));

        //player 1
        if (Input.GetKey(KeyCode.W))
        {
            racket1.transform.position += new Vector3(0, 1 * Time.deltaTime* racketspeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            racket1.transform.position += new Vector3(0, -1 * Time.deltaTime* racketspeed);
        }

        //player 2
        if (Input.GetKey(KeyCode.UpArrow))
        {
            racket2.transform.position += new Vector3(0, 1 * Time.deltaTime* racketspeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            racket2.transform.position += new Vector3(0, -1 * Time.deltaTime* racketspeed);
        }



    }
}
