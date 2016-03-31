using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class GetTarget : RAINAction
{	
	private Vector3 m_distance;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		ai.WorkingMemory.SetItem ("Target",GameObject.FindGameObjectWithTag("Player").transform.position);
		m_distance = (Vector3)ai.WorkingMemory.GetItem ("Target") - ai.Body.transform.position;
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		if (ai.Body.transform.rotation != Quaternion.LookRotation (m_distance)) 
		{
			ai.Body.transform.rotation = Quaternion.LookRotation (m_distance);

			return ActionResult.RUNNING;
		}

		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}