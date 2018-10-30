using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprite;
    public static int breakableCount = 0;
    public AudioClip crack;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprite.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
            PuffSmoke();
        }
        else
        {
            LoadSprites();
        }
    }

    public void PuffSmoke()
    {
        smoke.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
        
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity)
                as GameObject;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprite[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }
        
    }
}
