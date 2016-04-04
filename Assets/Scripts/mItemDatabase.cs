using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class mItemDatabase : MonoBehaviour 
{
	private List<Item> m_database = new List<Item>();
	private JsonData m_itemData;

	// Use this for initialization
	void Start () 
	{
		var m_resourceFile = Resources.Load ("ItemInfo") as TextAsset;
		m_itemData = JsonMapper.ToObject (m_resourceFile.text);

		if (m_itemData == null) 
		{
			//m_itemData = JsonMapper.ToObject (File.ReadAllText(Application.dataPath + "/Assets/StreamingAssets/Item.json"));
		}
		ConstructItemDatabase();
	}

	public Item FetchItemByID(int a_id)
	{
		for (int i = 0; i < m_database.Count; i++)
		{
			if (m_database [i].m_ID == a_id)
				return m_database [i];
		}
		return null;
	}

	void ConstructItemDatabase()
	{
		for (int i = 0; i < m_itemData.Count; i++) 
		{
			m_database.Add (new Item ((int)m_itemData [i] ["id"], 
									(string)m_itemData [i] ["title"], 
									(int)m_itemData [i] ["value"],
									(int)m_itemData[i] ["stats"]["attack"], 
									(int)m_itemData[i] ["stats"]["defence"], 
									(int)m_itemData[i] ["stats"]["health"],
									m_itemData [i] ["description"].ToString(), 
									(bool)m_itemData[i] ["stackable"],
									(int)m_itemData[i] ["maxStack"],
									(int)m_itemData[i] ["rarity"],
									(bool)m_itemData[i] ["consumable"],
									(bool)m_itemData[i] ["equipped"],
									(string)m_itemData[i] ["slug"]
			));
		}
	}
}

public class Item
{
	public int m_ID {get; set;}
	public string m_title {get; set;}
	public int m_value {get; set;}
	public int m_attack {get; set;}
	public int m_defence {get; set;}
	public int m_health {get; set;}
	public string m_description {get; set;}
	public bool m_stackable {get; set;}
	public int m_maxStack {get; set;}
	public int m_rarity {get; set;}
	public bool m_consumable {get; set;}
	public bool m_equipped {get; set;}
	public string m_slug {get; set;}
	public Sprite m_sprite {get; set;}

	public Item(int a_id, string a_title, int a_value, int a_attack, int a_defence, int a_health, 
		string a_description, bool a_stackable, int a_maxStack, int a_rarity, bool a_consumable, bool a_equipped, string a_slug)
	{
		this.m_ID = a_id;
		this.m_title = a_title;
		this.m_value = a_value;
		this.m_attack = a_attack;
		this.m_defence = a_defence;
		this.m_health = a_health;
		this.m_description = a_description;
		this.m_stackable = a_stackable;
		this.m_maxStack = a_maxStack;
		this.m_rarity = a_rarity;
		this.m_consumable = a_consumable;
		this.m_equipped = a_equipped;
		this.m_slug = a_slug;
		this.m_sprite = Resources.Load<Sprite> ("Sprites/" + a_slug);
	}

	public Item()
	{
		this.m_ID = -1;
	}
}