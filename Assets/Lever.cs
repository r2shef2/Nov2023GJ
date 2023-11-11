using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Lever : MonoBehaviour
{
    public LeverTriggerCollider triggerCollider;

    [Serializable]
    public class leverChangedEvent : UnityEvent { }

    // Event delegates triggered on click.
    [FormerlySerializedAs("onClick")]
    [SerializeField]
    private leverChangedEvent m_OnLeverChanged = new leverChangedEvent();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(triggerCollider.playerIsInBounds)
            {
                LeverPulled();
            }
        }
    }


    public void LeverPulled()
    {
        m_OnLeverChanged.Invoke();
    }
}
