using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Hourglass.Items;
using Hourglass.Scenes;
using Hourglass.UI;

namespace Hourglass.Characters
{
    public class Player : Character
    {

        private Manager manager;

        public static Player user;

        public string[] boundKeys = { "1", "2", "3", "4", "5" };
        private int activeSlot = -1;

        protected new void Awake()
        {
            base.Awake();
            manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        }

        protected void Start()
        {
            user = GetComponent<Player>();
            items.Add(new Teleporter(user));
        }

        protected new void Update()
        {
            base.Update();
            for (int i = 0; i < boundKeys.Length; i++)
            {
                try
                {
                    items[i].Update();
                }
                catch(ArgumentOutOfRangeException)
                {

                }
            }
            manager.uiManager.quickslot.UpdateSlots();

            for (int i = 0; i < boundKeys.Length; i++)
            {
                if (Input.GetKeyDown(boundKeys[i]))
                {
                    if (activeSlot != i)
                    {
                        activeSlot = i;
                        manager.uiManager.quickslot.SetActive(activeSlot);
                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
                UseItem(true);
            if (Input.GetMouseButtonDown(1))
                UseItem(false);

        }

        public void GetItem(Item newItem)
        {
            items.Add(newItem);

            while (items.Count > boundKeys.Length)
                items.RemoveAt(boundKeys.Length);
        }

        private void UseItem(bool primary)
        {
            try
            {
                Item selected = items[activeSlot];
                if (selected == null)
                    return;

                if (primary)
                    selected.UsePrimary();
                else
                    selected.UseSecondary();
            }
            catch (ArgumentOutOfRangeException)
            {

            }

        }
    }
}