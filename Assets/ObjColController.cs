using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjColController : MonoBehaviour
{
    private bool obj1;
    private Transform place;
    [SerializeField] private LayerMask TypeMask;
    [SerializeField] private string message;
    [SerializeField] private LayerMask ObjMask;

    [SerializeField] private TMP_Text textObj,textNorma;
    private GameObject main;




    // Start is called before the first frame update
    void Start()
    {
        this.place = GetComponent<Transform>();
        this.main = GameObject.Find("GameMainScript");
        obj1 = false;
    }



    // Update is called once per frame
    void Update()
    {

    }



    void FixedUpdate()
    {
        
        Collider[] collided_ele = Physics.OverlapSphere(this.place.position, 0.3f, TypeMask);
        Collider[] collided_obj = Physics.OverlapSphere(this.place.position, 0.1f, ObjMask);
        if (collided_ele.Length > 0)
        {
            textObj.color = Color.red;
            //this.main.SendMessage("Rule1", true);
        }
        else
        {
            if (collided_obj.Length > 0 && !obj1)
            {
                textObj.color = Color.white;
                textObj.text = "Objetivo: Colaca os candieiros de parede no local correto 0/4.";
                textNorma.text = "Norma: Os candieiros devem respeitar as normas de ergonomia(1,7 de altura).";
                this.main.SendMessage("Obj1completed", true);
                obj1 = true;
            }
        }
    }
}
