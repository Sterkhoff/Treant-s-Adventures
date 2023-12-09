using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameObjects.NPC
{
    internal class InvisibleWallNPC : NPCItemQuest
    {
        public GameObject Wall;
        protected override void TakeChoosenItem()
        {
            base.TakeChoosenItem();
            Wall.SetActive(false);
        }
    }
}
