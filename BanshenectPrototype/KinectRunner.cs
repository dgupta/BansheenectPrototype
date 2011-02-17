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
		
		/// <summary>
		/// Setup builds an XN Context, Session Manager and all the detectors. 
		/// It also adds the callbacks for the SessionManager and adds the listeners on the Broadcaster. 
		/// </summary>
		private void Setup(){
			//build the context
			Context = new Context(CONFIG);
			//build session manager
			SeshManager = new SessionManager(Context,"RaiseHand","RaiseHand");
			SeshManager.SetQuickRefocusTimeout(15000);
			//build the FlowRouter
			Flowy  = new FlowRouter();
			//build the Broadcaster
			BCaster = new Broadcaster();
			//build the detectors
			Pushy = new PushDetector();
			Swipy = new SwipeDetector();
			//setup all the callbacks
			SetupCallbacks();
			Flowy.SetActive(BCaster);
			//add the flow router to the session
			SeshManager.AddListener(Flowy);
			SeshManager.SessionStart += SessionStarted;
			//add the listeners to BCaster
			BCaster.AddListener(Pushy);
			BCaster.AddListener(Swipy);
		}
		
		/// <summary>
		/// Add the callbacks 
		/// </summary>
		
		private void SetupCallbacks(){
			Pushy.Push += new PushDetector.PushHandler(OnPush);
			//swipe detectors
			Swipy.SwipeUp += new SwipeDetector.SwipeUpHandler(SwipeUp);
			Swipy.SwipeRight += new SwipeDetector.SwipeRightHandler(SwipeRight);
			Swipy.SwipeDown += new SwipeDetector.SwipeDownHandler(SwipeDown);
			Swipy.SwipeLeft += new SwipeDetector.SwipeLeftHandler(SwipeLeft);
		}
		
		private void SessionStarted(ref Point3D point){
			Console.WriteLine("{0} ", CurrentContext.CurrentState.ToString());
			Console.WriteLine(Flowy.ToString());
		}
		
		/// <summary>
		/// The following are all Methods that detectors will call. THESE are not finalized versions simply prototypes
		/// </summary>
		
		//push detectors
		private void OnPush(float velocity, float angle){
			StateChanger(ONPUSH);
		}
		
		//swipe detectors clockwise (up, right,down,left)
		private void SwipeUp(float left, float right){
			StateChanger(SWIPEUP);
		}
		
		private void SwipeRight(float left, float right){
			StateChanger(SWIPERIGHT);
		}
		
		private void SwipeDown(float left, float right){
			StateChanger(SWIPEDOWN);
		}
		
		private void SwipeLeft(float left, float right){
			StateChanger(SWIPELEFT);
		}
		
		//state changer (this changes both the state and 
		void StateChanger(string EncapsulatedRequest){
			//first forward the request
			Console.WriteLine("State Changing");
			Console.WriteLine(EncapsulatedRequest);
			CurrentContext.ChangeState(EncapsulatedRequest);
			//Choose FlowRouter
			SetActiveOnFlowRouter();
		}
		
		//some nice monolithic logical statements to set the active listener on the flow router
		void SetActiveOnFlowRouter(){
			if(CurrentContext.CurrentState.ToString() == "BanshenectPrototype.NowPlayingState"){
				Console.WriteLine("Setting to the Broadcaster");
				Flowy.SetActive(BCaster);
			}
			if(CurrentContext.CurrentState.ToString() == "BanshenectPrototype.SongSelectionState" || CurrentContext.CurrentState.ToString() == "BanshenectPrototype.AddingState"){
				Console.WriteLine("Setting to Pushy");
				Flowy.SetActive(Pushy);
			}
			if(CurrentContext.CurrentState.ToString() == "BanshenectPrototype.ControllerState"){
				Console.WriteLine("Setting to Swipy");
				Flowy.SetActive(Swipy);
			}
		}
		
		//initializations
		private readonly string CONFIG = @"../../config.xml";
		//a nice list of readonly strings
		private readonly string SWIPEUP = "SwipeUp", SWIPELEFT ="SwipeLeft",SWIPERIGHT = "SwipeRight", SWIPEDOWN = "SwipeDown", ONPUSH = "OnPush";
		
		StateContext CurrentContext;
		Context Context;
		//Managers
		SessionManager SeshManager;
		FlowRouter Flowy;
		Broadcaster BCaster;
		//Detectors
		PushDetector Pushy;
		SwipeDetector Swipy;
		
	}
}

