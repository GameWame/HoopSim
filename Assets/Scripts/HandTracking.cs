using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class HandTracking : MonoBehaviour
{

    public GameObject sphereMarker;
    public GameObject alert;
    public GameObject goodAlert;

    public GameObject shotAlert;
    public GameObject goodShotAlert;

    public Transform cameraTransform;

    GameObject rightthumbObject;
    GameObject leftthumbObject;
    GameObject indexObject;
    GameObject middleObject;
    GameObject ringObject;
    GameObject pinkyObject;
    float distance;

    MixedRealityPose pose;

    void Start()
    {
        rightthumbObject = Instantiate(sphereMarker, this.transform);
        leftthumbObject = Instantiate(sphereMarker, this.transform);
        indexObject = Instantiate(sphereMarker, this.transform);
        middleObject = Instantiate(sphereMarker, this.transform);
        ringObject = Instantiate(sphereMarker, this.transform);
        pinkyObject = Instantiate(sphereMarker, this.transform);

        alert.SetActive(false);
        goodAlert.SetActive(false);
        shotAlert.SetActive(false);
        goodShotAlert.SetActive(false);
    }

    void Update()
    {

        rightthumbObject.GetComponent<Renderer>().enabled = false;
        leftthumbObject.GetComponent<Renderer>().enabled = false;
        indexObject.GetComponent<Renderer>().enabled = false;
        middleObject.GetComponent<Renderer>().enabled = false;
        ringObject.GetComponent<Renderer>().enabled = false;
        pinkyObject.GetComponent<Renderer>().enabled = false;

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        {
            rightthumbObject.GetComponent<Renderer>().enabled = true;
            rightthumbObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out pose))
        {
            leftthumbObject.GetComponent<Renderer>().enabled = true;
            leftthumbObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out pose))
        {
            pinkyObject.GetComponent<Renderer>().enabled = true;
            pinkyObject.transform.position = pose.Position;
        }


    }

    public void checkPosition()
    {
        StartCoroutine(checkDistance());
    }

    private IEnumerator removeAlert(GameObject alert)
    {
        yield return new WaitForSeconds(3);

        alert.SetActive(false);
    }

    private void checkHeight()
    {

        float thumbY = rightthumbObject.transform.position.y;
        float pinkyY = pinkyObject.transform.position.y;

        //Mathf.Abs(thumbY); Mathf.Abs(pinkyY); non funzionanti per qualche motivo
        if(thumbY < 0)
        {
            thumbY *= -1;
        }

        if (pinkyY < 0)
        {
            pinkyY *= -1;
        }



        float height = thumbY - pinkyY;

        //Mathf.Abs(height); non funzionante per qualche motivo

        if (height < 0)
        {
            height *= -1;
        }

        if (height > 0.02)
        {
            print("Pollice: " + thumbY);
            print("Mignolo: " + pinkyY);
            print("Differenza: " + height);
            alert.SetActive(true);
            StartCoroutine(removeAlert(alert));
        }

        else
        {
            print("Pollice: " + thumbY);
            print("Mignolo: " + pinkyY);
            print("Differenza: " + height);
            goodAlert.SetActive(true);

            StartCoroutine(removeAlert(goodAlert));
        }
    }

    private IEnumerator checkDistance()
    {
        yield return new WaitForSeconds(5);

        distance = Vector3.Distance(rightthumbObject.transform.position, leftthumbObject.transform.position);

        if (distance > 0.08)
        {
            alert.SetActive(true);

            StartCoroutine(removeAlert(alert));
        }

        else if(distance <= 0.08)
        {
            checkHeight();
        }
    }

    private IEnumerator checkShot()
    {
        yield return new WaitForSeconds(5); //messo per il testing a 5 secondi

        var altezzaMano = rightthumbObject.transform.position.y; 
        var altezzaTesta = cameraTransform.position.y;

        var isHigh = altezzaMano - altezzaTesta;

        if (isHigh < 0.11) 
        {
            
            shotAlert.SetActive(true);
            StartCoroutine(removeAlert(shotAlert));
        }

        else
        {
            
            goodShotAlert.SetActive(true);
            StartCoroutine(removeAlert(goodShotAlert));
        }

    }

    public void checkhandHeight()
    {
        StartCoroutine(checkShot());
    }
}
