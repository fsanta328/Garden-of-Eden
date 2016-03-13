using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class CollisionTest : RAINAction
{
//	private bool m_gotHurt;
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
//		m_gotHurt.Equals(ai.WorkingMemory.GetItem ("GotHurt"));
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		if(ai.Body.GetComponent<CollisionDetection>().GetGotHurt(true))
		{
			Debug.Log ("Got Hit");

			ai.Body.GetComponent<CollisionDetection>().SetGotHurt(false);

			return ActionResult.SUCCESS;
		}

		return ActionResult.RUNNING;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}