using UnityEngine;
using System.Collections;
using BehaviourTree;

public class ChangeColor : ITaskDefinition 
{
	Color currentColor;

	public ChangeColor(Color a_color)
	{
		currentColor = a_color;
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

		agent.GetComponent<MeshRenderer> ().material.color = currentColor;

		return NodeState.Success;
	}
}
