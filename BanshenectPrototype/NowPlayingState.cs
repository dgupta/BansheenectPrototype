using System;
namespace BanshenectPrototype
{
	public class NowPlayingState : IState
	{
		
		public NowPlayingState ()
		{
		}
		
		public void HandleRequest(string EncapsulatedRequest){
			//this is an odd placement for CurrentContext but it has to do with static modifiers 
			//DEAL WIT IT (same goes
			Context CurrentContext = Context.Instance;
			CurrentContext.CurrentState = CurrentContext.StateTable["SongSelection"];
			Console.WriteLine(CurrentContext.CurrentState.ToString());
		}
	}
}

