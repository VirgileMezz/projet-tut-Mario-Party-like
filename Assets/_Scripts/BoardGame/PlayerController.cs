using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int currentCase = 0;
    private int nextCase = 0;
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

        print(currentCase);
        print(nextCase);
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
}
