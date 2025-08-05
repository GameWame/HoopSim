using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour
{
 
    public GameObject alertGaze;

    // Start is called before the first frame update
    void Start()
    {
        alertGaze.SetActive(false);
    }

    public void isLooking()
    {
        Debug.Log("Guardando");
        alertGaze.SetActive(false);
    }

    public void isNotLooking()
    {
        Debug.Log("Non Guardando");
        alertGaze.SetActive(true);
    }
}
