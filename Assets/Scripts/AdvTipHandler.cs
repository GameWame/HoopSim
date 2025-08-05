using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdvTipHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject advTips;
    public TextMeshProUGUI DynamicTips;

    public GameObject nextButton;
    public GameObject closeButton;

    int counter;

    public void OnClick()
    {       
        counter++;

        if (counter == 3)
        {
            nextButton.SetActive(false);
            DynamicTips.text = "La posizione del tuoi piedi deve essere larga circa quanto la larghezza delle tue spalle, così da garantirti il massimo equilibrio." +
                "Inoltre durante il tiro cerca di lanciare la palla poco prima di raggiungere la tua massima estensione (salto compreso).";
        }
        if (counter == 2)
        {
            DynamicTips.text = "A seconda della tua altezza o forza, potrebbe essere necessario saltare durante un tiro libero. Ciò" +
                " non è vietato devi solo fare attenzione a non toccare la linea dei tiri liberi altrimenti commetterai un fallo, a tal proposito cerca sempre, in caso " +
                "di salto, di 'riatterrare' nel punto dal quale sei partito.";
        }
        if (counter == 1)
        {
            DynamicTips.text = "Quando dai la 'frustata' finale alla palla prima di lanciarla verso il canestro, cerca di conferirle una " +
                "rotazione, in questo modo la traiettoria verrà curvata e sarà più facile che tu faccia canestro. Inoltre dopo aver tirato cerca di " +
                "rimanere con il braccio in posizione, così potrai correggerti su eventuali errori.";
        }
    }

    public void StartAdvancedTips()
    {
        advTips.SetActive(true);
        DynamicTips.text = "Durante lo svolgimento del tiro è fondamentale avere sempre gli occhi sulla palla e controllare il respiro: " +
                "una respirazione profonda aiuta a mantenere la concentrazione durante tutta l'esecuzione.";
        nextButton.SetActive(true);
        closeButton.SetActive(true);
    }

    public void CloseAdvancedTips()
    {
        counter = 0;
        closeButton.SetActive(false);
        advTips.SetActive(false);

    }

    void Start()
    {
        advTips.SetActive(false);
        nextButton.SetActive(false);
        closeButton.SetActive(false);
        counter = 0;
    }

  
}
