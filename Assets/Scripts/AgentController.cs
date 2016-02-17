using UnityEngine;
using System.Collections;
using BehaviourTree;

public class AgentController : MonoBehaviour {

	public Transform m_target;
	Blackboard m_blackboard;
	BehaviourTrees bTree;

	// Use this for initialization
	void Start () 
	{
		m_blackboard = new Blackboard();
		m_blackboard.data.Add ("agent", gameObject);

		bTree = new BehaviourTrees(m_blackboard);

		BehaviourTreeNode root = bTree.GetRootNode ();
		root.Sequence()
				.Task (new ChangeColor (Color.blue))
				.Task (new WaitTask (2.0f))
				.Task (new NavigateToTask (m_target))
				.Task (new ChangeColor (Color.green))
				.Task (new WaitTask (2.0f))
			.End();
	}
	
	// Update is called once per frame
	void Update () 
	{
		bTree.Execute();
	}
}
