using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    //private GameController gc;
    private PlateauController plateauController;
    private GameObject plateau;
    private GameObject panel;
    public Button bouton;
    private void Start()
    {
        plateau = GameObject.FindGameObjectsWithTag("Plateau")[0];
        plateauController = plateau.GetComponent<PlateauController>();
        //panel = GameObject.Find("buttonPanel");
        //panel.SetActive(true);
    }

    //fonction qu'on met sur les bouttons pour choisir une valeur de déplacement
    public void buttonChooseValue(int i)
    {
        //plateauController.movingTime=i;
        plateauController.playersControllers[plateauController.compteurChoix].movingTime = i;
        plateauController.playersControllers[plateauController.compteurChoix].entour = true;
        plateauController.compteurChoix++;
        if (plateauController.compteurChoix == plateauController.NB_PLAYERS) plateauController.compteurPlayer = 0;
        
    }

    //fonction servant a désactiver un GameObject en cliquant sur un boutton
    public void desactivateObjectOnClic()
    {
        //bouton.SetActive(false);
        bouton.interactable=false;

    }

    //fonction servant a activer un GameObject en cliquant sur un boutton
    public void activateObjectOnClic()
    {
        bouton.interactable=true;
        //bouton.SetActive(true);
    }
}
