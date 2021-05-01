using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Extension para manejar el cambio entre escenas

//Este script es para cambiar la escena al presionar el boton PLAY AGAIN, para poder usar la funcion ChangeSceneTo(), se crea un objeto vacio, se le agrega este script y ese objeto se agrega al On Click () del boton para seleccionar la funcion a usar, y en el espacio que aparece en el editor despues de seleccionar la funcion a usar, se escribe el parametro que pide la funcion, en este caso el nombre de la escena a cargar. Para todo esto, la funcion debe ser publica

public class SceneChanger : MonoBehaviour {
	public void ChangeSceneTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}