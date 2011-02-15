using System;
//load the OpenNI and the NITE.net libraries
using xn;
using xnv;


namespace BanshenectPrototype
{
	class MainClass
	{
		
		public static void Main (string[] args)
		{
			KinectRunner kr = new KinectRunner();
			kr.Run();
		}
		
		
		
	}
}

