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
	public GameObject m_playerObj;
	public Player m_player;

	private Inventory m_inventory;
	private Vector2 m_offset;
	private ToolTip m_toolTip;

	// Use this for initialization
	void Start ()
	{
		m_inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		//m_amount = 1;
		m_toolTip = m_inventory.GetComponent<ToolTip> ();
		m_playerObj = GameObject.Find ("Berserker");
		m_player = m_playerObj.GetComponent<Player> ();
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (m_item != null) 
		{
			m_offset = eventData.position - new Vector2 (this.transform.position.x, this.transform.position.y);
			this.transform.SetParent (this.transform.parent.parent);
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
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
		this.transform.SetParent (m_inventory.m_slots [m_slotNumber].transform);
		this.transform.position = m_inventory.m_slots [m_slotNumber].transform.position;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	public void OnPointerDown (PointerEventData eventData)
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
					//remove
					Debug.Log (m_playerObj.GetComponent<Player> ().m_health);
					m_playerObj.GetComponent<Player> ().RestoreHealth (m_item.m_health);
					//remove
					Debug.Log (m_playerObj.GetComponent<Player> ().m_health);
					m_inventory.RemoveUniqueItem (m_slotNumber);
				}

				//equips/uneqips item
				else 
				{
					//equip item
					if (m_item.m_equipped == false) 
					{
						//equip sword
						if ((m_item.m_ID == 0 || m_item.m_ID == 1) && (m_player.m_weaponOn == 0)) 
						{
							Player.m_weaponEquipped = 1;
							if (m_item.m_ID == 0) 
							{
								m_playerObj.GetComponent<Player> ().m_attack = m_playerObj.GetComponent<Player> ().m_attack + m_item.m_attack;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.green;
								m_item.m_equipped = true;
								m_player.m_weaponOn = 1;
								m_player.m_equipables [0].SetActive (true);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "E";
							}

							else
							{
								m_playerObj.GetComponent<Player> ().m_attack = m_playerObj.GetComponent<Player> ().m_attack + m_item.m_attack;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.green;
								m_item.m_equipped = true;
								m_player.m_weaponOn = 1;
								m_player.m_equipables [1].SetActive (true);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "E";
							}
						} 

						//equip pauldron
						else if ((m_item.m_ID == 2 || m_item.m_ID == 5) && (m_player.m_pauldronOn == 0))
						{
							if (m_item.m_ID == 2)
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence + m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.green;
								m_item.m_equipped = true;
								m_player.m_pauldronOn = 1;
								m_player.m_equipables [2].GetComponent<Renderer> ().material.color = new Color(.8f,.6f,.2f);
								m_player.m_equipables [2].SetActive (true);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "E";
							}

							else
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence + m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.green;
								m_item.m_equipped = true;
								m_player.m_pauldronOn = 1;
								m_player.m_equipables [2].SetActive (true);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "E";
							}
						}

						//equip armguard
						else if ((m_item.m_ID == 3 || m_item.m_ID == 6) && (m_player.m_armGuardOn == 0))
						{
							if (m_item.m_ID == 3) 
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence + m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.green;
								m_item.m_equipped = true;
								m_player.m_armGuardOn = 1;
								m_player.m_equipables [3].GetComponent<Renderer> ().material.color = new Color(.8f,.6f,.2f);
								m_player.m_equipables [3].SetActive (true);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "E";
							}

							else
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence + m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.green;
								m_item.m_equipped = true;
								m_player.m_armGuardOn = 1;
								m_player.m_equipables [3].SetActive (true);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "E";
							}
						}

						//equip kneeguard
						else if ((m_item.m_ID == 4 || m_item.m_ID == 7) && (m_player.m_kneeGuardOn == 0))
						{
							if (m_item.m_ID == 4)
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence + m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.green;
								m_item.m_equipped = true;
								m_player.m_kneeGuardOn = 1;
								m_player.m_equipables [4].GetComponent<Renderer> ().material.color = new Color(.8f,.6f,.2f);
								m_player.m_equipables [4].SetActive (true);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "E";
							}

							else
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence + m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.green;
								m_item.m_equipped = true;
								m_player.m_kneeGuardOn = 1;
								m_player.m_equipables [4].SetActive (true);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "E";
							}
						}
					}
						
					//unequip item
					else 
					{
						//unequip sword
						if ((m_item.m_ID == 0 || m_item.m_ID == 1) && (m_player.m_weaponOn == 1)) 
						{
							if (m_item.m_ID == 0) 
							{
								m_playerObj.GetComponent<Player> ().m_attack = m_playerObj.GetComponent<Player> ().m_attack - m_item.m_attack;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
								m_item.m_equipped = false;
								Player.m_weaponEquipped = 0;
								m_player.m_weaponOn = 0;
								m_player.m_equipables [0].SetActive (false);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "";
							}

							else
							{
								m_playerObj.GetComponent<Player> ().m_attack = m_playerObj.GetComponent<Player> ().m_attack - m_item.m_attack;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
								m_item.m_equipped = false;
								Player.m_weaponEquipped = 0;
								m_player.m_weaponOn = 0;
								m_player.m_equipables [1].SetActive (false);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "";
							}
						}

						//unequip pauldron
						else if ((m_item.m_ID == 2 || m_item.m_ID == 5) && (m_player.m_pauldronOn == 1))
						{
							if (m_item.m_ID == 2)
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence - m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
								m_item.m_equipped = false;
								m_player.m_pauldronOn = 0;
								m_player.m_equipables [2].GetComponent<Renderer> ().material.color = Color.white;
								m_player.m_equipables [2].SetActive (false);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "";
							}

							else
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence - m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
								m_item.m_equipped = false;
								m_player.m_pauldronOn = 0;
								m_player.m_equipables [2].SetActive (false);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "";
							}
						}

						//unequip armguard
						else if ((m_item.m_ID == 3 || m_item.m_ID == 6) && (m_player.m_armGuardOn == 1))
						{
							if (m_item.m_ID == 3)
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence - m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
								m_item.m_equipped = false;
								m_player.m_armGuardOn = 0;
								m_player.m_equipables [3].GetComponent<Renderer> ().material.color = Color.white;
								m_player.m_equipables [3].SetActive (false);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "";
							}

							else
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence - m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
								m_item.m_equipped = false;
								m_player.m_armGuardOn = 0;
								m_player.m_equipables [3].SetActive (false);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "";
							}
						}

						//unequip kneeguard
						else if ((m_item.m_ID == 4 || m_item.m_ID == 7) && (m_player.m_kneeGuardOn == 1))
						{
							if (m_item.m_ID == 4)
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence - m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
								m_item.m_equipped = false;
								m_player.m_kneeGuardOn = 0;
								m_player.m_equipables [4].GetComponent<Renderer> ().material.color = Color.white;
								m_player.m_equipables [4].SetActive (false);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "";
							}

							else
							{
								m_playerObj.GetComponent<Player> ().m_defence = m_playerObj.GetComponent<Player> ().m_defence - m_item.m_defence;
								this.gameObject.transform.parent.GetComponent<Image> ().color = Color.white;
								m_item.m_equipped = false;
								m_player.m_kneeGuardOn = 0;
								m_player.m_equipables [4].SetActive (false);
								this.gameObject.transform.FindChild ("Equipped").GetComponent<Text> ().text = "";
							}
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