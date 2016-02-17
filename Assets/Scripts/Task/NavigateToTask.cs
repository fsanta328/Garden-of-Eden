using UnityEngine;
using System.Collections;
using BehaviourTree;

public class NavigateToTask : ITaskDefinition 
{
	Transform m_target;
	//float speed = 5.0f;
	public NavMeshAgent m_NavAgent;

	public NavigateToTask(Transform a_target)
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
		m_NavAgent = agent.GetComponent<NavMeshAgent>();
		m_NavAgent.SetDestination (m_target.position);

		//if the agent is not close to the target position then move
		if (!m_NavAgent.pathPending) 
		{
			if (m_NavAgent.remainingDistance <= m_NavAgent.remainingDistance) 
			{
				return NodeState.Success;
			}
		}

		return NodeState.Running;

	}
}
