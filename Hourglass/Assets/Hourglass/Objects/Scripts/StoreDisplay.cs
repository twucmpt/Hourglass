using Hourglass;
using Hourglass.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Hourglass.Objects.Scripts
{
    class StoreDisplay : MonoBehaviour
    {
        private ItemList.ItemProperties itemProps;
        Manager manager;

        private void Start()
        {
            manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        }

        public void Setup(ItemList.ItemProperties iP)
        {
            itemProps = iP;
            GetComponent<SpriteRenderer>().sprite = itemProps.sprite;
            transform.GetChild(0).GetComponent<TextMesh>().text = itemProps.name + "\n" + itemProps.price;            
        }

        public void BuyItem()
        {
            Item item = ItemList.GetNewItem(itemProps,manager.player);
            if(manager.player.GetSand() > item.Price)
            {
                manager.player.RemoveSand(item.Price);
                manager.player.GetItem(item);
            }

        }
    }
}
