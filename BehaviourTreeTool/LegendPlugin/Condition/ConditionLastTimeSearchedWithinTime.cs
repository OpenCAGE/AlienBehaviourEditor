////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2009, Daniel Kollmann
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
//
// - Redistributions of source code must retain the above copyright notice, this list of conditions
//   and the following disclaimer.
//
// - Redistributions in binary form must reproduce the above copyright notice, this list of
//   conditions and the following disclaimer in the documentation and/or other materials provided
//   with the distribution.
//
// - Neither the name of Daniel Kollmann nor the names of its contributors may be used to endorse
//   or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY
// WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using Brainiac.Design.Nodes;
using Brainiac.Design.Attributes;
using LegendPlugin.Properties;

namespace LegendPlugin.Nodes
{
	public class ConditionLastTimeSearchedWithinTime : ConditionConnectors
	{
        //All parameters added

        private string _cond4 = "";

        [DesignerString("Time constraint", "TimeConstraint", "CategoryBasic", DesignerProperty.DisplayMode.Parameter, 0, DesignerProperty.DesignerFlags.NoFlags)]
        public string TimeConstraint
        {
            get { return _cond4; }
            set { _cond4 = value; }
        }

        public ConditionLastTimeSearchedWithinTime()
            : base("LastTimeSearchedWithinTime", "WAS THE LAST TIME WE SEARCHED AROUND WITHIN A SPECIFIED TIME CONSTRAINT?")
 
        {
        }

        protected override void CloneProperties(Node newnode)
        {
            base.CloneProperties(newnode);

            ConditionLastTimeSearchedWithinTime cond = (ConditionLastTimeSearchedWithinTime)newnode;
            cond._cond4 = _cond4;
        }
    }
}
