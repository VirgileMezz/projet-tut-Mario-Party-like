using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauController : MonoBehaviour
{
    public int NB_CELLS = 50;
    public int NB_PLAYERS = 4;
    public GameObject[] cells;
    public GameObject CelPrefab;
    public GameObject PlayerPrefab;
    public GameObject[] players;
    public PlayerController[] playersControllers;
    public GameObject[] boutons;
    private GameObject firstCel;
    public bool avance;
    public int compteurChoix;
    public int compteurPlayer;
    //public bool isMoving = false;
    public int movingTime;
    public Transform t;
    // Start is called before the first frame update
    void Start()
    {
        CelPrefab = (GameObject)Resources.Load("prefabs/Cel", typeof(GameObject));
        PlayerPrefab = (GameObject)Resources.Load("prefabs/Player", typeof(GameObject));
        
        boutons = GameObject.FindGameObjectsWithTag("bouton");
        CreatePlayers();
        CreateCells();
        PutCells();
        movingTime = 0;
        compteurChoix = 0;
        compteurPlayer = 0;
        PutPlayers();
    }


    private void CreateCells()
    {
        cells = new GameObject[NB_CELLS];
        for (int i = 0; i < NB_CELLS; i++)
        {
            cells[i] = Instantiate(CelPrefab);
        }
        firstCel = cells[0];
    }

    private void CreatePlayers()
    {
        players = new GameObject[NB_PLAYERS];
        playersControllers = new PlayerController[NB_PLAYERS];
        for (int i = 0; i < NB_PLAYERS; i++)
        {
            players[i] = Instantiate(PlayerPrefab);
            playersControllers[i] = players[i].GetComponent<PlayerController>();
        }
        
    }

    private void PutPlayers()
    {
        foreach(GameObject player in players)
        {
            player.transform.position = new Vector3(cells[0].transform.position.x, player.transform.position.y, cells[0].transform.position.z);
        }
        
    }

    private void PutCells()
    {
        for(int i=0; i<NB_CELLS; i++)
        {
            float x = Cycloide(0, 20, i)[0];
            float z = Cycloide(0, 20, i)[1];

            cells[i].transform.position = new Vector3(x, cells[i].transform.position.y, z);
        }
    }

    public void movePlayer(int i)
    {
        if (playersControllers[i].entour)
        {

            if (playersControllers[i].isMoving) playersControllers[i].playTurn(t);
            else if (!playersControllers[i].isMoving && playersControllers[i].compteur < playersControllers[i].movingTime)
            {
                t = cells[playersControllers[i].getCurrentCase()].GetComponent<Transform>();
                playersControllers[i].compteur++;
                playersControllers[i].isMoving = true;
            }
            else
            {
                
                playersControllers[i].entour = false;
                playersControllers[i].compteur = 0;
                if (compteurPlayer == NB_PLAYERS - 1)
                {
                    foreach (GameObject bouton in boutons)
                    {
                        UiController controller = bouton.GetComponent<UiController>();
                        controller.activateObjectOnClic();
                        compteurChoix = 0;
                    }
                }
                compteurPlayer++;


            }
        }
    }

    public void Update()
    {
        if (compteurChoix == NB_PLAYERS)
        {
            if(compteurPlayer<NB_PLAYERS)
            movePlayer(compteurPlayer);
        }
        

    }

    public float[] Cycloide(float R, float r, float i)
    {
        float teta =(float) (2 * Math.PI / NB_CELLS) * i;
        float x = (float)((R + r) * Math.Cos(((R + r) / r) * teta));
        float z = (float)((R + r) * Math.Sin(((R + r) / r) * teta));

        return new float[] { x, z };
    }
}
