using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject light;
    private bool on;
    // Start is called before the first frame update
    void Start()
    {
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider hit)
    {
        if (!on)
        {
            light.SetActive(true);
            on = true;
        }else if (on)
        {
            light.SetActive(false);
            on = false;
        }
    }
}
