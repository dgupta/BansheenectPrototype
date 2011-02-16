using System;
using xn;
using xnv;
namespace BanshenectPrototype
{
	public class KinectRunner
	{
		public KinectRunner ()
		{
			Init();
		}
		
		void Init(){
			CurrentContext = StateContext.Instance;
			Setup();
		}
		
		public void Run(){
			while(true){
				try{
					this.Context.WaitAndUpdateAll();
					this.SeshManager.Update(Context);
				}catch(SystemException){
				}
			}
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
			//set the default detector
			Flowy.SetActive(Pushy);
			//add the flow router to the session
			SeshManager.AddListener(Flowy);
			
		}
		
		private void SetupCallbacks(){
			Pushy.Push += new PushDetector.PushHandler(OnPush);
			//swipe detectors
			Swipy.SwipeUp += new SwipeDetector.SwipeUpHandler(SwipeUp);
			Swipy.SwipeRight += new SwipeDetector.SwipeRightHandler(SwipeRight);
			Swipy.SwipeDown += new SwipeDetector.SwipeDownHandler(SwipeDown);
			Swipy.SwipeLeft += new SwipeDetector.SwipeLeftHandler(SwipeLeft);
		}
		
		/// <summary>
		/// The following are all Methods that detectors will call. THESE are not finalized versions simply prototypes
		/// </summary>
		
		//push detectors
		private void OnPush(float velocity, float angle){
			Console.WriteLine("Switching to the Swipe  and to the next state");
			CurrentContext.ChangeState("Blah");
			Flowy.SetActive(Swipy);
		}
		
		//swipe detectors clockwise (up, right,down,left)
		private void SwipeUp(float left, float right){
			Console.WriteLine("Swipe Up but no state change");
		}
		
		private void SwipeRight(float left, float right){
			Console.WriteLine("Swipe right but no state change");
		}
		
		private void SwipeDown(float left, float right){
		}
		
		private void SwipeLeft(float left, float right){
		}
		
		//state changer (this changes both the state and 
		void StateChanger(string EncapsulatedRequest){
			//first forward the request
			CurrentContext.ChangeState(EncapsulatedRequest);
			//Choose FlowRouter
			ChooseFlowRouter();
		}
		
		//some nice monolithic logical statement
		void ChooseFlowRouter(){
			
		}
		
		//initializations
		private readonly string CONFIG = @"../../config.xml";
		StateContext CurrentContext;
		Context Context;
		//Managers
		SessionManager SeshManager;
		FlowRouter Flowy;
		//Detectors
		PushDetector Pushy;
		SwipeDetector Swipy;
		
	}
}

