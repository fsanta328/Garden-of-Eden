using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	GameObject m_inventoryPanel;
	GameObject m_slotsPanel;
	mItemDatabase m_database;
	public bool deleteItem;
	public GameObject m_inventorySlot;
	public GameObject m_inventoryItem;
	public GameObject m_inventoryCanvas;
	public GameObject m_toggleButton;

	int m_slotCount;
	public List<Item> m_items = new List<Item>();
	public List<GameObject> m_slots = new List<GameObject>();

	void Start () 
	{
		m_inventoryCanvas.GetComponent<CanvasGroup> ().alpha = 0;
		m_inventoryCanvas.GetComponent<CanvasGroup> ().interactable = false;

		m_database = GetComponent<mItemDatabase> ();

		m_slotCount = 20;
		m_inventoryPanel = GameObject.Find ("InventoryPanel");
		m_slotsPanel = m_inventoryPanel.transform.FindChild ("Slot Panel").gameObject;

		for (int i=0; i < m_slotCount; i++)
		{
			m_items.Add (new Item ());
			m_slots.Add (Instantiate (m_inventorySlot));
			m_slots[i].GetComponent<SlotHelper>().m_slotID = i;
			m_slots[i].transform.SetParent (m_slotsPanel.transform);
		}
		//AddItem (0);
		//AddItem (1);
		//RemoveItemAtPos(m_inventoryItem.transform.GetInstanceID(),
		m_toggleButton = GameObject.Find("Toggle");
	}

	public void AddItem(int a_id)
	{
		Item m_itemToAdd = m_database.FetchItemByID (a_id);

		if ((m_itemToAdd.m_stackable == true) && (CheckForItem (m_itemToAdd) == a_id)) 
		{
			for (int i = 0; i < m_items.Count; i++) 
			{
				ItemData data = m_slots[i].transform.GetChild(0).GetComponent<ItemData> ();
				if (m_items [i].m_ID == a_id) 
				{
					//ItemData data = m_slots [i].transform.SetParent (m_slots [i].transform);
					data.m_amount++;
					data.transform.GetChild(0).GetComponent<Text>().text = data.m_amount.ToString ();
					break;
				}
			}
		} 

		else 
		{
			for (int i = 0; i < m_items.Count; i++) 
			{
				if (m_items [i].m_ID == -1) 
				{
					m_items [i] = m_itemToAdd;
					GameObject itemObj = Instantiate (m_inventoryItem);
					itemObj.GetComponent<ItemData> ().m_item = m_itemToAdd;
					itemObj.GetComponent<ItemData> ().m_slotNumber = i;
					itemObj.transform.SetParent (m_slots [i].transform);
					itemObj.GetComponent<RectTransform> ().anchoredPosition = Vector3.zero;
					itemObj.GetComponent<Image> ().sprite = m_itemToAdd.m_sprite;
					itemObj.name = m_itemToAdd.m_title;
					ItemData data = m_slots[i].transform.GetChild(0).GetComponent<ItemData> ();
					data.m_amount++;
					break;
				}
			}
		}
	}

	//function to remove item from inventory by id
	private int RemoveItemAtPos (int pos)
	{
		ItemData data = m_slots[pos].transform.GetChild(0).GetComponent<ItemData> ();

		//check if item exists
		if (pos != -1) 
		{
			//check if it is a stackable item
			if (m_items [pos].m_stackable) 
			{
				//check if item is remaining
				if (data.m_amount == 0) 
				{
					m_items [pos] = new Item ();
					Transform t = m_slots [pos].transform.GetChild (0);
					Destroy (t.gameObject);
					return 0;
				}

				//change text component to display properly
				else 
				{
					if (data.m_amount == 1) 
					{
						data.transform.GetComponentInChildren<Text> ().text = "";
						data.m_amount = 0;
					}

					else 
					{
						data.transform.GetComponentInChildren<Text> ().text = (data.m_amount-1).ToString ();
						data.m_amount = data.m_amount - 1;
						return data.m_amount;
					}
				}
			}

			else
			{
				m_items[pos] = new Item();
				Transform t = m_slots[pos].transform.GetChild(0);
				Destroy(t.gameObject);
				return 0;
			}
		}
		return -1;
	}

	public int RemoveItem(int a_id)
	{
		Item itemToRemove = m_database.FetchItemByID(a_id);
		int pos = CheckForItem(itemToRemove);
		return (RemoveItemAtPos(pos));
	}

	public int RemoveUniqueItem(int itemPosition)
	{
		//Item itemToRemove = m_database.FetchItemByID(itemId);

		//int pos = CheckForUniqueItem(current.);
		return (RemoveItemAtPos(itemPosition));
	}

	int CheckForItem(Item a_item)
	{
		for(int i = 0; i < m_items.Count; i++)
		{
			if (m_items[i].m_ID == a_item.m_ID)
				return i;
		}
		return -1;

//		for (int i = 0; i < m_items.Count; i++) 
//		{
//			if (m_items [i].m_ID == a_item.m_ID)
//				return true;
//		}
//		return false;
	}

	int CheckForUniqueItem(int a_id)
	{
		GameObject invSlots = GameObject.Find("Slot Panel");
		foreach (Transform child in invSlots.transform) 
		{
			try
			{
				if (child.transform.GetChild(0).GetInstanceID() == a_id)
				{
					return child.GetComponent<Item>().m_ID;
					//return 3;
				}
			}
			catch
			{}
		}
		return -1;
	}

	public void ToggleDeleteButton()
	{
		if (m_toggleButton.GetComponent<Toggle> ().isOn != true) 
		{
			deleteItem = false;
		} 

		else 
		{
			deleteItem = true;
		}
	}
}
//change find object to work with tags if possible