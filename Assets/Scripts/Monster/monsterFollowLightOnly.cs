using UnityEngine;
using System.Collections;

public class monsterFollowLightOnly : monstersFollow
{

    void OnTriggerStay(Collider col)
    {

        if ((col.tag == "Light") && (base.fsm.CurrentStateID == StateID.FollowingPath))
        {
            base.target = col.gameObject;
            RaycastHit hit;
            if (Physics.Linecast(transform.position, col.transform.position, out hit))
            {
                if (hit.collider.tag == "Light")
                {
                    GetComponent<monstersFollow>().SetTransition(Transition.SawPlayer);
                }
            }
        }
    }
}
