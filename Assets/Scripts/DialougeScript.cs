using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class DialougeScript : MonoBehaviour
{
    public Canvas messageCanvas;
    public TextMeshProUGUI messageText;
    public Image background; // Add this field for the background image
    [TextArea(3,10)]
    public string defaultMessage = "Hello, this is a message from the computer. Press 'E' to close.";
    public string promptMessage = "Press 'E' to interact.";

    private bool isPlayerInsideTrigger = false;

    void Start()
    {
        if (messageText == null)
        {
            messageText = messageCanvas.GetComponentInChildren<TextMeshProUGUI>();
        }

       

        if (messageText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the Canvas or assigned to the script.");
        }

        // Set a default message
        messageText.text = defaultMessage;

        // Deactivate the canvas initially
        messageCanvas.gameObject.SetActive(false);

        // Log to confirm Start is called
        Debug.Log("Start method called.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInsideTrigger = true;
          
            Debug.Log("Player entered trigger. Showing prompt.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInsideTrigger = false;
          
            CloseMessage();
            Debug.Log("Player exited trigger. Closing prompt and message.");
        }
    }

    void Update()
    {
        if (isPlayerInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (!messageCanvas.gameObject.activeSelf)
            {
                ShowMessage();
               
                Debug.Log("Showing message. Closing prompt.");
            }
            else
            {
                CloseMessage();
                Debug.Log("Closing message.");
            }
        }
    }

 

    void ShowMessage()
    {
        messageCanvas.gameObject.SetActive(true);
        messageText.text = defaultMessage;
        background.gameObject.SetActive(true);
        Debug.Log("Showing message.");
    }

    void CloseMessage()
    {
        messageCanvas.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        Debug.Log("Closing message.");
    }
}
