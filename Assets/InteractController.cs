using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;



public class InteractController : MonoBehaviour
{
    private int nmesinhas, MAXMESINHAS;
    private bool obj1,obj2;
    private bool placed;
    private GameObject _leftHand;
    private XRRayInteractor _leftHandRay;
    private int MAXLIGHTS = 4;
    private int Nlights;
    [SerializeField] private string message;
    [SerializeField] private TMP_Text textObj, textNorma;
    public GameObject plug;
    public ActionBasedController rightHand;
    public InputHelpers.Button button;




    // Start is called before the first frame update
    void Start()
    {
        _leftHand = GameObject.Find("LeftHand Controller");
        _leftHandRay = _leftHand.GetComponent<XRRayInteractor>();
        placed = false;
        Nlights = 0;
        obj1 = false;
        obj2 = false;
        nmesinhas = 0;
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        bool pressed = false;
        if (_leftHand.GetComponent<ActionBasedController>().activateAction.action.ReadValue<float>() > 0.5f)
        {
            Debug.Log("trigger pressed");
            pressed = true;
        }
        RaycastHit point;
        _leftHandRay.TryGetCurrent3DRaycastHit(out point);
        GameObject wall;
        if (!point.Equals(null) && pressed && placed== false && obj1 == true)
        {
            if (Nlights < MAXLIGHTS )
            {
                if (point.point.y >= 3.5 && point.point.y <= 4)
                {
                    wall = point.transform.gameObject;
                    if (wall.layer == 8)
                    {
                        Transform[] children = wall.GetComponentsInChildren<Transform>(true);
                        Nlights++;
                        textNorma.color = Color.white;
                        textObj.text = "Objetivo: Coloca os candeeiros de parede no local correto " + Nlights.ToString() + "/4.";
                        textNorma.text = "Norma: Os candeeiros devem respeitar as normas de ergonomia(1,7 de altura, Mouse 1).";
                        placed = true;

                        GameObject g= GameObject.Instantiate(plug, new Vector3(point.point.x, point.point.y, point.point.z), plug.transform.rotation * Quaternion.Euler(0f,children[1].localEulerAngles.y, 0f));
                        g.transform.Rotate(0, children[1].localEulerAngles.y, 0);
                        if (Nlights == MAXLIGHTS)
                        {
                            obj2 = true;
                            textObj.text = "Objetivo: Coloca as cabeceiras perto de uma cama. ";
                            textNorma.text = "Norma: As cabeceiras devem estar entre uma certa distancia de uma cama (0.3-1m de uma cama).";
                        }
                    }
                }
                else
                {
                    textNorma.color = Color.red;
                }
                
            }
        }
        if(pressed==false && placed==true)
        {
            placed = false;
        }
    }

    void Obj1completed(bool a)
    {
        obj1 = true;
    }
    void Obj3completed(bool a)
    {
        nmesinhas++;
        if (nmesinhas >= MAXMESINHAS && obj2== true)
        {
            textObj.color = Color.green;
            textObj.text = "Todas as tarefas foram concluidas!";
            textNorma.text = "Pode ir beber um copo de vinho e relaxar.";
        }
    }
}