using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public FireManager fireManager;
    public int firePointCount;
    public ParticleSystem water;
    public bool fireFinished = false;
    public MovementControl movementControl;
    public Vector3 targetPosition;
    public float speed=3;
    public GameObject character;
    

    [SerializeField] private TextMeshProUGUI fireCountText;
    void Start()
    {
        firePointCount = fireManager.firePoints.Length;
    }

    
    void Update()
    {
        fireCountText.text = firePointCount.ToString();
    }

    public void CheckFirePoints()
    {
        if (firePointCount == 0)
        {
            fireFinished = true;
            movementControl.GetComponent<Animator>().SetBool("Run",true);
            movementControl.GetComponent<Animator>().SetBool("ReachedPoint",false);
            water.Stop();
            Debug.Log("YANGIN SÖNDÜ");
        }
    }

    public void NextLevel()
    {
        character.transform.position = Vector3.MoveTowards(character.transform.position, targetPosition, speed * Time.deltaTime);
        character.transform.rotation = Quaternion.Euler(0f,90f,0f);
    }
}
