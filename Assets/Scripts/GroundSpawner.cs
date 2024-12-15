
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public Transform nextSpawnPoint;


    //public void SpawnTile()
    //{
    //    GameObject temp = Instantiate(groundTile, nextSapwnPoint, Quaternion.identity);
    //    nextSapwnPoint = temp.transform.GetChild(1).transform.position;
    //}

    public void SpawnNewTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint.position, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1);
        Debug.Log(nextSpawnPoint.position);
    }
    // Start is called before the first frame update
    void Start()
    {
        //for(int i=0; i<6; i++)
        //{
        //    SpawnTile();
        //}
        

    }
}
