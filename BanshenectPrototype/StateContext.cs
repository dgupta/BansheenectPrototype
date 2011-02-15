using System;
using System.Collections.Generic;

//needs to a be singleton ( all state objects need to be able to access this from a single point)
namespace BanshenectPrototype
{
	public class StateContext
	{
		private static readonly StateContext instance = new StateContext();
		

		public IState CurrentState {get; set;}
		/// <summary>
		/// should probably make a hashtable of all the possible states
		/// WHY: Because this will allow me to have one and only one set of states to load (in fact the state pattern might require this in some
		/// sense)
		/// It is in fact required.... the UML wants an aggregate of States
		/// </summary>
		
		// hashtable of states -->> declaration of states happens at construction
		public Dictionary<String,IState> StateTable {get; set;}
		
		
		
		
		// private constructor for the singleton 
		private StateContext ()
		{
			
			BuildHash();
			//default state
			CurrentState = StateTable["NowPlaying"];
			
		}
		
		
		//the getter for the singleton
		public static StateContext Instance{
			get{
				return instance;
			}
		}
		
		

		public void ChangeState(string EncapsulatedRequest){
			CurrentState.HandleRequest(EncapsulatedRequest);
		}
		
		//private creation of hashtable
		void BuildHash(){
			StateTable = new Dictionary<string, IState>();
			StateTable.Add("NowPlaying",new NowPlayingState());
			StateTable.Add("SongSelection", new SongSelectionState());
		}
	}
}

