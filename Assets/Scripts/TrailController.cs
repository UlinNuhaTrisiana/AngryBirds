using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    public GameObject Trail; // Menampung prefab GameObject dg komponen sprite
    public Bird TargetBird; // Burung yang akan diberi trails

    private List<GameObject> _trails;

    // Start is called before the first frame update
    void Start()
    {
        // Inisiasi atribut _trails
        _trails = new List<GameObject>();
    }

    // Menambah burung yg akan dijadikan target, dan reset ulang trail
    public void SetBird(Bird bird){
        TargetBird = bird;

        for (int i = 0; i < _trails.Count; i++)
        {
            Destroy(_trails[i].gameObject);
        }

        _trails.Clear();
    }

    // Membuat GameObject trail tiap 100ms
    public IEnumerator SpawnTrail(){
        _trails.Add(Instantiate(Trail, TargetBird.transform.position, Quaternion.identity));

        yield return new WaitForSeconds(0.1f);

        if (TargetBird != null && TargetBird.State != Bird.BirdState.HitSomething)
        {
            StartCoroutine(SpawnTrail());
        }
    }
}
