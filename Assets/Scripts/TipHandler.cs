using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using TMPro;
using UnityEngine;

public class TipHandler : MonoBehaviour
{
    public GameObject BaseTips;
    public TextMeshProUGUI textContent;
    public GameObject primaImg;
    public GameObject secondaImg;
    public GameObject terzaImg;

    public GameObject nextButton;
    public GameObject closeButton;

    private int counter=0;

    // Start is called before the first frame update
    void Start()
    {
        primaImg.SetActive(false);
        secondaImg.SetActive(false);
        terzaImg.SetActive(false);
        nextButton.SetActive(false);
        closeButton.SetActive(false);
        BaseTips.SetActive(false);
    }

    public void whenClicked()
    {
        counter ++;

        if (counter == 6)
        {
            textContent.text = ""; 
            terzaImg.SetActive(true);
            nextButton.SetActive(false);
        }

        if (counter == 5)
        {
            secondaImg.SetActive(false);
            textContent.text = "Infine per effettuare il tiro � necessario far partire la spinta dalle gambe, " +
                "e successivamente allungare le braccia dalla posizione impostata in precedenza verso l'alto. " +
                "Una volta arrivati alla massima estensione sia delle braccia che delle gambe, il polso della mano dominante deve piegarsi come ad emulare una 'frustata' e " +
                "lanciare la palla con una traiettoria parabolica.";
        }

        if (counter == 4)
        {
            textContent.text = "";
            secondaImg.SetActive(true);
        }

        if (counter == 3)
        {
            primaImg.SetActive(false);
            textContent.text = "Dopodich� bisogna affiancare la mano 'debole' a quella 'dominante', formando approssimativamente una 'T' coi pollici. " +
                "Una volta fatto ci� si pu� portare la palla in alto sopra la testa, formando un angolo di 90� o minore col tuo braccio dominante. " +
                "La posizione della palla deve essere tale da permetterti di vedere il canestro da sotto di essa. Questo passaggio serve per indirizzare meglio la parabola del tiro.";
        }

        if (counter == 2)
        {
            textContent.text = "";
            primaImg.SetActive(true);
        }

        if (counter == 1)
        {
            textContent.text = "Una volta sistemati piedi e ginocchia si pu� passare alle mani: anzitutto le dita sono l'unica parte a contatto con la palla e dunque " +
                "il palmo deve rimanere staccato. Successivamente vs posta la mano 'dominante' sulla palla cercando di posizionare pollice e mignolo alla stessa altezza " +
                "(� possibile aiutarsi utilizzando una delle linee orizzontali della palla).";
        }


    }

    public void CloseTips()
    {
        primaImg.SetActive(false);
        secondaImg.SetActive(false);
        terzaImg.SetActive(false);
        nextButton.SetActive(false);
        closeButton.SetActive(false);
        BaseTips.SetActive(false);
        counter = 0;
    }

    public void StartTips()
    {
        BaseTips.SetActive(true);
        nextButton.SetActive(true);
        closeButton.SetActive(true);
        textContent.text = "Prima di imparare la posizione delle mani � fondamentale avere una " +
            "postura di tiro corretta: i piedi devono essere tra loro paralleli ed essere indirizzati " +
            "verso il canestro, il piede 'dominante' dovrebbe essere leggermente pi� avanti rispetto al " +
            "quello 'debole'. Inoltre � anche importante piegare leggermente le ginocchia, " +
            "cos� da essere pronti a dare la spinta nel momento del tiro.";

    }
}
