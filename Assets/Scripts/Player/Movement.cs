using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    public SpriteRenderer sprite;
    Vector2 dir;
    float oldDir;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        InputMovement();
        FlipSprite();
        if(UiManager.health == 0)
        {
            gameObject.SetActive(false);
        }
    }
    void InputMovement()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        transform.Translate(dir * movementSpeed * Time.deltaTime);
    }
    void FlipSprite()
    {
        if(dir.x > 0 || dir.x < 0)
            transform.localScale = new Vector3(Mathf.Sign(dir.x), 1, 1);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Shark"))
        {
            UiManager.health--;
            sprite.color = new Color(1, (float)0.48, 0, 1);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Shark"))
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
    }
}
