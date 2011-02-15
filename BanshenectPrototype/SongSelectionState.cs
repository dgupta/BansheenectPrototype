using System;
namespace BanshenectPrototype
{
	public class SongSelectionState : IState
	{
		
		
		public SongSelectionState ()
		{
		}
		
		public void HandleRequest(string EncapsulatedRequest){
			Context CurrentContext = Context.Instance;
			CurrentContext.CurrentState = CurrentContext.StateTable["NowPlaying"];
			Console.WriteLine(CurrentContext.CurrentState.ToString());
		}
	}
}

