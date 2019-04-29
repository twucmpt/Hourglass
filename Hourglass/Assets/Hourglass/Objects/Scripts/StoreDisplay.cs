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

        private void Start()
        {
        }

        public void Setup(ItemList.ItemProperties iP)
        {
            itemProps = iP;
            GetComponent<Image>().sprite = itemProps.sprite;
            GetComponent<TextMesh>().text = itemProps.name + "\n" + itemProps.price;
        }
    }
}
