using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverTriggerCollider : MonoBehaviour
{
    public bool playerIsInBounds = false;

    [HideInInspector]
    public PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        playerMovement = other.gameObject.GetComponent<PlayerMovement>() ?? null;
        if (playerMovement != null)
        {
            playerIsInBounds = true;
            TriggerCollided();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            playerIsInBounds = false;
            TriggerExited();
            playerMovement = null;
        }
    }

    [Serializable]
    public class triggerCollidedEvent : UnityEvent { }
    [SerializeField]
    public class triggerExitedEvent : UnityEvent { }

    // Event delegates triggered on click.
    [SerializeField]
    private triggerCollidedEvent m_onTriggerCollided = new triggerCollidedEvent();
    [SerializeField]
    private triggerCollidedEvent m_onTriggerExited = new triggerCollidedEvent();


    public void TriggerCollided()
    {
        m_onTriggerCollided.Invoke();
    }

    public void TriggerExited()
    {
        m_onTriggerExited.Invoke();
    }
}
