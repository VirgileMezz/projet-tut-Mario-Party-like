using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //private List<GameObject> playerList = new List<GameObject>();

    //instanciation du tableau contenant les objets de classe PlayerController
    private PlayerController[] playerList = new PlayerController[4];
    private PlayerController pc;
    private GameObject[] caseList;

    // Start is called before the first frame update
    void Start()
    {
        //dans un nouveau tableau on cherche d'abord tout les GameObjects avec le tag "Player",
        //ensuite on boucle dans ce tableau de gameobject et on attribue le composant script "PlayerController" 
        //de chaque gameobject (donc les joueurs) a chaque case du tableau
        
        GameObject[] playerGoList = GameObject.FindGameObjectsWithTag("Player");
        //pc = playerGoList[1].GetComponent<PlayerController>();
        for(int i = 0; i < playerGoList.Length; i++)
        {
            print("boucle");
            print(playerGoList[i]);

            playerList[i] = playerGoList[i].GetComponent<PlayerController>();
        }
        caseList = GameObject.FindGameObjectsWithTag("case");
        
        //il est impossible de faire :
        //PlayerController[] playerList;
        //playerList = GameObject.FindGameObjectsWithTag("Player").getComponent<PlayerController>();
        //ce genre de manipulation marche pour un objet unique mais pas pour un tableau alors on est obligé de faire en 2 temps avec la boucle for...
    }

    // Update is called once per frame
    void Update()
    {
        //en attendant pour les tests, juste pour pas que ça s'active instant
        //appuyer sur espace pour lancer les tours (tout va se lancer d'un coup)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerTurn();
        }
    }

    private void playerTurn()
    {
        for (int i = 0; i < playerList.Length; i++)
        {            
            //il faut récup la case sur laquelle on est et faire +1 pour se déplacer a la case suivante
            isEndBoard();
            playerList[i].playTurn(caseList[playerList[i].getNextCase()].transform);
        }
    }

    private void isEndBoard()
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            //il faut récup la case sur laquelle on est et faire +1 pour se déplacer a la case suivante
            if(caseList.Length == playerList[i].getCurrentCase())
            {
                playerList[i].setNextCase(0);
                playerList[i].setCurrentCase(0);

            }

        }
    }
}
