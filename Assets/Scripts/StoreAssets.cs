/// Copyright (C) 2012-2014 Soomla Inc.
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///      http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Store.Baby {
	
	/// <summary>
	/// This class defines our game's economy, which includes virtual goods, virtual currencies
	/// and currency packs, virtual categories
	/// </summary>
	public class StoreAssets : IStoreAssets{
		
		/// <summary>
		/// see parent.
		/// </summary>
		public int GetVersion() {
			return 0;
		}
		
		/// <summary>
		/// see parent.
		/// </summary>
		public VirtualCurrency[] GetCurrencies() {
			return new VirtualCurrency[]{IAP_COUNTER};
		}
		
		/// <summary>
		/// see parent.
		/// </summary>
		public VirtualGood[] GetGoods() {
			return new VirtualGood[] { IAP_DECREMENT_GOOD};
		}
		
		/// <summary>
		/// see parent.
		/// </summary>
		public VirtualCurrencyPack[] GetCurrencyPacks() {
			return new VirtualCurrencyPack[] {IAP_INCREMENT};
		}
		
		/// <summary>
		/// see parent.
		/// </summary>
		public VirtualCategory[] GetCategories() {
			return new VirtualCategory[]{GENERAL_CATEGORY};
		}
		
		/** Static Final Members **/
		
		public const string IAP_COUNTER_ITEM_ID      = "currency_ads";
		
		public const string IAP_INCREMENT_PRODUCT_ID = "android.test.purchased";

		public const string IAP_DECREMENT_ITEM_ID   = "undo_IAP";

		
		/** Virtual Currencies **/
		
		public static VirtualCurrency IAP_COUNTER = new VirtualCurrency(
			"Number of IAP's made",										// name
			"",												// description
			IAP_COUNTER_ITEM_ID							// item id
			);
		
		
		/** Virtual Currency Packs **/
		
		public static VirtualCurrencyPack IAP_INCREMENT = new VirtualCurrencyPack(
			"Increment number of IAP",                                  // name
			"Test purchase of an item",                 	// description
			"Remove_Ads",                                  // item id
			1,                                            // number of currencies in the pack
			IAP_COUNTER_ITEM_ID,                        // the currency associated with this pack
			new PurchaseWithMarket(IAP_INCREMENT_PRODUCT_ID, 0.99)
			);

		
		/** Virtual Goods **/
		
		
		public static VirtualGood IAP_DECREMENT_GOOD = new SingleUseVG(
			"Decrement",                                        		// name
			"Reduces it by 1",   	// description
			"undo_IAP",                                        		// item id
			new PurchaseWithVirtualItem(IAP_COUNTER_ITEM_ID, 1));  // the way this virtual good is purchased
		
		
		/** Virtual Categories **/
		// The muffin rush theme doesn't support categories, so we just put everything under a general category.
		public static VirtualCategory GENERAL_CATEGORY = new VirtualCategory(
			"General", new List<string>(new string[] {IAP_DECREMENT_ITEM_ID })
			);
	}
	
}
