using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epic_Spell_Wars_Library
{
    public class Question 
    {
        private string text;
        private string[] variantsAnswer;
        private sbyte[] answerer;        

        public string Text
        {
            get { return text; }
            set { text = value; }
        }       

        public string[] VariantsAnswer
        {
            get { return variantsAnswer; }
            set { variantsAnswer = value; }
        }

        public sbyte[] Answerer
        {
            get { return answerer; }
            set { answerer = value; }
        }        
    }
}
