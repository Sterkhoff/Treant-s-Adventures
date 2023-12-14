using UnityEngine;

namespace Assets.Scripts.GameObjects.NPC
{
    public class FairyMiniGameNPC : NPCMiniGame
    {
        public GameObject FairyFollower;

        protected override void ShowChoicePanel()
        {
            if (Game.IsComplete)
                choicePanel.Show(TextForChoicePanelIfGameComplete, () => FairyFollower.SetActive(true), () => Destroy(gameObject));
            else
            {
                choicePanel.Show(TextForChoicePanelIfGameNotComplete, locChanger.ChangeLocation);
            }
        }
    }
}
