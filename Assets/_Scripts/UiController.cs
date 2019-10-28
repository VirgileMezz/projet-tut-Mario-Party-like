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
    public void buttonChooseValue(int i)
    {
        gc.setMoving(i);
    }
    public void desactivateObjectOnClic(GameObject o)
    {
        o.SetActive(false);
    }
    public void activateObjectOnClic(GameObject o)
    {
        o.SetActive(true);
    }
}
