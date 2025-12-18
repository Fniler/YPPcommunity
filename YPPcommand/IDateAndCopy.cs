using System;
using System.Collections.Generic;
using System.Text;

interface IDateAndCopy
{
    object DeepCopy();
    DateTime Date { get; set; }
}
