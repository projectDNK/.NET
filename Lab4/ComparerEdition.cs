using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	class ComparerEdition : IComparer<Edition>
	{
		public int Compare(Edition firstEdition, Edition secondEdition)
		{
			if (firstEdition.CirculationEdition > secondEdition.CirculationEdition)
				return 1;
			else if (firstEdition.CirculationEdition < secondEdition.CirculationEdition)
				return -1;
			else
				return 0;
		}
	}
}
