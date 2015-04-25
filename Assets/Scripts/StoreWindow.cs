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
using System;
using Soomla;
using UnityTest;

namespace Soomla.Store.Baby {
	
	/// <summary>
	/// This class contains functions that initialize the game and that display the different screens of the game.
	/// </summary>
	public class StoreWindow : MonoBehaviour {
		
		private static StoreWindow instance = null;
		GameObject GM;
		GameManager GMScript;
		
		private bool checkAffordable = false;
		

		/// <summary>
		/// Initializes the game state before the game starts.
		/// </summary>
		void Awake(){
			GM = GameObject.Find ("GameManager");
			GMScript = (GameManager)GM.GetComponent (typeof(GameManager));
			if(instance == null){ 	//making sure we only initialize one instance.
				instance = this;
				GameObject.DontDestroyOnLoad(this.gameObject);
			} else {					//Destroying unused instances.
				GameObject.Destroy(this);
			}
		}

		private Dictionary<string, bool> itemsAffordability;
		
		
		/// <summary>
		/// Starts this instance.
		/// Use this for initialization.
		/// </summary>
		void Start () {
			StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreInitialized;
			StoreEvents.OnCurrencyBalanceChanged += onCurrencyBalanceChanged;
			SoomlaStore.Initialize(new StoreAssets());
		}
		
		public void onSoomlaStoreInitialized() {
			
			// some usage examples for add/remove currency
			// some examples
			if (StoreInfo.Currencies.Count>0) {
				try {
					StoreInventory.GiveItem(StoreInfo.Currencies[0].ItemId,0);
					SoomlaUtils.LogDebug("SOOMLA ExampleEventHandler", "Currency balance:" + StoreInventory.GetItemBalance(StoreInfo.Currencies[0].ItemId));
				} catch (VirtualItemNotFoundException ex){
					SoomlaUtils.LogError("SOOMLA ExampleEventHandler", ex.Message);
				}
			}

			setupItemsAffordability ();
		}
		
		public void buttonTest(string ItemID){
			StoreInventory.BuyItem(ItemID);
		}

		
		public void setupItemsAffordability() {
			itemsAffordability = new Dictionary<string, bool> ();
			
			foreach (VirtualGood vg in StoreInfo.Goods) {
				itemsAffordability.Add(vg.ID, StoreInventory.CanAfford(vg.ID));
			}
		}
		
		public void onCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded) {
			if (itemsAffordability != null)
			{
				List<string> keys = new List<string> (itemsAffordability.Keys);
				foreach(string key in keys)
					itemsAffordability[key] = StoreInventory.CanAfford(key);
			}
		}
		
		/// <summary>
		/// Sets the window to open, and sets the GUI state to welcome.
		/// </summary>

		
		/// <summary>
		/// Sets the window to closed.
		/// </summary>

		
		/// <summary>
		/// Implements the game behavior of MuffinRush.
		/// Overrides the superclass function in order to provide functionality for our game.
		/// </summary>
		void Update () {
			if (StoreInventory.GetItemBalance (StoreInfo.Currencies [0].ItemId) > 0) {
				GMScript.SwapAds (false);
			} else {
				GMScript.SwapAds (true);
			}
			
			if (Application.platform == RuntimePlatform.Android) {
				if (Input.GetKeyUp(KeyCode.Escape)) {
					//quit application on back button
					Application.Quit();
					return;
				}
			}
		}
	}
}
