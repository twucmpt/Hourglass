using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Hourglass.Items;

namespace Hourglass.Characters
{
    public class Player : Character
    {
        public int itemLimit = 5;
        public string[] boundKeys = { "z", "x", "c", "v", "b" };
        private int selectedItem = 0;

        public void Awake()
        {
            items.Add(new Teleporter(this));
        }

        public void Update()
        {
            SelectItem();
            if (Input.GetMouseButtonDown(0))
                UseItem(true);
            if (Input.GetMouseButtonDown(1))
                UseItem(false);

        }

        private void SelectItem()
        {
            for(int i = 0; i < boundKeys.Length; i++)
                if (Input.GetKey(boundKeys[i]))
                    selectedItem = i;
        }

        public void GetItem(Item newItem)
        {
            items.Add(newItem);

            while (items.Count > itemLimit)
                items.RemoveAt(itemLimit);
        }

        private void UseItem(bool primary)
        {
            Item selected = items[selectedItem];
            if (selected == null)
                return;

            if (primary)
                selected.UsePrimary();
            else
                selected.UseSecondary();
        }
    }
}