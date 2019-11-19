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
    // Start is called before the first frame update
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
        //ce qui permet de se déplacer, CanMove est mise a true quand on appelle la fonction "setMoving(int i)" définie plus bas dans le code et utilisé dans la classe UiController
        //en l'occurence quand on appuie sur un des bouton de déplacement (1,2,3...)
        if (canMove)
        {
            //on appelle alors la fonction "playerTurn()" définie plus bas
            playerTurn();
        }


    }

    private void playerTurn()
    {
        //on affiche (et rend actif) les boutons de déplacement
        buttonPanel.SetActive(true);

        //on fait une boucle pour déplacer le joueur actuel n fois (movingTime ici), movingTime est attribué dans la méthode "setMoving(int i)" quand elle est appellé dans UiController
        //movingTime prend comme valeur le paramètre i passé dans "setMoving(int i)"
        for (int j = 0; j < movingTime; j++)
        {
            print("current player : " + currentPlayer);
            //on appelle isEndBoard définie plus bas pour le joueur actuel
            isEndBoard(currentPlayer);

            //on appelle la fonction "playTurn" du joueur actuel définie dans la classe PlayerController pour avancer
            playerList[currentPlayer].playTurn(caseList[playerList[currentPlayer].getNextCase()].transform);
            print("looping");
        }
        
        //on reinitialise les valeurs canMove et movingTime pour le prochain joueur
        canMove = false;
        movingTime = 0;
        //on appelle currentPlayerCheck() définie plus bas
        currentPlayerCheck();


    }

    //isEndBoard va checker si on est a la fin du plateau pour pouvoir refaire un tour
    private void isEndBoard(int i)
    {
        if (caseList.Length == playerList[i].getCurrentCase() +1 )
        {
            playerList[i].setNextCase(0);
            playerList[i].setCurrentCase(-1);
            print("is end board");
        }


    }

    //fonction qui sert a changer de joueur et pour checker si le dernier joueur a jouer pour recommencer un tour de joueurs
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
