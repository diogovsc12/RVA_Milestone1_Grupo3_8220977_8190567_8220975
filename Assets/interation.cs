using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



public class interaction : MonoBehaviour
{



    private GameObject _leftHand;
    private XRRayInteractor _leftHandRay;
    private int count;


    public GameObject Lamp_Wall;




    public ActionBasedController rightHand;
    public InputHelpers.Button button;




    // Start is called before the first frame update
    void Start()
    {
        _leftHand = GameObject.Find("LeftHand Controller");
        _leftHandRay = _leftHand.GetComponent<XRRayInteractor>();
        count = 0;
    }



    // Update is called once per frame
    void Update()
    {




        bool pressed = false;





        if (_leftHand.GetComponent<ActionBasedController>().activateAction.action.ReadValue<float>() > 0.5f)
        {
            Debug.Log("trigger pressed");
            pressed = true;
        }



        //rightHand.inputDevice.IsPressed(button, out pressed);



        if (pressed)
        {
            Debug.Log("Hello - " + button);
        }




        RaycastHit point;
        _leftHandRay.TryGetCurrent3DRaycastHit(out point);

        if (!point.Equals(null) && pressed && count<=0)
        {
            Instantiate(Lamp_Wall, new Vector3(point.point.x, point.point.y, point.point.z), new Quaternion(0, 0, 0, 0));
            Debug.Log("Text: " + point.transform.gameObject.name.ToString());
            count++;
            //if (Input.GetButtonDown("Grab"))
            //{
            //Instantiate(plug, new Vector3(point.point.x, point.point.y,point.point.z));
            //Instantiate(plug, point.transform, true);
            //}
        }
        else
        {
            Debug.Log("Not : ");
        }

    }
    /*
    private void FixedUpdate()
    {
        
    }

 

    private void OnSelectEvent(HoverEnterEventArgs args)
    {
        //interactable Object 
        //args.interactableObject
        Debug.Log("Selected: " );
    }
    */
    void Rule1(bool a)
    {
        Debug.Log("Received ball collision ");
    }



}
