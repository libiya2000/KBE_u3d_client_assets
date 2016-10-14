using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System; 
using System.Collections.Generic;
using KBEngine;

public class UI_trade : MonoBehaviour
{
	public InputField OutTradeMoney;
	public Button locktrade;
	public Button trade;
	public Text TradeTargetName;
	public Text InTradeMoney;
	private UInt64 tradeMoney;
	public UnityEngine.GameObject  Trade_UI;

	private KBEngine.Avatar Trade_Player;
	public Dictionary<UInt32, UInt32> OutItem; //= new Dictionary<string,object>();
	// Use this for initialization
	void Start () {
		KBEngine.Event.registerOut("OnreqTradeDone", this, "OnreqTrade_Done");
		KBEngine.Event.registerOut("OnreqTradeItemList", this, "OnreqTrade_ItemList");
		KBEngine.Event.registerOut("OnreqTradeItemList2", this, "OnreqTrade_ItemList2");

		tradeMoney = 0;
		OutTradeMoney.text = tradeMoney.ToString ();
		locktrade.onClick.AddListener(delegate() {this.Is_locktrade();});
		    trade.onClick.AddListener (delegate() {	this.Is_trade ();});
		deactivate ();
	}
	public void 	Is_locktrade()
	{
		Debug.Log ("is donging lock");	
		//OutItem = new Dictionary<UInt32, UInt32> ();
		Trade_Player.trade.reqLockTradeItem (OutItem, Convert.ToUInt64(OutTradeMoney.text));
		//Trade_Player.trade.reqLockTradeItem2 ( Convert.ToUInt64(OutTradeMoney.text));

	}
	
	public void 	Is_trade()
	{
		Debug.Log ("is donging trade");	
		Trade_Player.trade.reqTrade ();
	}
	public void deactivate()
	{
		Trade_UI.SetActive(false);
	}

	public void activate()
	{
		Trade_UI.SetActive(true);
		get_playerEntry ();
	}


	public void BeginTrade(Int32 TargetID)
	{
		
		SetTitel (TargetID);
		if ((TargetID == 0)&&(Trade_Player == null))
			Debug.Log ("there is not any trade target");
		else
			Trade_Player.trade.reqBeginTrade (TargetID);
		
	}
	public void SetTitel(Int32 TargetID)
	{
		TradeTargetName.text =     TargetID.ToString();

	}

	private void get_playerEntry()
	{

		KBEngine.Entity entity = KBEngineApp.app.player();
		Trade_Player = null;
		if (entity != null && entity.className == "Avatar")
			Trade_Player = (KBEngine.Avatar)entity;
		else
			return;
	}

	public void OnreqTrade_ItemList(Dictionary<string, object> InItem,UInt64 INmoney)
	{
		//show target trade item
		InTradeMoney.text=INmoney.ToString();
	}
	public void OnreqTrade_ItemList2(UInt64 INmoney)
	{
		//show target trade item
		InTradeMoney.text=INmoney.ToString();
	}
	public void OnreqTrade_Done()
	{
		// trade is done

		Debug.Log ("trade is done");	
		deactivate ();
	
	}

}
