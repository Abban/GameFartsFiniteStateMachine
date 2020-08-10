using System;

namespace GF.Library.FSM
{
	public interface IState
	{
		/// <summary>
		/// When this state is entered
		/// </summary>
		/// <param name="lastState"></param>
		void Start(Type lastState);
		
		
		/// <summary>
		/// Run this once a frame
		/// </summary>
		void Update();
		
		
		/// <summary>
		/// When this state is exited
		/// </summary>
		void Exit();
		
		
		/// <summary>
		/// Check if this state is allowed to move to another
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		bool CanMoveToState(Type type);
	}
}