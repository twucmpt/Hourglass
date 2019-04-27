using Hourglass.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.UI
{
    public class Quickslot : MonoBehaviour
    {

        public int numQuickslots = 5;
        public GameObject slot;

        private GameObject[] slots;
        private Character character;

        void Awake()
        {
            character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();

            slots = new GameObject[numQuickslots];
            for (int i = 0; i < numQuickslots; i++)
            {
                GameObject slotObject = Instantiate(slot, transform);
                slotObject.GetComponent<Slot>().Setup(character,(i+1).ToString());
                slots[i] = slotObject;

            }
        }

        public GameObject GetSlot(int i)
        {
            return slots[i];
        }

    }
}
