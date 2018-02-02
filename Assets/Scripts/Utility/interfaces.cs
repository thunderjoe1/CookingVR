﻿/*******************************************************************************************************
Class Name:     interfaces
Author’s Name:  Thunder Clonch
Created Date:   10/12/2017
Description:    Script which stores our interfaces.

Last Edited:
Last Editor:
Last Edit Description:

*******************************************************************************************************/
using System.Collections;
using UnityEngine;

//Interface that says that an object can be heated.E.g. is cookable on a flat top.
public interface IHeatable
{
	void Heat(Structs.cooked cooked, float heatPerSecond);
	void currentCookedValue ();
}

public interface ITenderizable
{
    void Tenderize();
}

public interface ISeasonable {
	void Season (Structs.seasoned seasoned);
}