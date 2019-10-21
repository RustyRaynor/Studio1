using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3[] patrolPosition = new Vector3[3];
    public Vector3 chargingPosition;
    State state;
    public int battery = 0;

    private void Start()
    {
        patrolPosition[0] = transform.position; 
        state = new PatrolState();
    }

    private void Update()
    {
        state.UpdateState(this);
    }

    public void setState(State _state)
    {
        state = _state;
    }
}
