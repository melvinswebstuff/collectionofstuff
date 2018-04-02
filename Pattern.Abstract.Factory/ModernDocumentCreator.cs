using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Abstract.Factory
{
    class ModernDocumentCreator : DocumentCreator
    {
        public override Letter CreateLetter()
        {
            return new FancyLetter();
        }

        public override Resume CreateResume()
        {
            return new ModernResume();
        }
    }
}
