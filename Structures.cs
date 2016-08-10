using System;

namespace Ravi
{
	#region Data Structures 

	//_____________________________________________________________________________________________
	//
	// Indicates the type of move
	//_____________________________________________________________________________________________

	public enum enPlayType
	{
		None=0,
		Ball=1,
		Cross=10
	}

	//_____________________________________________________________________________________________
	//
	// Indicates CPU AI difficulty
	//_____________________________________________________________________________________________

	public enum enDifficulty
	{
		Easy=0,
		Average=1,
		Hard=2
	}

	//_____________________________________________________________________________________________
	//
	// Indicates the type of line to draw in case of a winner
	//_____________________________________________________________________________________________

	public enum enLineType
	{
		Vertical=0,
		Horizontal=1,
		DiagonalRight=2,
		DiagonalLeft=3
	}

	#endregion
}
