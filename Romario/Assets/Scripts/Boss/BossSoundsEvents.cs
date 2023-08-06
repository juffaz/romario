using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSoundsEvents : MonoBehaviour
{
    public void Voice1()
    {
        FindAnyObjectByType<AudioManager>().Play("Voc1");
    }

    public void Voice2()
    {
        FindAnyObjectByType<AudioManager>().Play("Voc2");
    }

    public void Voice3()
    {
        FindAnyObjectByType<AudioManager>().Play("Voc3");
    }


}
