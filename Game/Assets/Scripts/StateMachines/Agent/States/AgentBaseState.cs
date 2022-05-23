using UnityEngine;

// Each state of the agent derives from the base state.
public abstract class AgentBaseState
{
    public abstract void EnterState(AgentStateManager _thisAgent);
    
    public abstract void UpdateState(AgentStateManager _thisAgent);

    public abstract void OnCollisionEnter(AgentStateManager _thisAgent);
}
