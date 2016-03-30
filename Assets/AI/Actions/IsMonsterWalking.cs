using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINDecision]
public class IsMonsterWalking : RAINDecision
{
	private AIBehaviour m_aiBehaviour;

	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		m_aiBehaviour = new AIBehaviour (ai, _children,"Walking");

		//Is monster in certain animation
		return m_aiBehaviour.CheckAndAccess ();
	}
}