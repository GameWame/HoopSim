using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class GazeHandler : MonoBehaviour
{
    public SphereCollider sfera;
    public GameObject alert;
    public GameObject gazeController;
    int numClick = 0;
    
    void Start()
    {
       
        sfera.enabled = false;
        alert.SetActive(false);
        gazeController.SetActive(false);

    }

    public void OnClick()
    {
        numClick++;

        if (numClick % 2 == 1)
        {
            sfera.enabled = true;
            gazeController.SetActive(true);
        }

        else
        {
            alert.SetActive(false);
            gazeController.SetActive(false);

            sfera.enabled = false;
 
        }
    }
}
