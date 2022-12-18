using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lampInte : MonoBehaviour
{
    private Transform place;
    [SerializeField] private LayerMask SoloMask;
    [SerializeField] private string message;
    [SerializeField] private LayerMask PortaMask;

    [SerializeField] private TMP_Text textObj, textNorma;
    private GameObject main;

    // Start is called before the first frame update
    void Start()
    {
        this.place = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //canvasGO = new GameObject();
        //canvas = canvasGO.GetComponent<Canvas>();
        //GameObject textGO = new GameObject();
        //textGO.transform.parent = canvasGO.transform;
        //text = textGO.GetComponent<Cafeteira>();
        Collider[] collided_solo = Physics.OverlapSphere(this.place.position, 1.3f, SoloMask);
        Collider[] collided_porta = Physics.OverlapSphere(this.place.position, 0.3f, PortaMask);
        if (collided_solo.Length > 0)
        {

            textObj.color = Color.red;
            this.place.position = new Vector3(this.place.position.x, 2, this.place.position.z);
        }
        else
        {
            if (collided_porta.Length > 0)
            {
                
            }
        }
    }
    void DestroyScriptInstance()
    {
        // Removes this script instance from the game object
        Destroy(this);
    }
}
