using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epic_Spell_Wars_Library
{
    public class Question 
    {
        private sealed string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string[] variantsAnswer;

        public string[] VariantsAnswer
        {
            get { return variantsAnswer; }
            set { variantsAnswer = value; }
        }
    }
}
