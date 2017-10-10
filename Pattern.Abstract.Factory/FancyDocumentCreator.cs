using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Abstract.Factory
{
    class FancyDocumentCreator : DocumentCreator
    {
        public override Letter CreateLetter()
        {
            return new FancyLetter();
        }

        public override Resume CreateResume()
        {
            throw new NotImplementedException();
        }
    }
}
