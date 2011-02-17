using System;
namespace BanshenectPrototype
{
	public class NowPlayingState : IState
	{
		
		public NowPlayingState ()
		{
			
		}
		
		public void HandleRequest(string EncapsulatedRequest){
			StateContext CurrentContext = StateContext.Instance;
			if(EncapsulatedRequest == ONPUSH){
				
				
				CurrentContext.CurrentState = CurrentContext.StateTable[SONG];
			}
			if(EncapsulatedRequest == SWIPEUP){
				CurrentContext.CurrentState = CurrentContext.StateTable[CONTROLLER];
			}
			//throw it away
			else{
				
			}
		}
		
		private readonly string SWIPEUP = "SwipeUp", SWIPELEFT ="SwipeLeft",SWIPERIGHT = "SwipeRight", SWIPEDOWN = "SwipeDown", ONPUSH = "OnPush";	
		private readonly string NOW = "NowPlaying", SONG = "SongSelection", ADDING = "AddingState", CONTROLLER = "ControllerState";
	}
}

