using System;
namespace BanshenectPrototype
{
	public class ControlerState :IState
	{
		public ControlerState ()
		{
		}
		
		#region IState implementation
		public void IState.HandleRequest (string EncapsulatedRequest)
		{
			throw new NotImplementedException ();
		}
		#endregion

	}
}

