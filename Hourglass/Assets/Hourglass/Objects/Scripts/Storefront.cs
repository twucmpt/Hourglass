using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Hourglass;

namespace Assets.Hourglass.Objects.Scripts
{
    class Storefront : MonoBehaviour
    {
        public GameObject storeItem;
        GameObject[] storeItems;

        ItemList.ItemProperties[] availableItems = new ItemList.ItemProperties[5];

        public void Awake()
        {
            Setup(ItemList.items);
        }

        public void Setup(ItemList.ItemProperties[] itemsprops)
        {
            if (itemsprops.Length == 0)
            {
                System.Random r = new System.Random();
                for (int i = 0; i < availableItems.Length; i++)
                {
                    availableItems[i] = ItemList.items[r.Next(ItemList.items.Length)];
                }
            }
            else
                availableItems = itemsprops;

            storeItems = new GameObject[availableItems.Length];

            for(int i = 0; i < transform.childCount; i++)
            {
                GameObject itemdisplay = Instantiate(storeItem, transform);
                if (availableItems[i] != null)
                {
                    itemdisplay.GetComponent<StoreDisplay>().Setup(availableItems[i]);
                    storeItems[i] = itemdisplay;
                }
            }
        }
    }
}
