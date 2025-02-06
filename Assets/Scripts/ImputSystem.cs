using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ImputSystem : MonoBehaviour
{
    //Imput System
    public PlayerInput _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        //Implementar ImputSystem
        _playerInput=GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
