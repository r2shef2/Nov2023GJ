using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverTriggerCollider : MonoBehaviour
{
    public bool playerIsInBounds = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
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
        }
    }


    public LeverTriggerCollider triggerCollider;

    [Serializable]
    public class triggerCollidedEvent : UnityEvent { }

    // Event delegates triggered on click.
    [SerializeField]
    private triggerCollidedEvent m_onTriggerCollided = new triggerCollidedEvent();


    public void TriggerCollided()
    {
        m_onTriggerCollided.Invoke();
    }
}
