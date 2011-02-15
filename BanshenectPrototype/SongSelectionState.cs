using System;
namespace BanshenectPrototype
{
	public class SongSelectionState : IState
	{
		
		
		public SongSelectionState ()
		{
		}
		
		public void HandleRequest(string EncapsulatedRequest){
			StateContext CurrentContext = StateContext.Instance;
			CurrentContext.CurrentState = CurrentContext.StateTable["NowPlaying"];
			Console.WriteLine(CurrentContext.CurrentState.ToString());
		}
	}
}

