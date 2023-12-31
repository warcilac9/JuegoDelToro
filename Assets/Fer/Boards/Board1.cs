using UnityEngine;

public class Board1 : MonoBehaviour
{
    public bool rojo1 = false;
    public bool azul1 = false;

    [SerializeField] bool active = false;

    private SpriteRenderer spriteRenderer;
    public SoundEffects soundEffects;

    void Start()
    {
        rojo1 = false;
        azul1 = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (rojo1 == false && azul1 == false)
        {
            active = false;
        }

        else
        {
            active = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Azul") && active == false)
        {
            spriteRenderer.color = Color.blue;
        }

        if (collision.CompareTag("Rojo") && active == false)
        {
            spriteRenderer.color = Color.red;
        }

        if (collision.CompareTag("CheckA"))
        {
            azul1 = true;
            rojo1 = false;
            active = true;
            spriteRenderer.color = Color.blue;
            //soundEffects.PlaySlotSound();
            GameObject.FindGameObjectWithTag("Azul").GetComponent<SoundEffects>().PlaySlotSound();
        }

        if (collision.CompareTag("CheckR"))
        {
            azul1 = false;
            rojo1 = true;
            active = true;
            spriteRenderer.color = Color.red;
            //soundEffects.PlaySlotSound();
            GameObject.FindGameObjectWithTag("Azul").GetComponent<SoundEffects>().PlaySlotSound();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Azul") && active == false)
        {
            spriteRenderer.color = Color.white;
        }

        if (collision.CompareTag("Rojo") && active == false)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
