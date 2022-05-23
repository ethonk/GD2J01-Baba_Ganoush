using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStateManager : MonoBehaviour
{
    // == AGENT STATES ==
    private AgentBaseState _currentState;                                // What state the current agent is in.
    //
    // State References
    private readonly AgentJailedState _jailedState = new AgentJailedState();      // State for when the agent is in the jail.


    // == UNITY FUNCTIONS ==
    private void Start()
    {
        // Set the starting state of the agent.
        SetCurrentState(_jailedState);
    }

    private void Update()
    {
        // Run update on the current state.
        _currentState.UpdateState(this);
    }

    // == OBJECT FUNCTIONS ==
    //
    // SetCurrentState - Sets the state of the agent to a given state.
    void SetCurrentState(AgentBaseState state)
    {
        _currentState = state;          // set the current state
        _currentState.EnterState(this);  // enter that state.
    }
}
