using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	public Transform paddle; //Variable para poner un componente de tipo Transform en el editor, en este caso el Paddle. Se puede hacer una variable de cualquier componente de unity
	public bool gameStarted = false; //Si un booleano no se inicializa este empezara como falso por default
	public Rigidbody2D rbBall; //Variable para referenciar el RigidBody2D de la pelota
	float positionDiference; //Variable de la posicion de la pelota
	public AudioSource ballSound; //Variable para reproducir el audio de la pelota

	void Start () {
		positionDiference = paddle.position.x - transform.position.x; //Indica que cada que se inice el juego o una nueva partida, la posicion de la pelota en x siempre sera la misma que la del paddle
	}
	
	void Update () {
        if (!gameStarted) //Si gameStarted es direrente de verdadero(por el !), o sea falso(lo cual si es el caso)...
        {
			transform.position = new Vector3(paddle.position.x - positionDiference, paddle.position.y, paddle.position.z); //Indica que la posicion de la pelota(porque tiene este cript) sera(por new Vector3) la misma que la del paddle(por el .position de paddle porque el Paddle se puso en la variable desde el editor) porque lo seguira y se moveran juntos, hasta que no se haga clic para empezar el juego

            if (Input.GetMouseButtonDown(0)) //Si se detecta el clic izquierdo del mouse, el cual se representa con 0...
            {
				rbBall.velocity = new Vector2(8,8); //Direccion en la que saldra disparada la pelota
				gameStarted = true; //... gameStarted sera true
            }
        }
	}

	private void OnCollisionEnter2D(Collision2D collision) //Cuando la pelota(la cual tiene este script) choque con cualquier cosa...
    {
		ballSound.Play(); //... reproducira su audio
    }
}