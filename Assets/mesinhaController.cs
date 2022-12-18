using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mesinhaController : MonoBehaviour
{
    private bool obj3;
    private Transform place;
    [SerializeField] private LayerMask CamaMask;
    [SerializeField] private string message;
    [SerializeField] private TMP_Text textObj, textNorma;
    private GameObject main;




    // Start is called before the first frame update
    void Start()
    {
        this.place = GetComponent<Transform>();
        this.main = GameObject.Find("GameMainScript");
        obj3 = false;

    }



    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        Collider[] collided_cama1 = Physics.OverlapSphere(this.place.position, 0.3f, CamaMask);
        Collider[] collided_cama2 = Physics.OverlapSphere(this.place.position, 1f, CamaMask);
        if (collided_cama1.Length > 0)
        {
            textObj.color = Color.red;
        }
        else
        {
            if (collided_cama2.Length > 0 && obj3 == false)
            {
                obj3 = true;
                this.main.SendMessage("Obj3completed", true);
            }
        }
    }
}
