using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;

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

	[Test]
	public void T02Bowl8ReturnsTidy()
	{
		ActionMaster actionMaster = new ActionMaster ();
		Assert.AreEqual(tidy, actionMaster.Bowl (8));
	}

	[Test]
	public void T03SpareReturnsEndTurn()
	{
		ActionMaster actionMaster = new ActionMaster ();
		Assert.AreEqual(tidy, actionMaster.Bowl (8));
		Assert.AreEqual(endTurn, actionMaster.Bowl (2));
	}

	[Test]
	public void T04Bowl3And4ReturnsEndTurn()
	{
		ActionMaster actionMaster = new ActionMaster ();
		Assert.AreEqual(tidy, actionMaster.Bowl (3));
		Assert.AreEqual(endTurn, actionMaster.Bowl (4));
	}
}