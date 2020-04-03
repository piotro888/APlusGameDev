using UnityEngine;
using System.Diagnostics;

public class BombController : MonoBehaviour
{
    Stopwatch stopwatch;

    void Start(){
        stopwatch.Start();
    }

    
    void FixedUpdate(){
        if(stopwatch.ElapsedMilliseconds > 1000){

        }
    }
}
