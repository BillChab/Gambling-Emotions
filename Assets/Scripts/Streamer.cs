using liblsl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streamer : MonoBehaviour
{
	// Class attributes
	StreamOutlet Outlet;
	string[] Sample;
	
    // Start is called before the first frame update
    void Start()
    {
        StreamInfo streamInfo = new StreamInfo("Gambling Emotions", "Markers", 1, 0, channel_format_t.cf_string);
		Outlet = new liblsl.StreamOutlet(streamInfo);
		Sample = new string[1];
    }
	
	public void PushSample(string Sample)
	{
		this.Sample[0] = Sample;
		Outlet.push_sample(this.Sample);
	}
	
    void OnApplicationQuit() { Outlet = null; }
}
