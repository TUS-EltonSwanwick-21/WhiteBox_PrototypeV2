using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    public GameObject targetDoor;
    public bool isLocked = true;
    public bool playerAtDoor;
    public Vector3 openOffset;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = targetDoor.transform.position;
    }

    void Update()
    {
        if (playerAtDoor && !isLocked && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player Opened Door");
           OpenDoor();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered key trigger zone.");
            playerAtDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited key trigger zone.");
            playerAtDoor = false;
            targetDoor.transform.position = initialPosition;
        }
    }

    public void UnlockDoor()
    {
        Debug.Log("The door is unlocked");
        isLocked = false;
    }


    public void OpenDoor()
    {
        targetDoor.transform.position += openOffset;
    }
}








