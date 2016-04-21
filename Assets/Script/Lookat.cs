using UnityEngine;
using System.Collections;
using Assets.Script;

public class Lookat : MonoBehaviour
{
    public GameObject CameraGameObject;

    readonly TimeOverEvent timeOverEvent = new TimeOverEvent();
	// Use this for initialization
	void Start ()
	{

	}

    // Update is called once per frame
	void Update () {

	    if (CameraGameObject != null)
	    {
            transform.LookAt(CameraGameObject.transform);

	    }
	    else
	    {
	        CameraGameObject = Camera.main.gameObject;
            transform.LookAt(CameraGameObject.transform);
            
        }

	}


    public void ActionTimer()
    {
        timeOverEvent.AddListener(GetGoName);
        Timer.Instance(timeOverEvent, 3);
    }

    public void ActionTimerOver()
    {
        Timer.Instance().StopTimer();
    }


    public void GetGoName()
    {
        Debug.Log(gameObject.name);
    }



}
