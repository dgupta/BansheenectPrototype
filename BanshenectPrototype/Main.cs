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
			StateContext CurrentContext = StateContext.Instance;
			Console.WriteLine(CurrentContext.CurrentState.ToString());
			Setup();
			//Obviously here an encapsulated request does absolutly nothing. I'm not sure if it ever will 
			CurrentContext.ChangeState("Do Something");
			CurrentContext.ChangeState("Do another thing");
		}
		
		private void Setup(){
			//build the context
			Context = new Context(CONFIG);
			//build session manager
			SeshManager = new SessionManager(Context,"RaiseHand","RaiseHand");
			SeshManager.SetQuickRefocusTimeout(15000);
			//build the FlowRouter
			Flowy  = new FlowRouter();
			//build the detectors
			Pushy = new PushDetector();
			Swipy = new SwipeDetector();
			//setup all the callbacks
			SetupCallbacks();
		}
		
		private void SetupCallbacks(){
			
		}
		
		/// <summary>
		/// The following are all Methods that detectors will call. THESE are not finalized versions simply prototypes
		/// </summary>
		
		//push detectors
		private void OnPush(float velocity, float angle){
			
		}
		
		//swipe detectors clockwise (up, right,down,left)
		private void SwipeUp(float left, float right){
		
		}
		
		private void SwipeRight(float left, float right){
		}
		
		private void SwipeDown(float left, float right){
		}
		
		private void SwipeLeft(float left, float right){
		}
		
		//initializations
		private readonly string CONFIG = @"../../config.xml";
		Context Context;
		//Managers
		SessionManager SeshManager;
		FlowRouter Flowy;
		//Detectors
		PushDetector Pushy;
		SwipeDetector Swipy;
		
	}
}

