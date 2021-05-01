using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {
	public Transform ball; //Variable para usar la posicion de la pelota en "y"	
    public float speed; //Velocidad con la que el enemigo perseguira la pelota

	void Update () {
        if (ball.GetComponent<BallMovement>().gameStarted) //Si gameStarted es verdadero
		{
            if (transform.position.y < ball.position.y) //Si la posicion en "y" del enemy paddle(game object en donde esta este script) es menor a la posicion en "y" de la pelota...
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + speed, -3.8f, 3.8f), transform.position.z); //... se le sumara velocidad a la posicion en "y" del enemy paddle y estara restringido entre -3.8 y 3.8
            }
            else if (transform.position.y > ball.position.y) //Si no, si la posicion en "y" del enemy paddle(game object en donde esta este script) es mayor a la posicion en y de la pelota...
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - speed, -3.8f, 3.8f), transform.position.z); //... se le restara velocidad a la posicion en "y" del enemy paddle y estara restringido entre -3.8 y 3.8
            }
        }
	}
}