using UnityEngine;
using System.Collections;
using Assets.Hourglass.Objects.Scripts;

public class ClickHandler : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Click");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                //Debug.Log("Hit " + hit.collider.name);
                if (hit.collider.gameObject.tag == "StoreItem")
                {
                    hit.collider.GetComponent<StoreDisplay>().BuyItem(); ;
                }
            }
        }
    }

}
