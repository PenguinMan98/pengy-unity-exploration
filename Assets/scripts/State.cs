using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [SerializeField] string stateId;
    [TextArea(10, 14)] [SerializeField] string storyText;
    [TextArea(3, 14)] [SerializeField] string feedbackText;
    [SerializeField] State[] nextStates;
    
    public string GetStateId() {
        return stateId;
    }

    public string GetStateStory() {
        return storyText;
    }

    public string GetFeedbackText() {
        return feedbackText;
    }

    public State[] GetNextStates() {
        return nextStates;
    }
}
