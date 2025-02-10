using System;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialogueUI;
    public Button noButton;
    public StaminaController staminaController;
    
        void Start()
    {
        dialogueUI.SetActive(false);
        noButton.onClick.AddListener(delegate { dialogueUI.SetActive(false); });
    }

    public void OnYesClicked()
    {
        dialogueUI.SetActive(false);
        staminaController.IncreaseStamina(100F);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueUI.SetActive(false);
        }
    }
}