using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;

	[Test]
	public void PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01StrikeReturnsEndTurn()
	{
		ActionMaster actionMaster = new ActionMaster ();
		Assert.AreEqual(endTurn, actionMaster.Bowl (10));
	}
}