using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateStuff
{
    
// using 'T' is convention for creating a generic type. After T is U, V - if we so choose
// T is simply a placeholder, and will end up being an actual type when the method is called
public class StateMachine<T> 
{
    public State<T> currentState {get; private set;}
    public T Owner;

    public StateMachine(T _owner)
    {
        Owner = _owner;
        currentState = null;
    }

    public void ChangeState(State<T> _newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(Owner);
            currentState = _newState;
            currentState.EnterState(Owner);
        }
    }

    public void Update()
    {
         if (currentState != null)
        {
            currentState.UpdateState(Owner);
        }
    }
}
    public abstract class State<T> // abstract because this is what all our State files are going to be based on
    {
    public abstract void EnterState(T _owner);
    public abstract void ExitState(T _owner);
    public abstract void UpdateState(T _owner);
    }



}
