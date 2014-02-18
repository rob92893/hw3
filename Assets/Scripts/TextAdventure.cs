using UnityEngine;
using System.Collections;

public class TextAdventure : MonoBehaviour {
	
	enum GameState {START, SHIP, CAPTAINS_QUARTERS, CARGO_HOLD, LOOTED, SURRENDER, FIGHT, RUN};
	GameState gameState = GameState.START;
	bool keyFound = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "";
		
		if (gameState == GameState.START) {
			textBuffer += "You are a dolphin in the ocean\n";
			textBuffer += "Up ahead is a sunken ship\n\n";
			textBuffer += "Press [W] to approach the ship";
			if (Input.GetKeyDown(KeyCode.W)) {
				gameState = GameState.SHIP;
			}
		}
		else if (gameState == GameState.SHIP) {
			textBuffer += "There are 2 rooms on the ship:\n";
			textBuffer += "The captain's quarters and the cargo hold\n\n";
			textBuffer += "Press [A] to go to the captain's quarters\n";
			textBuffer += "Press [D] to go to the cargo hold";
			if (Input.GetKeyDown(KeyCode.A)) {
				gameState = GameState.CAPTAINS_QUARTERS;
			}
			else if (Input.GetKeyDown(KeyCode.D)) {
				gameState = GameState.CARGO_HOLD;
			}
		}
		else if (gameState == GameState.CAPTAINS_QUARTERS) {
			if (keyFound) {
				textBuffer += "The room is empty\n\n";
			}
			else {
				textBuffer += "You found a key!\n\n";
			}
			textBuffer += "Press [S] to go back to the deck of the ship";
			if (Input.GetKeyDown(KeyCode.S)) {
				gameState = GameState.SHIP;
				keyFound = true;
			}
		}
		else if (gameState == GameState.CARGO_HOLD) {
			textBuffer += "You found a treasure chest...\n";
			if (keyFound) {
				textBuffer += "The key opened the chest and it's full of\n";
				textBuffer += "gold and jewels!\n\n";
				textBuffer += "Press [W] to loot the chest";
				if (Input.GetKeyDown(KeyCode.W)) {
					gameState = GameState.LOOTED;
				}
			}
			else {
				textBuffer += "But it is locked\n\n";
				textBuffer += "Press [S] to go back to the deck of the ship";
				if (Input.GetKeyDown(KeyCode.S)) {
					gameState = GameState.SHIP;
				}
			}
		}
		else if (gameState == GameState.LOOTED) {
			textBuffer += "As you leave the ship, a shark notices\n";
			textBuffer += "the tresure you are carying and swims towards you!\n\n";
			textBuffer += "Press [A] to surrender and hand over the\n";
			textBuffer += "        treasure to the shark\n";
			textBuffer += "Press [S] to run away\n";
			textBuffer += "Press [W] to fight him\n";
			if (Input.GetKeyDown(KeyCode.A)) {
				gameState = GameState.SURRENDER;
			}
			else if (Input.GetKeyDown(KeyCode.S)) {
				gameState = GameState.RUN;
			}
			else if (Input.GetKeyDown(KeyCode.W)) {
				gameState = GameState.FIGHT;
			}
		}
		else if (gameState == GameState.SURRENDER) {
			textBuffer += "The shark spared your life but took all your treasure\n";
			textBuffer += "The End.";
		}
		else if (gameState == GameState.RUN) {
			textBuffer += "You got away safely with all the treasure!\n";
			textBuffer += "You Win!";
		}
		else if (gameState == GameState.FIGHT) {
			textBuffer += "You were no match for the shark!\n";
			textBuffer += "Gameover";
		}
		
		GetComponent<TextMesh>().text = textBuffer;
	}
}
