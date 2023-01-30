using UnityEngine;
using System.Diagnostics;
using System.Threading;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string output;

    public void Start()
    {
        string frequencyUnity;
        string nanosecPerTickUnity;

        long frequency = Stopwatch.Frequency;
        frequencyUnity = frequency.ToString();
        UnityEngine.Debug.Log("Timer frequency in ticks per second = ");
        UnityEngine.Debug.Log(frequencyUnity);
        long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
        nanosecPerTickUnity = nanosecPerTick.ToString();
        UnityEngine.Debug.Log("Timer is accurate within = ");
        UnityEngine.Debug.Log(nanosecPerTickUnity);
    }

    public void ProcessedText1()
    {
        long nanosecPerTick = (1000L * 1000L * 1000L) / Stopwatch.Frequency;
        const int numIterations = 10000;
        string maxTicksUnity;
        string minTicksUnity;
        string milliSecUnity;
        // Optimize this code in term of Garbage collect and Performance
        // Prepare slide to showcase the comparison before and after

        //TimeSpan ts = stopWatch.Elapsed;
        long numTicks = 0;
        long numRollovers = 0;
        long maxTicks = 0;
        long minTicks = Int64.MaxValue;
        int indexFastest = -1;
        int indexSlowest = -1;
        long milliSec = 0;

        Stopwatch time10kOperations = Stopwatch.StartNew();
        for (int i = 0; i < numIterations; ++i)
        {
           
            
            long ticksThisTime = 0;
            Stopwatch timePerParse;
            timePerParse = Stopwatch.StartNew();
            output += i.ToString() + "\n";
            timePerParse.Stop();
            ticksThisTime = timePerParse.ElapsedTicks;

            if (i == 0)
            {
                time10kOperations.Reset();
                time10kOperations.Start();
            }
            else
            {
                if (maxTicks < ticksThisTime)
                {
                    indexSlowest = i;
                    maxTicks = ticksThisTime;
                }
                if (minTicks > ticksThisTime)
                {
                    indexFastest = i;
                    minTicks = ticksThisTime;
                }
                numTicks += ticksThisTime;
                if (numTicks < ticksThisTime)
                {
                    // Keep track of rollovers.
                    numRollovers++;
                }
            }
            output += i.ToString() + "\n";
        }
        
        time10kOperations.Stop();
        milliSec = time10kOperations.ElapsedMilliseconds;
        maxTicksUnity = maxTicks.ToString();
        minTicksUnity = minTicks.ToString();
        milliSecUnity = milliSec.ToString();
        UnityEngine.Debug.Log("Slowest Time:");
        UnityEngine.Debug.Log(maxTicksUnity);
        UnityEngine.Debug.Log("Fastest Time:");
        UnityEngine.Debug.Log(minTicksUnity);
        UnityEngine.Debug.Log("Total time looping through 10000 operations:");
        UnityEngine.Debug.Log(milliSecUnity); 
        UnityEngine.Debug.Log(output);

        time10kOperations.Reset();
        milliSec = 0;
    }
    public void ProcessedText()
    {
        long nanosecPerTick = (1000L * 1000L * 1000L) / Stopwatch.Frequency;
        const int numIterations = 10000;
        string maxTicksUnity;
        string minTicksUnity;
        string milliSecUnity;
        // Optimize this code in term of Garbage collect and Performance
        // Prepare slide to showcase the comparison before and after

        //TimeSpan ts = stopWatch.Elapsed;
        long numTicks = 0;
        long numRollovers = 0;
        long maxTicks = 0;
        long minTicks = Int64.MaxValue;
        int indexFastest = -1;
        int indexSlowest = -1;
        long milliSec = 0;

        Stopwatch time10kOperations = Stopwatch.StartNew();
        for (int i = 0; i < numIterations; ++i)
        {
            long ticksThisTime = 0;
            int inputNum;
            Stopwatch timePerParse;
            timePerParse = Stopwatch.StartNew();
            if (!Int32.TryParse("0", out inputNum))
            {
                inputNum = 0;
                output += inputNum.ToString() + "\n";
                
            }
      
            timePerParse.Stop();
            ticksThisTime = timePerParse.ElapsedTicks;

            if (i == 0)
            {
                time10kOperations.Reset();
                time10kOperations.Start();
            }
            else
            {
                if (maxTicks < ticksThisTime)
                {
                    indexSlowest = i;
                    maxTicks = ticksThisTime;
                }
                if (minTicks > ticksThisTime)
                {
                    indexFastest = i;
                    minTicks = ticksThisTime;
                }
                numTicks += ticksThisTime;
                if (numTicks < ticksThisTime)
                {
                    // Keep track of rollovers.
                    numRollovers++;
                }
            }
            output += i.ToString() + "\n";
        }

        time10kOperations.Stop();
        milliSec = time10kOperations.ElapsedMilliseconds;
        maxTicksUnity = maxTicks.ToString();
        minTicksUnity = minTicks.ToString();
        milliSecUnity = milliSec.ToString();
        UnityEngine.Debug.Log("Slowest Time:");
        UnityEngine.Debug.Log(maxTicksUnity);
        UnityEngine.Debug.Log("Fastest Time:");
        UnityEngine.Debug.Log(minTicksUnity);
        UnityEngine.Debug.Log("Total time looping through 10000 operations:");
        UnityEngine.Debug.Log(milliSecUnity);
        UnityEngine.Debug.Log(output);

        time10kOperations.Reset();
        milliSec = 0;
    }

    public void GoScene(int buildIndex)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }

    public void BackScene(int buildIndex)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
