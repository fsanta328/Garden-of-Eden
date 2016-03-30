using UnityEngine;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

public class AIBehaviour
{
	protected int m_lastRunning = 0;
	private AI m_ai;
	private List<RAIN.BehaviorTrees.BTNode> m_children;
	private string m_animationClipTag;

	//Constructor
	public AIBehaviour(AI a_ai, List<RAIN.BehaviorTrees.BTNode> a_children, string a_animationClipTag)
	{
		m_ai = a_ai;
		m_children = a_children;
		m_animationClipTag = a_animationClipTag;
	}

	//Method to check, is AI is in certain state of animation
	bool Is_inState ()
	{
		//Accessing the body of the character through Rain A.I
		Animator a_aiAnimation = m_ai.Body.GetComponent<Animator> ();

		//Is character in certain state of animation
		return a_aiAnimation.GetCurrentAnimatorStateInfo (0).IsTag (m_animationClipTag).Equals (true);
	}

	public RAINAction.ActionResult CheckAndAccess()
	{
		//is monster in certain animation clip
		if (Is_inState()) 
		{
			RAINAction.ActionResult tResult = RAINAction.ActionResult.SUCCESS;

			//Access each child node under this Decision Node
			for (; m_lastRunning < m_children.Count; m_lastRunning++)
			{
				tResult = m_children[m_lastRunning].Run(m_ai);
				if (tResult != RAINAction.ActionResult.SUCCESS)
					break;
			}
			return RAINAction.ActionResult.SUCCESS;
		}
		return RAINAction.ActionResult.RUNNING;
	}
}