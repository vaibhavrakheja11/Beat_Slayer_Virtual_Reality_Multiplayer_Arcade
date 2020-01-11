using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class Map : MonoBehaviour
{
    float[] samples = new float[512];
    public static float[] _frequencyBand = new float[8];
    public  static float[] _audioBand = new float[8];
    public static float[] _bandBuffer = new float[8];
    public  static float[] _audioBandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];
    float[] _frequencyBandHighest = new float[8];

 


    public Transform startPos;
    public GameObject[] spawnLocationsMap;
    public GameObject[] maps;
    int nextStep = 0;
	public GameObject[] map;
    public GameObject[] enemy;
    // Start is called before the first frame update
    public bool mapNext = false;
    private int spawnedEnemies;
    private int currentEnemies;
    private int maxLoc;
    AudioSource _audiosource;

    

    private void Start()
    {
        _audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
	{
        
        GetSpectrumAudioSource();
        MakeFrequencybands();
        BandBuffer();
        CreateAudioBands();

        enemy = GameObject.FindGameObjectsWithTag("enemyAI");

        if (enemy.Length == 0)
        {
            mapNext = true;
        }

        if (mapNext)
        {

            GenerateMap();
        }
        

        map = GameObject.FindGameObjectsWithTag("map");

    }

    

    void GenerateMap()
    {
        Color newCol;


        bool bConverted = ColorUtility.TryParseHtmlString("#C34df3", out newCol);
        maxLoc  = GameObject.FindGameObjectsWithTag("EnemySpawnPoint").Length;

        nextStep += 80;
        if (spawnLocationsMap.Length == 0)
        {
            Instantiate(map[0], new Vector3(startPos.position.x, startPos.position.y, startPos.position.z + nextStep), Quaternion.identity);
            RenderSettings.fogColor = newCol;
            spawnner spawnner = new spawnner();
            //spawnner.level = map.Length + 1;
            spawnner.SpawnCharatcter(map.Length + 1,maxLoc);
            mapNext = false;
        }
        else
        {
            Debug.Log("Previous Spawn Points still intact" + spawnLocationsMap.Length);
            mapNext = false;
        }
        mapNext = false;
    }

    void GetSpectrumAudioSource()
    {
        _audiosource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencybands()
    {
        //22050 / 512  = 43hertz per sample

        int count = 0;
       
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int samplecunt = (int)Mathf.Pow(2, i) * 2;
            //Debug.Log("SampleCunt ----> " + samplecunt);
            if(i==7)
            {
                samplecunt += 2;
            }
            for ( int j = 0; j < samplecunt; j++)
            {
                average += samples[count] * (count+1);
                count++;

            }
            average /= count;
            _frequencyBand[i] = average * 10;

        }
    }

    void BandBuffer()
    {
        for(int g =0; g < 8; ++g)
        {
            if(_frequencyBand[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _frequencyBand[g];
                _bufferDecrease[g] = 0.005f;
            }
            if(_frequencyBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void CreateAudioBands()
    {
        for(int i=0; i< 8; i++)
        {
            if(_frequencyBand[i]>_frequencyBandHighest[i])
            {
                _frequencyBandHighest[i] = _frequencyBand[i];

            }
            _audioBand[i] = (_frequencyBand[i] / _frequencyBandHighest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i]/ _frequencyBandHighest[i]);

        }
    }

}
