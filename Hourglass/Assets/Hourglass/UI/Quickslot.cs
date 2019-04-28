using Hourglass.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.UI
{
    public class Quickslot : MonoBehaviour
    {

        public GameObject slot;

        private GameObject[] slots;
        private Player player;

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().player;

            slots = new GameObject[player.boundKeys.Length];
            for (int i = 0; i < slots.Length; i++)
            {
                GameObject slotObject = Instantiate(slot, transform);
                slotObject.GetComponent<Slot>().Setup(player, i, player.boundKeys[i]);
                slots[i] = slotObject;

            }
        }

        public void UpdateSlots()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].GetComponent<Slot>().UpdateSlot();
            }
        }

        public void SetActive(int id)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i == id)
                {
                    slots[i].GetComponent<Slot>().SetActive(true);
                }
                else
                {
                    slots[i].GetComponent<Slot>().SetActive(false);
                }
            }
        }

        public GameObject GetSlot(int i)
        {
            return slots[i];
        }

    }
}
