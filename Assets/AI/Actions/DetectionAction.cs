using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class DetectionAction : RAINAction
{	
	private int minionCount = 2;
	GameObject minions;
	private bool isMinionsInstantiated;
	RAIN.Core.AI ai;

    public override void Start(RAIN.Core.AI ai)
    {
		minions = ai.WorkingMemory.GetItem("InstantiateMinions") as GameObject;
        base.Start(ai);


    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		InstantiateHandler(ai);
		Debug.Log(isMinionsInstantiated);
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }

	void InstantiateHandler(RAIN.Core.AI ai)
	{
		Vector3 miniBossPos = ai.Body.transform.position;
		miniBossPos.x += 2;
		miniBossPos.z +=2;

		if (minions !=null && isMinionsInstantiated == false)
		{
			for (int i = 0; i < minionCount; i++)
			{
				//GameObject minions = ai.WorkingMemory.GetItem("InstantiateMinions") as GameObject;
				GameObject instantiatedMinions = GameObject.Instantiate(minions,new Vector3(miniBossPos.x +i , miniBossPos.y ,miniBossPos.z), Quaternion.identity) as GameObject;
				//UnityEngine.MonoBehaviour.Instantiate (minions,ai.Body.transform.position,Quaternion.identity);

			}

			isMinionsInstantiated = true;
			ai.WorkingMemory.SetItem<bool>("isMinionsInstantiated" , isMinionsInstantiated);

		}


	}


}