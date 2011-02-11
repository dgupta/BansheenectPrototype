using System;
using System.Collections;
namespace BanshenectPrototype
{
	public class Context
	{
		private IState CurrentState {get; set;}
		/// <summary>
		/// should probably make a hashtable of all the possible states
		/// WHY: Because this will allow me to have one and only one set of states to load (in fact the state pattern might require this in some
		/// sense)
		/// It is in fact required.... the UML wants an aggregate of States
		/// </summary>
		
		// hashtable of states -->> declaration of states happens at construction
		private Hashtable StateTable {get; set;}
		
		
		
		
		// null constructor 
		public Context ()
		{
		}
		
		//state constructor
		public Context(IState state){
			CurrentState = state;
		}
				
		
		public void ChangeState(string EncapsulatedRequest){
			CurrentState.HandleRequest(EncapsulatedRequest);
		}
		
		//private creation of hashtable
		private void BuildHash(){
		}
		
	}
}

