using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Extencion para cambiar entre escenas
using UnityEngine.UI; //Extencion para usar los componentes de la UI

public class DeadZone : MonoBehaviour {
    public Text playerScoreText;
    public Text enemyScoreText;

    int playerScoreQuantity;
    int enemyScoreQuantity;

    public SceneChanger sceneChanger; //Variable para pasar el Scene Changer(dentro de un componente vacio) para usar su funcion en CheckScore()
    public AudioSource onePointSound; //Variable para pasar por referencia el ausio source de la misma dead zone, esto para reproducir el audio al anotar un punto

    /*
    private void OnCollisionEnter2D(Collision2D collision) //Detecta cuando algo(representado por la variable local collision) CHOCA con el collider del gameobject cuando el collider NO es un trigger
    {
        Debug.Log("Colision");
    }
    */

    private void OnTriggerEnter2D(Collider2D ball) //Detecta cuando algo(representado por la variable local ball) ENTRA en el collider del game object cuando este ES un trigger
    {
        if (gameObject.CompareTag("DeadZoneLeft")) //Si el game object al que esta agregado este cript tiene el tag DeadZoneLeft cuando algo lo atraviece...
        {
            enemyScoreQuantity++;
            UpdateScoreLabel(enemyScoreText, enemyScoreQuantity);
            onePointSound.Play(); //Reproducir audio al ganar un punto
        }
        else if (gameObject.CompareTag("DeadZoneRight")) //... si no, si el tag es DeadZoneRight...
        {
            playerScoreQuantity++;
            UpdateScoreLabel(playerScoreText, playerScoreQuantity);
            onePointSound.Play();
        }
        ball.GetComponent<BallMovement>().gameStarted = false; //De lo que choque con la dead zone(en este caso la pelota), se obtendra su componente BallMovement(su script), se accedera a la variable gameStarted y se cambiara su valor a false
        CheckScore(); //Checa en cada punto si alguno de los dos ya hizo 3 puntos
    }

    //NOTA: GameObject es la clase de donde se instancian todos los objetos del juego, y gameObject se refiere a un objeto instanciado de la clase GameObject.
    //Esto es parecido en la variable label de la funcion UpdateScoreLabel(), se declara con la clase Text como tipo de dato, y para acceder a la variable text de label se hace con .text

    void CheckScore() //Para que esta funcion funcione; el script SceneChanger(dentro de un componente vacio) debe agregarse como parametro desde el editor, dentro de la variable sceneChanger en este script
    {
        if (playerScoreQuantity == 3)
        {
            sceneChanger.ChangeSceneTo("WinScene");
        }
        else if (enemyScoreQuantity == 3)
        {
            sceneChanger.ChangeSceneTo("LoseScene");
        }
    }

    void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }
}