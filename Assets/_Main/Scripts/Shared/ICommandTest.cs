using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICommandTest 
{
    public void Execute(object parameter);
    public void Undo(object parameter);
}
