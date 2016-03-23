using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class ItemData : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler , IPointerEnterHandler, IPointerExitHandler
{
	public Item m_item;
	public int m_amount;
	public int m_slotNumber;
	public GameObject m_player;

	private Inventory m_inventory;
	private Vector2 m_offset;
	private ToolTip m_toolTip;

	// Use this for initialization
	void Start () 
	{
		m_inventory = GameObject.Find ("Inventory").GetComponent<Inventory>();
		//m_amount = 1;
		m_toolTip = m_inventory.GetComponent<ToolTip>();
		m_player = GameObject.Find ("Berserker");
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (m_item != null) 
		{
			m_offset = eventData.position - new Vector2 (this.transform.position.x, this.transform.position.y);
			this.transform.SetParent (this.transform.parent.parent);
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

	public void OnDrag (PointerEventData eventData)
	{
		if (m_item != null) 
		{
			this.transform.position = eventData.position - m_offset;
		}
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		this.transform.SetParent (m_inventory.m_slots[m_slotNumber].transform);
		this.transform.position = m_inventory.m_slots[m_slotNumber].transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
		
	public void OnPointerDown(PointerEventData eventData)
	{
		if (m_item != null)
		{
			// If the item should be deleted
			if (m_inventory.deleteItem == true) 
			{
				this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;

				m_inventory.RemoveUniqueItem (m_slotNumber);
			} 

			if (eventData.pointerId == -2) 
			{
				//consume item
				if (m_item.m_consumable == true) 
				{
					Debug.Log (m_player.GetComponent<Player> ().m_health);
					m_player.GetComponent<Player> ().RestoreHealth (10);
					Debug.Log (m_player.GetComponent<Player> ().m_health);
					m_inventory.RemoveUniqueItem (m_slotNumber);
				}

				//closes tooltip if item consumed was the last one
//				if (m_inventory.RemoveItem (m_item.m_ID) == 0) 
//				{
//					m_toolTip.Deactivate ();
//				} 

				//equips/uneqips item
				else 
				{
					if (m_item.m_equipped == false)
					{
						if(m_item.m_ID == 0)
						{
							m_player.GetComponent<Player> ().m_attack = m_player.GetComponent<Player> ().m_attack + m_item.m_attack;
							this.gameObject.transform.parent.GetComponent<Image> ().color = Color.green;
							m_item.m_equipped = true;
							this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "E";
						}

						if (m_item.m_ID == 1)
						{
							m_player.GetComponent<Player> ().m_defence = m_player.GetComponent<Player> ().m_defence + m_item.m_defence;
							this.gameObject.transform.parent.GetComponent<Image> ().color = Color.green;
							m_item.m_equipped = true;
							this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "E";
						}
					}

					else
					{
						if(m_item.m_ID == 0)
						{
							m_player.GetComponent<Player> ().m_attack = m_player.GetComponent<Player> ().m_attack - m_item.m_attack;
							this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
							m_item.m_equipped = false;
							this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "";
						}

						if (m_item.m_ID == 1)
						{
							m_player.GetComponent<Player> ().m_defence = m_player.GetComponent<Player> ().m_defence - m_item.m_defence;
							this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
							m_item.m_equipped = false;
							this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "";
						}
					}
				}	
			}

			else 
			{
				m_offset = eventData.position - new Vector2 (this.transform.position.x, this.transform.position.y);
				this.transform.position = eventData.position - m_offset;
			}
		}
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		if (m_item != null)
		{
			if (m_inventory.deleteItem == true) 
			{
				this.gameObject.transform.parent.GetComponent<Image> ().color = Color.red;
				//this.gameObject.transform.GetComponentInChildren<Text> ().text = (Int32.Parse (this.gameObject.transform.GetComponentInChildren<Text> ().text) - 1).ToString();
			}
			else 
			{
				m_toolTip.Activate (m_item);
			}
		}
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		m_toolTip.Deactivate ();
		this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
	}
}
//remove stack item when deleting
//delete function removes from stack amount when hovering mouse over item