using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SlotHelper : MonoBehaviour , IDropHandler
{
	public int m_slotID;
	private Inventory m_inventory;

	// Use this for initialization
	void Start () 
	{
		m_inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
	}

	public void OnDrop (PointerEventData eventData)
	{
		ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();

		if (m_inventory.m_items [m_slotID].m_ID == -1) 
		{
			m_inventory.m_items [droppedItem.m_slotNumber] = new Item ();
			m_inventory.m_items [m_slotID] = droppedItem.m_item;
			droppedItem.m_slotNumber = m_slotID;
		} 

		else 
		{
			Transform itemSwap = this.transform.GetChild(0);
			itemSwap.GetComponent<ItemData>().m_slotNumber = droppedItem.m_slotNumber;
			itemSwap.transform.SetParent(m_inventory.m_slots[droppedItem.m_slotNumber].transform);
			itemSwap.transform.position = m_inventory.m_slots[droppedItem.m_slotNumber].transform.position;

			droppedItem.m_slotNumber = m_slotID;
			droppedItem.transform.SetParent (this.transform);
			droppedItem.transform.position = this.transform.transform.position;

			m_inventory.m_items[droppedItem.m_slotNumber] = itemSwap.GetComponent<ItemData>().m_item;
			m_inventory.m_items [m_slotID] = droppedItem.m_item;
			//change to use setter to set slot for swapping in inventoryclass
		}
	}
}
