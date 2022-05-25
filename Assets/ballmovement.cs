using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmovement : MonoBehaviour
{

    private float ballspeed = 200f;
    private GameObject ball;
    private GameObject esquerda;
    private GameObject direita;
    private Vector3 posicao_inicial = new Vector3(0, 0, 0);
    private Collider colisao;

    private void Awake()
    {
        ball = GameObject.Find("Bola");
    }

    // Start is called before the first frame update
    void Start()
    {
        var x = Random.Range(0, 2) == 0 ? -1 : 1; 
        var y = Random.Range(0, 2) == 0 ? -1 : 1; 
        GetComponent<Rigidbody2D>().velocity = new Vector3(x * ballspeed * Time.deltaTime, y * ballspeed * Time.deltaTime);
    }
    void OnCollision2D(Collider colisao)
    {
        if (colisao.gameObject.tag == "parededireita")
        {
            gameObject.transform.position = posicao_inicial;
        }
        if(colisao.gameObject.tag == "paredesquerda")
        {
            gameObject.transform.position = posicao_inicial;
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
