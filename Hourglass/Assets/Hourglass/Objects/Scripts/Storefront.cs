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
        public float spacing = 10;
        GameObject[] storeItems;

        ItemList.ItemProperties[] availableItems = new ItemList.ItemProperties[5];

        public void Start()
        {
            Setup(ItemList.items);
        }

        public void Setup(ItemList.ItemProperties[] itemsprops)
        {
            
            if (itemsprops.Length > availableItems.Length)
            {
                List<ItemList.ItemProperties> remainingItems = new List<ItemList.ItemProperties>(itemsprops);
                System.Random r = new System.Random();
                for (int i = 0; i < availableItems.Length; i++)
                {
                    availableItems[i] = remainingItems[r.Next(remainingItems.Count)];
                }
            }
            else
            {
                for(int i = 0; i < itemsprops.Length; i++)
                {
                    availableItems[i] = itemsprops[i];
                }
            }

            storeItems = new GameObject[availableItems.Length];

            for(int i = 0; i < availableItems.Length; i++)
            {
                GameObject itemdisplay = Instantiate(storeItem, transform);
                itemdisplay.transform.position += new Vector3(spacing * i, 0, 0);
                if (availableItems[i] != null)
                {
                    itemdisplay.GetComponent<StoreDisplay>().Setup(availableItems[i]);
                    storeItems[i] = itemdisplay;
                }
            }
        }
    }
}
