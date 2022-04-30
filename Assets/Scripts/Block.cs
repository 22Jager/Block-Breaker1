 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config param
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites; 

    //cached reference
    LevelLogic level;

    //state variables
    int timesHit = 0;

    private void Start() 
    {
        CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (tag == "Breakable") 
        {
            HandleHit();
        }
    }

    private void HandleHit() 
    {
        int maxHits = hitSprites.Length + 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else 
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() 
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock() 
    {
        AudioSource.PlayClipAtPoint(breakSound, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        FindObjectOfType<GameStatus>().AddToScore();
        TriggerSparkles();
        level.BlockWasBroken();
        Destroy(gameObject);
    }

    private void TriggerSparkles() 
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    private void CountBreakableBlocks() 
    {
        level = FindObjectOfType<LevelLogic>();
        if (tag == "Breakable")
        {
            level.CountNumberOfBlocks();
        }
    }
}
