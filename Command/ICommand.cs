using System;
using System.Collections.Generic;
using System.Text;

namespace TrainRoute.Command
{
    interface ICommand
    {
        void Execute(string input);
    }
}
