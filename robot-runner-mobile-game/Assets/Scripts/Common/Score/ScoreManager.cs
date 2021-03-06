﻿using System.Collections;
using System.Collections.Generic;

using Vaneftec.Game.Common.Level;

// Copyright (c) Florian Steitz
namespace Vaneftec.Game.Common.Score {

	/// <summary>
	/// The <code>ScoreManager</code> is responsible for updating the player score and notifying all listeners.
	/// </summary>
	public class ScoreManager {

		public static readonly int DEFAULT_SCORE = 0;

		private List<OnUpdate> listeners = new List<OnUpdate>();

		public PlayableLevel CurrentLevel { get; set; }

		/// <summary>
		/// Registers the given listener. A listener is notified whenever the player score is updated.
		/// </summary>
		/// <param name="listener">The listener that shall be registered</param>
		public void Register(OnUpdate onUpdate) {
			listeners.Add(onUpdate);
		}

		/// <summary>
		/// Updates the score with either a positive or negative value.
		/// </summary>
		/// <param name="scoreValueToAdd">The value that shall be added to the score. If the score is negative, the value will be substracted from the score instead.</param>
		public void UpdateScore(int scoreValueToAdd) {
			CurrentLevel.CurrentScore += scoreValueToAdd;

			if (listeners != null) {
				listeners.ForEach(onUpdate => onUpdate(CurrentLevel.CurrentScore));
			}
		}

		/// <summary>
		/// TODO
		/// </summary>
		/// <returns>TODO</returns>
		public int GetScore() {
			return CurrentLevel.CurrentScore;
		}

		/// <summary>
		/// TODO
		/// </summary>
		public delegate void OnUpdate(int score);
	}
}
