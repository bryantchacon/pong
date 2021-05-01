using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	void Start () { //El Start de cada game object se ejecuta una sola vez al iniciar el juego
	}
	
	void Update () { //El Update de cada game object se ejecuta cada fps, el codigo que vaya aqui no debe ser muy pesado, si no, eso bajara los fps
		//Debug.Log(Input.mousePosition); //Muestra en consola las coordenadas de la posicion del mouse
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Indica que detectara las coordenadas de la posicion del mouse cuando este en la pantalla del mundo del juego, esto con ScreenToWorldPoint, porque traduce la posicion de los pixeles en la pantalla a la posicion del mundo del juego

		transform.position = new Vector3(transform.position.x, Mathf.Clamp(mousePosition.y, -3.8f, 3.8f), transform.position.z); //Indica que la posicion del paddle(porque tiene este script) sera(por new Vector3) en el eje "y" la del mousePosition con limite de movimiento entre los valores -3.8 y 3.8 en "y", y "x" y "z" quedan en la posicion que se indica en el editor antes de empezar el juego, o sea, en la que se dejo
	}
}