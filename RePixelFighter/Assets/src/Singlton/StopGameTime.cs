using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGameTime{

	private static StopGameTime mInstance;

	private StopGameTime(){}

    public static StopGameTime Instance {
        get {
            if( mInstance == null ) mInstance = new StopGameTime();

            return mInstance;
        }
    }

	bool stop_flag = false;
	public bool StopFlag{
		get{  return stop_flag;  }
		set{  stop_flag = value;  }
	}

}
