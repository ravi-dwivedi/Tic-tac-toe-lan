using System;

namespace Ravi
{

	public class GameAI
	{
		
		private enPlayType wTypeCPU;
		private enPlayType wTypePlayer;
		private enDifficulty wDifficulty;
		frmTicTacToe objTicTacToe;

		#region잺onstructor 

		public GameAI(frmTicTacToe objForm)
		{
		
			//_____________________________________________________________________________________________
			//
			// Gets main form reference, who is CPU, who is player and
			// difficulty
			//_____________________________________________________________________________________________

			objTicTacToe=objForm;
			wTypeCPU=objTicTacToe.wTypeCPU;
			wTypePlayer=objTicTacToe.wTypePlayer;
			wDifficulty=objTicTacToe.wDifficulty;

		}


		#endregion

		#region쟃ame (1 player) 

		public void MakeComputerMove()
		{

			//_____________________________________________________________________________________________
			//
			// CPU plays
			//_____________________________________________________________________________________________

			bool wNothing=false;

			//_____________________________________________________________________________________________
			//
			// Return if it is not CPU turn
			//_____________________________________________________________________________________________

			if (objTicTacToe.wTurn==wTypePlayer)
				return;

			//_____________________________________________________________________________________________
			//
			// Routine to check if it is possible to win the game
			// Return if a move was made
			//_____________________________________________________________________________________________

			PlayWinner(false,ref wNothing);

			if (objTicTacToe.wTurn==wTypePlayer)
				return;

			//_____________________________________________________________________________________________
			//
			// Routine to check if there is a move that prevents the player to win
			// Return if a move was made
			//_____________________________________________________________________________________________

			PlayDefensive();

			if (objTicTacToe.wTurn==wTypePlayer)
				return;

			//_____________________________________________________________________________________________
			//
			// Routine to make and avoid "traps"
			//_____________________________________________________________________________________________

			PlayOffensive();

		}
	
		private void PlayWinner(bool pJustVerifyMove,ref bool rGoodMove)
		{
			//_____________________________________________________________________________________________
			//
			// Routine to check if it is possible to win the game
			// (sums lines and check totals latter)
			//_____________________________________________________________________________________________

			if (wDifficulty==enDifficulty.Average)
			{
				rGoodMove=true;
				return;
			}

			int wSum1=(int)objTicTacToe.wBoard[1,1]+(int)objTicTacToe.wBoard[1,2]+(int)objTicTacToe.wBoard[1,3];
			int wSum2=(int)objTicTacToe.wBoard[2,1]+(int)objTicTacToe.wBoard[2,2]+(int)objTicTacToe.wBoard[2,3];
			int wSum3=(int)objTicTacToe.wBoard[3,1]+(int)objTicTacToe.wBoard[3,2]+(int)objTicTacToe.wBoard[3,3];

			int wSum4=(int)objTicTacToe.wBoard[1,1]+(int)objTicTacToe.wBoard[2,1]+(int)objTicTacToe.wBoard[3,1];
			int wSum5=(int)objTicTacToe.wBoard[1,2]+(int)objTicTacToe.wBoard[2,2]+(int)objTicTacToe.wBoard[3,2];
			int wSum6=(int)objTicTacToe.wBoard[1,3]+(int)objTicTacToe.wBoard[2,3]+(int)objTicTacToe.wBoard[3,3];

			int wSum7=(int)objTicTacToe.wBoard[1,1]+(int)objTicTacToe.wBoard[2,2]+(int)objTicTacToe.wBoard[3,3];
			int wSum8=(int)objTicTacToe.wBoard[3,1]+(int)objTicTacToe.wBoard[2,2]+(int)objTicTacToe.wBoard[1,3];

			//_____________________________________________________________________________________________
			//
			// Calculates sum that indicates a good move for CPU 
			//_____________________________________________________________________________________________

			int wCPUSum=0;

			if (wTypeCPU==enPlayType.Cross)
				wCPUSum=20;
			else
				wCPUSum=2;

			//_____________________________________________________________________________________________
			//
			// If sum checks, plays in the available position to win the game
			//_____________________________________________________________________________________________

			if (wSum1==wCPUSum)
			{
				if (objTicTacToe.wBoard[1,1]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(1,1);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[1,2]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(1,2);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[1,3]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(1,3);
					rGoodMove=true;
					return;
				}
			}

			if (wSum2==wCPUSum)
			{
				if (objTicTacToe.wBoard[2,1]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(2,1);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[2,2]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(2,2);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[2,3]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(2,3);
					rGoodMove=true;
					return;
				}
			}

			if (wSum3==wCPUSum)
			{
				if (objTicTacToe.wBoard[3,1]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(3,1);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[3,2]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(3,2);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[3,3]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(3,3);
					rGoodMove=true;
					return;
				}
			}
			
			if (wSum4==wCPUSum)
			{
				if (objTicTacToe.wBoard[1,1]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(1,1);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[2,1]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(2,1);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[3,1]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(3,1);
					rGoodMove=true;
					return;
				}
			}

			if (wSum5==wCPUSum)
			{
				if (objTicTacToe.wBoard[1,2]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(1,2);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[2,2]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(2,2);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[3,2]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(3,2);
					rGoodMove=true;
					return;
				}
			}

			if (wSum6==wCPUSum)
			{
				if (objTicTacToe.wBoard[1,3]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(1,3);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[2,3]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(2,3);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[3,3]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(3,3);
					rGoodMove=true;
					return;
				}
			}

			if (wSum7==wCPUSum)
			{
				if (objTicTacToe.wBoard[1,1]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(1,1);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[2,2]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(2,2);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[3,3]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(3,3);
					rGoodMove=true;
					return;
				}
			}

			if (wSum8==wCPUSum)
			{
				if (objTicTacToe.wBoard[3,1]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(3,1);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[2,2]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(2,2);
					rGoodMove=true;
					return;
				}
				if (objTicTacToe.wBoard[1,3]==enPlayType.None)
				{
					if (pJustVerifyMove==false)
						objTicTacToe.MakeMove(1,3);
					rGoodMove=true;
					return;
				}
			}

		}

		private void PlayDefensive()
		{
			//_____________________________________________________________________________________________
			//
			// Routine to check if there is a move that prevents the player to win
			// (sum lines and check totals latter)
			//_____________________________________________________________________________________________

			//_____________________________________________________________________________________________
			//
			// In easy and average difficulty sometimes it doesn뭪 make a defensive move
			//_____________________________________________________________________________________________

			if (wDifficulty==enDifficulty.Average)		
			{
				System.Threading.Thread.Sleep(15);
				System.Random objRandom=new Random();
				int rnd=objRandom.Next(1,6);
				if (rnd==3)
					return;
			}

			if (wDifficulty==enDifficulty.Easy)		
			{
				System.Threading.Thread.Sleep(15);
				System.Random objRandom=new Random();
				int rnd=objRandom.Next(1,3);
				if (rnd==1)
					return;
			}

			//_____________________________________________________________________________________________
			//
			// Sums lines and check totals latter
			//_____________________________________________________________________________________________
			
			int wSum1=(int)objTicTacToe.wBoard[1,1]+(int)objTicTacToe.wBoard[1,2]+(int)objTicTacToe.wBoard[1,3];
			int wSum2=(int)objTicTacToe.wBoard[2,1]+(int)objTicTacToe.wBoard[2,2]+(int)objTicTacToe.wBoard[2,3];
			int wSum3=(int)objTicTacToe.wBoard[3,1]+(int)objTicTacToe.wBoard[3,2]+(int)objTicTacToe.wBoard[3,3];

			int wSum4=(int)objTicTacToe.wBoard[1,1]+(int)objTicTacToe.wBoard[2,1]+(int)objTicTacToe.wBoard[3,1];
			int wSum5=(int)objTicTacToe.wBoard[1,2]+(int)objTicTacToe.wBoard[2,2]+(int)objTicTacToe.wBoard[3,2];
			int wSum6=(int)objTicTacToe.wBoard[1,3]+(int)objTicTacToe.wBoard[2,3]+(int)objTicTacToe.wBoard[3,3];

			int wSum7=(int)objTicTacToe.wBoard[1,1]+(int)objTicTacToe.wBoard[2,2]+(int)objTicTacToe.wBoard[3,3];
			int wSum8=(int)objTicTacToe.wBoard[3,1]+(int)objTicTacToe.wBoard[2,2]+(int)objTicTacToe.wBoard[1,3];

			//_____________________________________________________________________________________________
			//
			// Calculates sum that indicates two piecies in a row for human player
			//_____________________________________________________________________________________________

			int wPlayerSum=0;

			if (wTypePlayer==enPlayType.Cross)
				wPlayerSum=20;
			else
				wPlayerSum=2;

			//_____________________________________________________________________________________________
			//
			// If sum checks, plays in the available position preventing player to win
			//_____________________________________________________________________________________________

			if (wSum1==wPlayerSum)
			{
				if (objTicTacToe.wBoard[1,1]==enPlayType.None) {
					objTicTacToe.MakeMove(1,1);return;}
				if (objTicTacToe.wBoard[1,2]==enPlayType.None) {
					objTicTacToe.MakeMove(1,2);return;}
				if (objTicTacToe.wBoard[1,3]==enPlayType.None) {
					objTicTacToe.MakeMove(1,3);return;}
			}

			if (wSum2==wPlayerSum)
			{
				if (objTicTacToe.wBoard[2,1]==enPlayType.None) {
					objTicTacToe.MakeMove(2,1);return;}
				if (objTicTacToe.wBoard[2,2]==enPlayType.None) {
					objTicTacToe.MakeMove(2,2);return;}
				if (objTicTacToe.wBoard[2,3]==enPlayType.None) {
					objTicTacToe.MakeMove(2,3);return;}
			}

			if (wSum3==wPlayerSum)
			{
				if (objTicTacToe.wBoard[3,1]==enPlayType.None) {
					objTicTacToe.MakeMove(3,1);return;}
				if (objTicTacToe.wBoard[3,2]==enPlayType.None) {
					objTicTacToe.MakeMove(3,2);return;}
				if (objTicTacToe.wBoard[3,3]==enPlayType.None) {
					objTicTacToe.MakeMove(3,3);return;}
			}
			
			if (wSum4==wPlayerSum)
			{
				if (objTicTacToe.wBoard[1,1]==enPlayType.None) {
					objTicTacToe.MakeMove(1,1);return;}
				if (objTicTacToe.wBoard[2,1]==enPlayType.None) {
					objTicTacToe.MakeMove(2,1);return;}
				if (objTicTacToe.wBoard[3,1]==enPlayType.None) {
					objTicTacToe.MakeMove(3,1);return;}
			}

			if (wSum5==wPlayerSum)
			{
				if (objTicTacToe.wBoard[1,2]==enPlayType.None) {
					objTicTacToe.MakeMove(1,2);return;}
				if (objTicTacToe.wBoard[2,2]==enPlayType.None) {
					objTicTacToe.MakeMove(2,2);return;}
				if (objTicTacToe.wBoard[3,2]==enPlayType.None) {
					objTicTacToe.MakeMove(3,2);return;}
			}

			if (wSum6==wPlayerSum)
			{
				if (objTicTacToe.wBoard[1,3]==enPlayType.None) {
					objTicTacToe.MakeMove(1,3);return;}
				if (objTicTacToe.wBoard[2,3]==enPlayType.None) {
					objTicTacToe.MakeMove(2,3);return;}
				if (objTicTacToe.wBoard[3,3]==enPlayType.None) {
					objTicTacToe.MakeMove(3,3);return;}
			}

			if (wSum7==wPlayerSum)
			{
				if (objTicTacToe.wBoard[1,1]==enPlayType.None) {
					objTicTacToe.MakeMove(1,1);return;}
				if (objTicTacToe.wBoard[2,2]==enPlayType.None) {
					objTicTacToe.MakeMove(2,2);return;}
				if (objTicTacToe.wBoard[3,3]==enPlayType.None) {
					objTicTacToe.MakeMove(3,3);return;}
			}

			if (wSum8==wPlayerSum)
			{
				if (objTicTacToe.wBoard[3,1]==enPlayType.None) {
					objTicTacToe.MakeMove(3,1);return;}
				if (objTicTacToe.wBoard[2,2]==enPlayType.None) {
					objTicTacToe.MakeMove(2,2);return;}
				if (objTicTacToe.wBoard[1,3]==enPlayType.None) {
					objTicTacToe.MakeMove(1,3);return;}
			}
			
		}

		private void PlayOffensive()
		{
			//_____________________________________________________________________________________________
			//
			// Routine to make and avoid "traps"
			//_____________________________________________________________________________________________

			//_____________________________________________________________________________________________
			//
			// This routine works as follow:
			//
			//		- If player is O try in the middle
			//		- If player is X try playing in the inverse diagonal of the player
			//		  in case there is a player큦 piece on the corner
			//
			//		- If there is a player큦 piece in a corner 
			//		  try next to player큦 piece (HARD difficulty)
			//			- Try smart moves to avoid "traps" (HARD difficulty)
			//
			//		- Try on the corner
			//		  (checks in a random order if there is an available position)
			//		- Try on the sides
			//		- Try in the middle
			//
			//_____________________________________________________________________________________________
		
			bool wGoodMove=false;

			if (wDifficulty==enDifficulty.Hard)
			{
				if (wTypePlayer==enPlayType.Cross)
				{
				
					//_____________________________________________________________________________________________
					//
					//	If player is X try playing in the inverse diagonal of the player
					//	in case there is a player큦 piece on the corner
					//_____________________________________________________________________________________________
					
					if ((objTicTacToe.wBoard[1,1]==enPlayType.None) && (objTicTacToe.wBoard[3,3]==wTypePlayer))
					{
						objTicTacToe.MakeMove(1,1);
						return;
					}
									
					if ((objTicTacToe.wBoard[1,3]==enPlayType.None) && (objTicTacToe.wBoard[3,1]==wTypePlayer))
					{
						objTicTacToe.MakeMove(1,3);
						return;
					}
					
					if ((objTicTacToe.wBoard[3,1]==enPlayType.None) && (objTicTacToe.wBoard[1,3]==wTypePlayer))
					{
						objTicTacToe.MakeMove(3,1);
						return;
					}
					
					if ((objTicTacToe.wBoard[3,3]==enPlayType.None) && (objTicTacToe.wBoard[1,1]==wTypePlayer))
					{
						objTicTacToe.MakeMove(3,3);
						return;
					}
				}
				else
				{
					//_____________________________________________________________________________________________
					//
					// Try in the middle
					//_____________________________________________________________________________________________

					if (objTicTacToe.wBoard[2,2]==enPlayType.None)
					{
						objTicTacToe.MakeMove(2,2);
						return;
					}
				}
			}
			
			//_____________________________________________________________________________________________
			//
			// If there is a player큦 piece in a corner 
			// try next to player큦 piece (HARD difficulty)
			// Try smart moves to avoid "traps" (HARD difficulty)
			//_____________________________________________________________________________________________

			if (wDifficulty==enDifficulty.Hard)
			{
				
				//_____________________________________________________________________________________________
				// 
				// Moves:		 |M|O		 | |O 
				//				-----		-----
				//				 |X|		 |X|  
				//				-----		-----
				//				O| | 		O|M|
				//
				//
				//				O|M|		O| |   
				//				-----		-----
				//				 |X|		 |X| 
				//				-----		-----
				//				 | |O		 |M|O
				//
				//_____________________________________________________________________________________________

				if ((objTicTacToe.wBoard[1,2]==enPlayType.None) && ((objTicTacToe.wBoard[1,3]==wTypePlayer) && (objTicTacToe.wBoard[3,1]==wTypePlayer)))
				{
					objTicTacToe.wBoard[1,2]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[1,2]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(1,2);
						return;
					}
				}

				if ((objTicTacToe.wBoard[3,2]==enPlayType.None) && ((objTicTacToe.wBoard[1,3]==wTypePlayer) && (objTicTacToe.wBoard[3,1]==wTypePlayer)))
				{
					objTicTacToe.wBoard[3,2]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[3,2]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(3,2);
						return;
					}
				}

				if ((objTicTacToe.wBoard[1,2]==enPlayType.None) && ((objTicTacToe.wBoard[1,1]==wTypePlayer) && (objTicTacToe.wBoard[3,3]==wTypePlayer)))
				{
					objTicTacToe.wBoard[1,2]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[1,2]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(1,2);
						return;
					}
				}

				if ((objTicTacToe.wBoard[3,2]==enPlayType.None) && ((objTicTacToe.wBoard[1,1]==wTypePlayer) && (objTicTacToe.wBoard[3,3]==wTypePlayer)))
				{
					objTicTacToe.wBoard[3,2]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[3,2]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(3,2);
						return;
					}
				}
				

				//_____________________________________________________________________________________________
				// 
				// Moves:		 |M|		O| | 
				//				-----		-----
				//				O|X|		M|X|  
				//				-----		-----
				//				 | |O		 |O| 
				//
				//
				//				 | |O		 | |  
				//				-----		-----
				//				 |X|M		 |X|O 
				//				-----		-----
				//				 |O|		O|M| 
				//
				//_____________________________________________________________________________________________

				if ((objTicTacToe.wBoard[1,2]==enPlayType.None) && ((objTicTacToe.wBoard[2,1]==wTypePlayer) && (objTicTacToe.wBoard[3,3]==wTypePlayer)))
				{
					objTicTacToe.wBoard[1,2]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[1,2]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(1,2);
						return;
					}
				}

				if ((objTicTacToe.wBoard[2,1]==enPlayType.None) && ((objTicTacToe.wBoard[1,1]==wTypePlayer) && (objTicTacToe.wBoard[3,2]==wTypePlayer)))
				{
					objTicTacToe.wBoard[2,1]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[2,1]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(2,1);
						return;
					}
				}

				if ((objTicTacToe.wBoard[2,3]==enPlayType.None) && ((objTicTacToe.wBoard[1,3]==wTypePlayer) && (objTicTacToe.wBoard[3,2]==wTypePlayer)))
				{
					objTicTacToe.wBoard[2,3]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[2,3]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(2,3);
						return;
					}
				}

				if ((objTicTacToe.wBoard[3,2]==enPlayType.None) && ((objTicTacToe.wBoard[2,3]==wTypePlayer) && (objTicTacToe.wBoard[3,1]==wTypePlayer)))
				{
					objTicTacToe.wBoard[3,2]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[3,2]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(3,2);
						return;
					}
				}

				//_____________________________________________________________________________________________
				// 
				// Moves:		 |O|		O| | 
				//				-----		-----
				//				 |X|M		M|X|  
				//				-----		-----
				//				O| | 		 |O| 
				//_____________________________________________________________________________________________

				if ((objTicTacToe.wBoard[2,3]==enPlayType.None) && ((objTicTacToe.wBoard[3,1]==wTypePlayer) && (objTicTacToe.wBoard[1,2]==wTypePlayer)))
				{
					objTicTacToe.wBoard[2,3]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[2,3]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(2,3);
						return;
					}
				}

				if ((objTicTacToe.wBoard[2,1]==enPlayType.None) && ((objTicTacToe.wBoard[1,1]==wTypePlayer) && (objTicTacToe.wBoard[3,2]==wTypePlayer)))
				{
					objTicTacToe.wBoard[2,1]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[2,1]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(2,1);
						return;
					}
				}

				//_____________________________________________________________________________________________
				// 
				// Moves:		M|O|		 |O|M 
				//				-----		-----
				//				O|X|		 |X|O 
				//				-----		-----
				//				 | | 		 | |
				//
				//
				//				 | |		 | |   
				//				-----		-----
				//				 |X|O		O|X| 
				//				-----		-----
				//				 |O|M		M|O| 
				//
				//_____________________________________________________________________________________________

				if ((objTicTacToe.wBoard[1,1]==enPlayType.None) && ((objTicTacToe.wBoard[1,2]==wTypePlayer) && (objTicTacToe.wBoard[2,1]==wTypePlayer)))
				{
					objTicTacToe.wBoard[1,1]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[1,1]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(1,1);
						return;
					}
				}

				if ((objTicTacToe.wBoard[1,3]==enPlayType.None) && ((objTicTacToe.wBoard[1,2]==wTypePlayer) && (objTicTacToe.wBoard[2,3]==wTypePlayer)))
				{
					objTicTacToe.wBoard[1,3]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[1,3]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(1,3);
						return;
					}
				}

				if ((objTicTacToe.wBoard[3,3]==enPlayType.None) && ((objTicTacToe.wBoard[2,3]==wTypePlayer) && (objTicTacToe.wBoard[3,2]==wTypePlayer)))
				{
					objTicTacToe.wBoard[3,3]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[3,3]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(3,3);
						return;
					}
				}

				if ((objTicTacToe.wBoard[3,1]==enPlayType.None) && ((objTicTacToe.wBoard[2,1]==wTypePlayer) && (objTicTacToe.wBoard[3,2]==wTypePlayer)))
				{
					objTicTacToe.wBoard[3,1]=wTypeCPU;
					PlayWinner(true,ref wGoodMove);
					objTicTacToe.wBoard[3,1]=enPlayType.None;

					if (wGoodMove==true)
					{
						objTicTacToe.MakeMove(3,1);
						return;
					}
				}

			}

			//_____________________________________________________________________________________________
			//
			//	Try on the corner
			//	(checks in a random order if there is an available position)
			//_____________________________________________________________________________________________

			System.Threading.Thread.Sleep(15);
			System.Random objRandom=new Random();
			int rnd=objRandom.Next(1,5);

			int[] wPosicaoPontaX = new int[5];
			int[] wPosicaoPontaY = new int[5];
		
			if (rnd==1)
			{
				wPosicaoPontaX[1]=1;wPosicaoPontaY[1]=1;
				wPosicaoPontaX[2]=1;wPosicaoPontaY[2]=3;
				wPosicaoPontaX[3]=3;wPosicaoPontaY[3]=1;
				wPosicaoPontaX[4]=3;wPosicaoPontaY[4]=3;
			}
			if (rnd==2)
			{
				
				wPosicaoPontaX[1]=1;wPosicaoPontaY[1]=3;
				wPosicaoPontaX[2]=3;wPosicaoPontaY[2]=1;
				wPosicaoPontaX[3]=3;wPosicaoPontaY[3]=3;
				wPosicaoPontaX[4]=1;wPosicaoPontaY[4]=1;
			}
			if (rnd==3)
			{
			
				wPosicaoPontaX[1]=3;wPosicaoPontaY[1]=1;
				wPosicaoPontaX[2]=3;wPosicaoPontaY[2]=3;
				wPosicaoPontaX[3]=1;wPosicaoPontaY[3]=1;
				wPosicaoPontaX[4]=1;wPosicaoPontaY[4]=3;
			}
			if (rnd==4)
			{
				
				wPosicaoPontaX[1]=3;wPosicaoPontaY[1]=3;
				wPosicaoPontaX[2]=1;wPosicaoPontaY[2]=1;
				wPosicaoPontaX[3]=1;wPosicaoPontaY[3]=3;
				wPosicaoPontaX[4]=3;wPosicaoPontaY[4]=1;
			}
			
			if (objTicTacToe.wBoard[wPosicaoPontaX[1],wPosicaoPontaY[1]]==enPlayType.None)
			{
				objTicTacToe.MakeMove(wPosicaoPontaX[1],wPosicaoPontaY[1]);
				return;
			}
		
			if (objTicTacToe.wBoard[wPosicaoPontaX[2],wPosicaoPontaY[2]]==enPlayType.None)
			{
				objTicTacToe.MakeMove(wPosicaoPontaX[2],wPosicaoPontaY[2]);
				return;
			}
		
			if (objTicTacToe.wBoard[wPosicaoPontaX[3],wPosicaoPontaY[3]]==enPlayType.None)
			{
				objTicTacToe.MakeMove(wPosicaoPontaX[3],wPosicaoPontaY[3]);
				return;
			}
		
			if (objTicTacToe.wBoard[wPosicaoPontaX[4],wPosicaoPontaY[4]]==enPlayType.None)
			{
				objTicTacToe.MakeMove(wPosicaoPontaX[4],wPosicaoPontaY[4]);
				return;
			}

			//_____________________________________________________________________________________________
			//
			// Try on the sides
			//_____________________________________________________________________________________________

			if (objTicTacToe.wBoard[1,2]==enPlayType.None)
			{
				objTicTacToe.MakeMove(1,2);
				return;
			}

			if (objTicTacToe.wBoard[2,1]==enPlayType.None)
			{
				objTicTacToe.MakeMove(2,1);
				return;
			}

			if (objTicTacToe.wBoard[2,3]==enPlayType.None)
			{
				objTicTacToe.MakeMove(2,3);
				return;
			}

			if (objTicTacToe.wBoard[3,2]==enPlayType.None)
			{
				objTicTacToe.MakeMove(3,2);
				return;
			}

			//_____________________________________________________________________________________________
			//
			// Try in the middle
			//_____________________________________________________________________________________________

			if (objTicTacToe.wBoard[2,2]==enPlayType.None)
			{
				objTicTacToe.MakeMove(2,2);
				return;
			}

		}

		#endregion

	}
}
