using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TestInputModule : BaseInputModule
{


    private PointerEventData pointerData;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Process()
    {
        if (pointerData != null)
        {
            HandlePointerExitAndEnter(pointerData,null);
        }
    }
}
