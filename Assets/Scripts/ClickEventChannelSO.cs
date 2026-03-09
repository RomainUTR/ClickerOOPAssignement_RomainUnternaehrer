using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ClickEventChannelSO", menuName = "Events/ClickEventChannelSO")]
public class ClickEventChannelSO : ScriptableObject
{
    public Action OnEventRaised;

    public void RaiseEvent()
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke();
        }
    }
}
