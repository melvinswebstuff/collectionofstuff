using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Abstract.Factory
{
    class Documents
    {
    }

    class FancyLetter : Letter
    {
        public override void Write()
        {
            throw new NotImplementedException();
        }
    }

    class ModernResume : Resume
    {
        public override void Write()
        {
            throw new NotImplementedException();
        }
    }

    abstract class Letter
    {
        public abstract void Write();
    }

    abstract class Resume
    {
        public abstract void Write();
    }
}
