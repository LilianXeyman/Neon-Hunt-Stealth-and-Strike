using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rueda : MonoBehaviour
{
    public static Rueda instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void RodarRueda()
    {
        gameObject.transform.Rotate(0,0,10);
    }
    public void Sprint()
    {
        gameObject.transform.Rotate(0, 0, 15);
    }
}
