using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private int currentCase = -1; //-1 car le debut de la partie ne commence pas sur une case
    private int nextCase = 0; //0 car la la première case sera le premier déplacement
    private float moveSpeed = 2.5f;
    private int moveNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playTurn(Transform t)
    {
        Debug.Log("play turn !");
        //je fait tp les joueurs en attendant
        transform.position = t.position;
        print("current case : "+currentCase);
        print("next case : " + nextCase);
        currentCase++;
        nextCase = currentCase + 1;
    }


    public int getCurrentCase()
    {
        return this.currentCase;
    }
    public void setCurrentCase(int i)
    {
        this.currentCase = i;
    }
    public int getNextCase()
    {
        return this.nextCase;
    }
    public void setNextCase(int i)
    {
        this.nextCase = i;
    }

    public int getMoveNumber()
    {
        return moveNumber;
    }
    public void setMoveNumber(int i)
    {
        this.moveNumber = i;
    }
}
