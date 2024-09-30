using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] GameObject oceanprefab;
    private int planelength = 10;
    private int chunksize = 100;
    private int renderDistance = 50;

    [SerializeField] private Transform playerpos;

    private void Start()
    {
        LoadChunks();
    }


    // 내 기준 + - 로 처리하기 
    private void LoadChunks()
    {

        for(int i = -20; i < 20; i++)
        {
            for(int j = -20; j < 20; j++)
            {
                Vector3 chunkpos = new Vector3(playerpos.position.x + i * planelength, -0.5f, playerpos.position.y + j * planelength);
                GameObject chunk = Instantiate(oceanprefab, chunkpos, Quaternion.identity);
                chunk.transform.SetParent(transform);
            }
        }

    }

}
