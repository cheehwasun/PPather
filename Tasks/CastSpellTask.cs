/*
  This file is part of PPather.

    PPather is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    PPather is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with PPather.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Collections.Generic;
using System.Text;

using Glider.Common.Objects;
using Pather;
using Pather.Activities;
using Pather.Graph;
using Pather.Parser;

namespace Pather.Tasks
{
	class CastSpellTask : ActivityFreeTask
	{
		string spell;
		bool done = false;
		public CastSpellTask(PPather pather, NodeTask node)
			: base(pather, node)
		{
			Value v = nodetask.GetValueOfId("Key");
			if (v == null)
				spell = "";
			else
				spell = v.GetStringValue();
		}

		public override void GetParams(List<string> l)
		{
			l.Add("Key");
			base.GetParams(l);
		}

		public override string ToString()
		{
			return "Casting Spell: " + spell;
		}

		public override Location GetLocation()
		{
			return null;
		}

		public override void Restart()
		{
			done = false;
		}
		public override bool IsFinished()
		{
			return done;
		}

		public override bool WantToDoSomething()
		{
			return !done;
		}

		public override bool DoActivity()
		{
			GContext.Main.CastSpell(spell);
			return true; // done
		}

		public override bool ActivityDone(Activity task)
		{
			done = true;
			return true;
		}
	}
}
