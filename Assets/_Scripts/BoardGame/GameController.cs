using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    //private List<GameObject> playerList = new List<GameObject>();

    //instanciation du tableau contenant les objets de classe PlayerController
    private PlayerController[] playerList = new PlayerController[4];
    private PlayerController pc;
    private GameObject[] caseList;
    private int movingTime = 0;
    private int currentPlayer = 0;

    private bool canMove;

    private GameObject buttonPanel;
    // Start is called before the first frame update.
    void Start()
    {
        //dans un nouveau tableau on cherche d'abord tout les GameObjects avec le tag "Player",
        //ensuite on boucle dans ce tableau de gameobject et on attribue le composant script "PlayerController" 
        //de chaque gameobject (donc les joueurs) a chaque case du tableau
        buttonPanel = GameObject.Find("buttonPanel");
        GameObject[] playerGoList = GameObject.FindGameObjectsWithTag("Player");
        //pc = playerGoList[1].GetComponent<PlayerController>();
        for (int i = 0; i < playerGoList.Length; i++)
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
        if (canMove)
        {
            playerTurn();
        }


    }

    private void playerTurn()
    {

        buttonPanel.SetActive(true);

        for (int j = 0; j < movingTime; j++)
        {
            print("current player : " + currentPlayer);
            isEndBoard(currentPlayer);
            playerList[currentPlayer].playTurn(caseList[playerList[currentPlayer].getNextCase()].transform);
            print("looping");
        }
        //il faut récup la case sur laquelle on est et faire +1 pour se déplacer a la case suivante
        canMove = false;
        movingTime = 0;
        currentPlayerCheck();


    }

    private void isEndBoard(int i)
    {

        //il faut récup la case sur laquelle on est et faire +1 pour se déplacer a la case suivante
        if (caseList.Length == playerList[i].getCurrentCase() + 1)
        {
            playerList[i].setNextCase(0);
            playerList[i].setCurrentCase(0);
            print("is end board");
        }


    }
    private void currentPlayerCheck(){
        currentPlayer++;
        if (currentPlayer > playerList.Length-1)
        {
            currentPlayer = 0;
        }
    }

    public void setMoving(int i)
    {
        this.movingTime = i;
        canMove = true;
    }
}
