using UnityEngine;
using System.Collections;
using BehaviourTree;

public class MoveToTask : ITaskDefinition 
{
	Transform m_target;
	float speed = 5.0f;

	public MoveToTask(Transform a_target)
	{
		m_target = a_target;
	}
	public void OnEnter()
	{
		
	}

	public void OnExit()
	{
	}

	public NodeState OnExecute(BehaviourTrees bTree)
	{
		Blackboard m_blackBoard = bTree.GetBlackboard();
		GameObject agent = (GameObject)m_blackBoard.data ["agent"];

		Vector3 BminusA = m_target.position - agent.transform.position;
		float distance = BminusA.magnitude;

		//if the agent is not close to the target position then move
		if (distance > 0.01f) 
		{
			agent.transform.position += BminusA.normalized * speed * Time.deltaTime;
			return NodeState.Running;
		}

		return NodeState.Success;
			
	}
}
