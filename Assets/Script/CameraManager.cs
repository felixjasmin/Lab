using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    //Déclaration des variables
    //Déclaration de la variable "joueur"/"player" qui se trouve à être l'avion
    public GameObject player;
    //Déclaration de la position désiré de la caméra
    private Vector3 offset = new Vector3(0, 10, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Place la caméra sur le joueur + plus son décalement ( la position désiré) ET qui suit l'avion (en gardant le offset) 
        transform.position = player.transform.position + offset;
    }
}
