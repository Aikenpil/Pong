using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class ballmovement : MonoBehaviour
{

    private float speed = 10;
    private float maxspeed = 35;

    private int pointplayer1 = 1;
    private int pointplayer2 = 1;

    [SerializeField] private TMP_Text player1;
    [SerializeField] private TMP_Text player2;

    private Rigidbody2D ball;
    private GameObject paredesquerda;
    private GameObject parededireita;
    
    private Vector3 posicao_inicial = new Vector3(0, 0, 0);

    private void Awake()
    {
        paredesquerda = GameObject.Find("paredesquerda");
        parededireita = GameObject.Find("parededireita");
    }

    void Start()
    { 
        ball = GetComponent<Rigidbody2D>();
        ball.velocity = new Vector2((Random.Range(0, 2)*2-1) * speed, 0);
    }
    
    void ResetBall(){
        speed = 10f;
        ball.velocity = new Vector2((Random.Range(0, 2)*2-1) * speed, 0);
        ball.transform.position = posicao_inicial;
    }

    float hitFactor(Vector2 bolaPos, Vector2 jogPos, float tam){		
	    return (bolaPos.y - jogPos.y)/tam;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == parededireita){
            player1.text = pointplayer1++.ToString();
            ResetBall();
        }
        if(other.gameObject == paredesquerda){
            player2.text = pointplayer2++.ToString();
            ResetBall();
        }
        
		if (other.gameObject.name == "raqueteA"){
			float y = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.y);
			Vector2 dir = new Vector2(1,y).normalized;
			ball.velocity = dir*speed;
            if(speed < maxspeed) { speed++; }
            //speed++;
        }
		if (other.gameObject.name == "raqueteB"){
			float y = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1,y).normalized;
			ball.velocity = dir*speed;
            if(speed < maxspeed) { speed++; }
        }
    }   
}
