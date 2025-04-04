using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour { 

    //Time that the button is set inactive after release
    public float deadTime = -1.0f;
    //Bool used to lock down button during its set dead time
    private bool _deadTimeActive = false;

    //public Unity Events we can use in the editor and tie other functions t0.
    public UnityEvent onPressed, onReleased;

    //Checks if teh current collider entering is the Button and sets off OnPressed event.
    private void OnTriggerEnter(Collider other){

        if(other.tag == "Button" && !_deadTimeActive)
        {
            onPressed?.Invoke();
            Debug.Log("Yeouch, you pressed me.");
        }
    }
    //Checks if the current collider exiting is the Button and sets off OnReleased event.
    //It will also call a Coroutine to make the button inactive for however long deadTime is set to.
    public void OnTriggerExit(Collider other) {

        if (other.tag == "Button" && !_deadTimeActive)
        {
            onReleased?.Invoke();
            Debug.Log("Whew...You let up off me.");
            StartCoroutine(WaitForDeadTime());
        }
    }

    //Locks button actively until deadTime has passed and reactivates button activity.
    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActive = false;
    }
}
