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


        public static Player user;

        public string[] boundKeys = { "1", "2", "3", "4", "5" };

        protected new void Awake()
        {
            base.Awake();
        }

        protected void Start()
        {
            user = GetComponent<Player>();
            items.Add(new Teleporter(user));
            items.Add(new Glider(user));
            items.Add(new Pistol(user));
            items.Add(new GrappleHook(user));

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
                    Equip(i);
                    manager.uiManager.quickslot.SetActive(activeSlot);
                }
            }

            if (activeSlot > -1)
            {
                if (Input.GetMouseButtonDown(0))
                    UseItem(true);
                if (Input.GetMouseButtonDown(1))
                    UseItem(false);
                
            }


        }

        public void GetItem(Item newItem)
        {
            items.Add(newItem);

            while (items.Count > boundKeys.Length)
                items.RemoveAt(0);
        }

        private void OnCollisionEnter(Collision collision)
        {
            // stop grappling
            
            foreach (GrappleHookProjectile ghp in FindObjectsOfType<GrappleHookProjectile>())
            {
                if(IsGrounded())
                    Destroy(ghp);
            }
        }
    }
}