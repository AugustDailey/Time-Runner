using UnityEngine;
using FSharpUnityTutorial;

public class CallFSharp : MonoBehaviour
{
    void Start()
    {
        FSharpMath math = new FSharpMath();
        Debug.Log("C# " + math.Add(20, 22).ToString());
    }
}
