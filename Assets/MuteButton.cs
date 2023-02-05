using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
	public Sprite muted;
	public Sprite unmuted;
	
	bool is_muted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void ToggleMute() {
		is_muted = !is_muted;
        if(is_muted) {
            AudioListener.volume = 0;
			GetComponent<Image>().sprite = muted;
        } else {
            AudioListener.volume = 1;
			GetComponent<Image>().sprite = unmuted;
        }
		
	}
}
