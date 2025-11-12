using Services.LevelProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelsMap.View
{
    public class LevelButtonView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private int level;

        [SerializeField] private GameObject completed;
        [SerializeField] private GameObject locked;

        public Button Button => button;
        public int Level => level;

        private void Start() => SetLevel(level);

        public void SetLevel(int level) => text.SetText(level.ToString());

        public void SetState(LevelStatus levelStatus)
        {
            button.interactable = levelStatus != LevelStatus.Locked;
            locked.SetActive(levelStatus == LevelStatus.Locked);
            completed.SetActive(levelStatus == LevelStatus.Completed);
        }
    }
}