namespace KBEngine
{
	using UnityEngine; 
	using System; 
	using System.Collections; 
	using System.Collections.Generic;

	public class Trade
	{
		public Entity entity = null;

		public Trade(Entity e)
		{
			entity = e;
		}


		public void reqBeginTrade(Int32 ENTITY_ID)
		{
			entity.cellCall("reqBeginTrade", ENTITY_ID); 
		}


		public void reqLockTradeItem(Dictionary<UInt32, UInt32> OutItem,UInt64 Outmoney)
		{
			entity.cellCall("reqLockTradeItem", OutItem,Outmoney);
		}


		public void reqLockTradeItem2(UInt64 Outmoney)
		{
			entity.cellCall("reqLockTradeItem2", Outmoney);
		}


	

		public void reqTrade()//Dictionary<string, object> OutItem,UInt64 Outmoney)
		{
			//make sure to trade
			entity.cellCall("reqTrade");
		}



	}
} 
