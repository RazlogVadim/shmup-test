using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Game.View
{
    public class GameEndedView : MonoBehaviour
    {
        private const string LostDesc = "You Lost!";
        private const string WonDesc = "You Won!";

        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private Button menuButton;
        [SerializeField] private Button restartButton;

        public void SetDescription(bool win) => description.text = win ? WonDesc : LostDesc;

        public void SetButtonActions(Action restart, Action menu)
        {
            menuButton.onClick.AddListener(() => menu());
            restartButton.onClick.AddListener(() => restart());
        }
    }
}
