using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    private GameController gc;

    private void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    //fonction qu'on met sur les bouttons pour choisir une valeur de déplacement
    public void buttonChooseValue(int i)
    {
        gc.setMoving(i);
    }

    //fonction servant a désactiver un GameObject en cliquant sur un boutton
    public void desactivateObjectOnClic(GameObject o)
    {
        o.SetActive(false);
    }

    //fonction servant a activer un GameObject en cliquant sur un boutton
    public void activateObjectOnClic(GameObject o)
    {
        o.SetActive(true);
    }
}
