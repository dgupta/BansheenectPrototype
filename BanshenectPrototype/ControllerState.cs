using System;
namespace BanshenectPrototype
{
	public class ControllerState :IState
	{
		public ControllerState ()
		{
			
		}
		
		#region IState implementation
		public void HandleRequest (string EncapsulatedRequest)
		{
			StateContext CurrentContext = StateContext.Instance;
			if(EncapsulatedRequest == SWIPEDOWN){
				CurrentContext.CurrentState = CurrentContext.StateTable[NOW];
			}
			//throw it away
			else{
			}
		}
		#endregion
		
		
		private readonly string SWIPEUP = "SwipeUp", SWIPELEFT ="SwipeLeft",SWIPERIGHT = "SwipeRight", SWIPEDOWN = "SwipeDown", ONPUSH = "OnPush";	
		private readonly string NOW = "NowPlaying", SONG = "SongSelection", ADDING = "AddingState", CONTROLLER = "ControllerState";

	}
}

