using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public State prevState;
    public virtual void UpdateState(Main context)
    {
        
    }
}
