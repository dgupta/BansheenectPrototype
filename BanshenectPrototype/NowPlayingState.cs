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
			CurrentContext.CurrentState = CurrentContext.StateTable["SongSelection"];
			Console.WriteLine(CurrentContext.CurrentState.ToString());
		}
	}
}

