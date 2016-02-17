using UnityEngine;
using System.Collections;
using BehaviourTree;

public class WaitTask : ITaskDefinition 
{
	float m_time = 0.0f;
	float m_duration = 0.0f;

	public WaitTask(float a_duration)
	{
		m_duration = a_duration;
	}
	public void OnEnter()
	{
		m_time = 0.0f;
	}

	public void OnExit()
	{
	}

	public NodeState OnExecute(BehaviourTrees bTree)
	{
		m_time += Time.deltaTime;
		if (m_time >= m_duration)
		{
			return NodeState.Success;
		}
		return NodeState.Running;
	}
}
