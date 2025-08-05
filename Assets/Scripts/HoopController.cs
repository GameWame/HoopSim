using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Timeline;

public class HoopController : MonoBehaviour
{
    public GameObject hoop;
    public GameObject tabelloneInv;
    public new Camera camera;

    int click = 0;
    float hoopY = 3;
    float freeThrowZ = (float)4.5;
    float altezzaPlayer = 1.78f; //usata media italiana e altezza developer, in futuro implementare personalizzazione
    float threePointerZ = (float)6.75;


    public void FreeThrow()
    {
        click = 0;
        var forward = Vector3.Cross(camera.transform.right, Vector3.up);
        var position = transform.position + forward * freeThrowZ;

        position.y = hoopY - altezzaPlayer + camera.transform.position.y;
        hoop.transform.position = position;

        var marker = camera.transform.position;

        marker.y = camera.transform.position.y + hoopY - altezzaPlayer;

        hoop.transform.LookAt(marker);

    }

    public void ThreePointer()
    {
        click = 0;
        //var forward = Vector3.Cross(GetComponent<Camera>().transform.right, Vector3.up);
        var forward = Vector3.Cross(camera.transform.right, Vector3.up);
        var position = transform.position + forward * threePointerZ;

        position.y = hoopY - altezzaPlayer + camera.transform.position.y;
        hoop.transform.position = position;

        var marker = camera.transform.position;

        marker.y = camera.transform.position.y + hoopY - altezzaPlayer;

        hoop.transform.LookAt(marker);


    }

    public void Rotate()
    {
        click++;

        if(click % 3 == 2)
        {
            var rotation = new Vector3(0, 180, 0);
            hoop.transform.Rotate(rotation);
            tabelloneInv.transform.Rotate(rotation);
        }

        else
        {
            var rotation = new Vector3(0, 90, 0);
            hoop.transform.Rotate(rotation);
            tabelloneInv.transform.Rotate(rotation);

        }
   

    }
}
