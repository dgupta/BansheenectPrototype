using System;
namespace BanshenectPrototype
{
	public interface IState
	{
		void HandleRequest(string EncapsulatedRequest);
	}
}

