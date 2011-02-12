using System;
using System.Collections;

//needs to a be singleton ( all state objects need to be able to access this from a single point)
namespace BanshenectPrototype
{
	public static class Context
	{
		static Context instance = null;
		static readonly Object locking = new Object();
		
		
		
		IState CurrentState {get; set;}
		/// <summary>
		/// should probably make a hashtable of all the possible states
		/// WHY: Because this will allow me to have one and only one set of states to load (in fact the state pattern might require this in some
		/// sense)
		/// It is in fact required.... the UML wants an aggregate of States
		/// </summary>
		
		// hashtable of states -->> declaration of states happens at construction
		Hashtable StateTable {get; set;}
		
		
		
		
		// null constructor 
		Context ()
		{
		}
		
		
		//the getter for the singleton
		public static Context Instance{
			
			get{
				lock(locking){
					if(instance == null){
						instance = new Context();
					}
					return instance;
				}
			}
		}
		

		public void ChangeState(string EncapsulatedRequest){
			CurrentState.HandleRequest(EncapsulatedRequest);
		}
		
		//private creation of hashtable
		private void BuildHash(){
		}
		
	}
}

