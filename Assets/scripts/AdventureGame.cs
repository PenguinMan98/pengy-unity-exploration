using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;
    bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(startingState);
        Debug.Log(startingState.GetStateStory());
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();

        // listen for state in a for loop
        for (var i = 0; i < nextStates.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                moveState(nextStates[i]);
            }
        }

    }
    private void moveState(State newState)
    {
        var feedback = "";
        Debug.Log("current state");
        Debug.Log(state.GetStateId());
        Debug.Log("new state");
        Debug.Log(newState.GetStateId());
        Debug.Log(hasKey ? "has Key" : "no key");

        if (newState.GetStateId() == "GetKey")
        {
            hasKey = true;
        }

        if (newState.GetStateId() == "OpenDoor" && !hasKey)
        {
            feedback = "You cannot open it. It's locked.";
        } else
        {
            state = newState;
        }

        textComponent.text = feedback + "\n\n" + state.GetStateStory();
    }
}