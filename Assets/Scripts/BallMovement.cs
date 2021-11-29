using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	public Transform paddle; //Variable para poner un componente de tipo Transform en el editor, en este caso el Paddle. Se puede hacer una variable de cualquier componente de unity
	public bool gameStarted = false; //Si un booleano no se inicializa este empezara como falso por default
	public Rigidbody2D rbBall; //Variable para referenciar el RigidBody2D de la pelota
	float positionDiference; //Variable para calcular la posicion de la pelota
	public AudioSource ballSound; //Variable para reproducir el audio de la pelota

	void Start ()
	{
		positionDiference = paddle.position.x - transform.position.x; //Calcula la diferencia entre la posicion inicial del paddle y la pelota al iniciar el juego, por ejemplo: 3 - 5 = -2
	}
	
	void Update ()
	{
        if (!gameStarted) //Si gameStarted es direrente de verdadero(por el !), o sea falso(lo cual si es el caso)...
        {
			transform.position = new Vector3(paddle.position.x - positionDiference, paddle.position.y, paddle.position.z); //Indica que la posicion de la pelota sera enfrente del paddle aunque se mueva porque en esa posicion inicia, usando la diferencia calculada en el Start(), por ejemplo: 3 - (-2) = 5. La pelota seguira el paddle hasta que se haga clic para empezar el juego

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