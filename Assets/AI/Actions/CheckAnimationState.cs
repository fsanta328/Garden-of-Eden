using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINDecision]
public class CheckAnimationState : RAINDecision
{
	private int _lastRunning = 0, m_animationState;

    public override void Start(RAIN.Core.AI ai)
    {
		m_animationState = (int)ai.WorkingMemory.GetItem ("AnimationState");
        base.Start(ai);

        _lastRunning = 0;
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        ActionResult tResult = ActionResult.SUCCESS;

		if(ai.Body.GetComponent<Animator>().GetFloat("Anim") == m_animationState)
		{
			for (; _lastRunning < _children.Count; _lastRunning++)
			{
				tResult = _children[_lastRunning].Run(ai);
				if (tResult != ActionResult.SUCCESS)
					break;
			}

			return tResult;
		}

		return ActionResult.FAILURE;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}