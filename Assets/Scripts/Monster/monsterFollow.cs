using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class monstersFollow : MonoBehaviour
{
    public GameObject target;
    public Transform[] waypoint;
    public FSMSystem fsm;

    public void SetTransition(Transition t) { fsm.PerformTransition(t); }

    public void Start()
    {
        MakeFSM();
    }

    public void FixedUpdate()
    {
        fsm.CurrentState.Reason(target, gameObject);
        fsm.CurrentState.Act(target, gameObject);
    }

    // The NPC has two states: FollowPath and ChasePlayer
    // If it's on the first state and SawPlayer transition is fired, it changes to ChasePlayer
    // If it's on ChasePlayerState and LostPlayer transition is fired, it returns to FollowPath
    private void MakeFSM()
    {
        ChasePlayerState chase = new ChasePlayerState();
        chase.AddTransition(Transition.LostPlayer, StateID.FollowingPath);

        Vector3[] path = new Vector3[waypoint[0].childCount];
        for (int i = 0; i < waypoint[0].childCount; i++)
        {
            path[i] = waypoint[0].GetChild(i).position;
        }
        FollowPathState follow = new FollowPathState(path);
        follow.AddTransition(Transition.SawPlayer, StateID.ChasingPlayer);

        fsm = new FSMSystem();
        fsm.AddState(follow);
        fsm.AddState(chase);
    }
}

public class FollowPathState : FSMState
{
    private int currentWayPoint;
    private Vector3[] waypoints;

    public FollowPathState(Vector3[] wp)
    {
        waypoints = wp;
        currentWayPoint = 0;
        stateID = StateID.FollowingPath;
    }



    public override void Reason(GameObject player, GameObject npc)
    {

    }


    public override void Act(GameObject player, GameObject npc)
    {

        Vector3 vel = npc.GetComponent<Rigidbody>().velocity;
        Vector3 moveDir = waypoints[currentWayPoint] - npc.transform.position;
        if (moveDir.magnitude < 1)
        {
            currentWayPoint++;
            if (currentWayPoint >= waypoints.Length)
            {
                currentWayPoint = 0;
            }
        }
        else
        {

            npc.GetComponent<NavMeshAgent>().destination = waypoints[currentWayPoint];
        }

    }

} // FollowPathState

public class ChasePlayerState : FSMState
{
    public ChasePlayerState()
    {
        stateID = StateID.ChasingPlayer;
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        // If the player has gone 30 meters away from the NPC, fire LostPlayer transition
        if (Vector3.Distance(npc.transform.position, player.transform.position) >= 30)
        {
            npc.GetComponent<monstersFollow>().SetTransition(Transition.LostPlayer);
        }


    }

    public override void Act(GameObject player, GameObject npc)
    {
        npc.GetComponent<NavMeshAgent>().destination = player.transform.position;
    }

} // ChasePlayerState


