﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Prospector : MonoBehaviour {
	static public Prospector 	S;

	[Header("Set in Inspector")]


	public TextAsset			deckXML;
	public TextAsset 			layoutXML;
	public float xOffset = 3;
	public float yOffset = -2.5f;
	public Vector3 layoutCenter;

	[Header("Set Dynamically")]
		
	public Deck					deck;
	public Layout 				layout;
	public List<CardProspector> drawPile;
	public Transform layoutAnchor;
	public CardProspector target;
	public List <CardProspector> tableau;
	public List <CardProspector> discardPile;

	void Awake(){
		S = this;
	}

	void Start () {
		deck = GetComponent<Deck> ();
		deck.InitDeck (deckXML.text);
		Deck.Shuffle(ref deck.cards);

		//Card c;
		//for (int cNum = 0; cNum < deck.cardsCount; cNum++) {
		//	c = deck.cards [cNum];
		//	c.transform.localPosition = new Vector3 ((cNum % 13) * 3, cNum / 13 * 4, 0);
		//	}
		layout = GetComponent<Layout> ();
		layout.ReadLayout (layoutXML.text);
		drawPile = ConvertListCardsToListCardProspectors (deck.cards);
		LayoutGame ();

	}
	List<CardProspector> ConvertListCardsToListCardProspectors(List<Card> lCD) {
		List<CardProspector> lCP = new List<CardProspector>();
		CardProspector tCP;
		foreach (Card tCD in lCD){
			tCP=tCD as CardProspector;
			lCP.Add(tCP);
		}
		return (lCP);
	}

	}


