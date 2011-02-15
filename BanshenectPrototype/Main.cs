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
			Context CurrentContext = Context.Instance;
			Console.WriteLine(CurrentContext.CurrentState.ToString());
			
			//Obviously here an encapsulated request does absolutly nothing. I'm not sure if it ever will 
			CurrentContext.ChangeState("Do Something");
			CurrentContext.ChangeState("Do another thing");
		}
		
	}
}

