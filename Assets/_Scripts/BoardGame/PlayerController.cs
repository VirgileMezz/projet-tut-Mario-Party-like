using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int currentCel;
    public Transform playerT;
    public bool isMoving = false;
    public int movingTime;
    public int compteur = 0;
    public bool entour=false;
    public int compteurTour;
    private PlateauController plateauController;
    private GameObject plateau;
    // Start is called before the first frame update
    void Start()
    {
        playerT = GetComponentInParent<Transform>();
        currentCel = 1;
        compteurTour = 0;
        compteur = 0;
        movingTime = 0;
        plateau = GameObject.FindGameObjectsWithTag("Plateau")[0];
        plateauController = plateau.GetComponent<PlateauController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playTurn(Transform t)
    {
        Debug.Log("play turn !");
        Vector3 position = new Vector3(t.position.x, playerT.position.y, t.position.z);
        playerT.position=Vector3.MoveTowards(playerT.position, position, 2f);

        if (playerT.position == position)
        {
            currentCel++;
            isMoving = false;
        }
        if (currentCel > plateauController.NB_CELLS - 1)
        {
            currentCel = 0;
            addTour();
        }
        print(currentCel);
        //print(int);
    }


    public int getCurrentCase()
    {
        return this.currentCel;
    }

    public void setCurrentCase(int cel)
    {
        //Vector3.MoveTowards(playerT.position, cel.transform.position, 2f);
        //playerT.position = new Vector3(cel.transform.position.x, playerT.position.y, cel.transform.position.z);
        this.currentCel = cel;
    }

    public void setPosition(Vector3 position) {
        playerT.position = position;
    }

    public int getCompteurTour()
    {
        return compteurTour;
    }

    public void addTour()
    {
        compteurTour++;
    }
}
