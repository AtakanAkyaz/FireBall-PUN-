using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MouseMove : MonoBehaviourPunCallbacks
{

    public float MouseSensitivity = 50F;
    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
      
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
        
    }

}
