using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTriggerScript : MonoBehaviour {
    public GameObject blastParticle;
    private bool once;
    public BoxCollider boxCollider1;
    public BoxCollider boxCollider2;

    public GameObject fastRunItem;

    // Use this for initialization
    void Start () {
        boxCollider1.enabled = false;
        boxCollider2.enabled = false;
        StartCoroutine(BlastParticleeffect(1f));
	}
    private IEnumerator BlastParticleeffect(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameObject p = Instantiate(blastParticle, this.transform.position, this.transform.rotation);
        p.transform.parent = this.gameObject.transform;
        this.transform.GetChild(0).gameObject.SetActive(false);
        once = true;
        boxCollider1.enabled = true;
        boxCollider2.enabled = true;
        yield return new WaitForSeconds(seconds/2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {
            if (other.gameObject.transform.childCount < 1)
            {
                this.gameObject.transform.parent = other.gameObject.transform;
                this.transform.position = new Vector3(other.gameObject.transform.position.x,
                    other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            }
            else
            {
                Destroy(this.gameObject);
            }

        }
        if (other.gameObject.CompareTag("Player"))
        {
            if (once)
            {
                print(other.gameObject.name);
               other.gameObject.GetComponent<PlayerControllerScript>().enabled = false;
                if (other.name == "Player_A")
                {
                    GameManagerScript.scoreB++;
                }
                if (other.name == "Player_B")
                {
                    GameManagerScript.scoreA++;
                }
                GameManagerScript.instant.players.Add(other.gameObject);
                Destroy(this.gameObject, 1f);
            }
        }
        if (other.gameObject.CompareTag("Ops"))
        {
            if (once)
            {
                if (GameManagerScript.optItem == 4 || GameManagerScript.optItem == 6)
                {
                    Instantiate(fastRunItem, other.transform.position, Quaternion.identity);
                }
                GameManagerScript.optItem++;
               
                print(other.gameObject.name);
                Destroy(other.gameObject);
                Destroy(this.gameObject, 1f);
            }
        }
    }
}
