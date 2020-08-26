using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GM;

public class CoinController : MonoBehaviour
{

    private void Awake()
    {
        GlobalManager.CoinController = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            GlobalManager.GameManager.AddCoin();
            GlobalManager.AudioManager.PlayCoin();
        }
    }
}
