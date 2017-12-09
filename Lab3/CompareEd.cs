using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	class CompareEd : IComparer<Edition>
	{
		 int IComparer<Edition>.Compare(Edition x, Edition y)
		{
			Magazine x1 = x as Magazine;
			Magazine y1 = y as Magazine;
			if (x1.InformationListOfArticles[0].Rate < y1.InformationListOfArticles[0].Rate)
				return 1;
			if (x1.InformationListOfArticles[0].Rate > y1.InformationListOfArticles[0].Rate)
				return -1;
			return 0;
		}
	}
}
