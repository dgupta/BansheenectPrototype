using System;
namespace BanshenectPrototype
{
	public class AddingState : IState
	{
		public AddingState ()
		{
		}
	

		#region IState implementation
		void IState.HandleRequest (string EncapsulatedRequest)
		{
			throw new NotImplementedException ();
		}
		#endregion
}
}

