using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Hourglass.Items;
using Hourglass.Scenes;

namespace Hourglass.Characters
{
    public class Player : Character
    {
        public static Player user;

        public int itemLimit = 5;
        public string[] boundKeys = { "z", "x", "c", "v", "b" };
        private int selectedItem = 0;

        protected new void Awake()
        {
            base.Awake();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

        protected void Start()
        {
            user = GetComponent<Player>();
            items.Add(new Teleporter(user));
        }

        protected new void Update()
        {
            base.Update();

            SelectItem();
            if (Input.GetMouseButtonDown(0))
                UseItem(true);
            if (Input.GetMouseButtonDown(1))
                UseItem(false);

        }


        private void SelectItem()
        {
            for (int i = 0; i < items.Count && i < boundKeys.Length; i++)
                if (Input.GetKey(boundKeys[i]))
                {
                    selectedItem = i;
                    return;
                }
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