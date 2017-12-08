using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;

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

	[Test]
	public void T05Bowl22LastFrame()
	{
		ActionMaster actionMaster = new ActionMaster ();
		BowlToEndFrame (actionMaster);

		Assert.AreEqual(tidy, actionMaster.Bowl (2));
		Assert.AreEqual(endGame, actionMaster.Bowl (2));
	}

	[Test]
	public void T06Bowl5510LastFrame()
	{
		ActionMaster actionMaster = new ActionMaster ();
		BowlToEndFrame (actionMaster);

		Assert.AreEqual(tidy, actionMaster.Bowl (5));
		Assert.AreEqual(reset, actionMaster.Bowl (5));
		Assert.AreEqual(endGame, actionMaster.Bowl (10));
	}

	[Test]
	public void T07Bowl101010LastFrame()
	{
		ActionMaster actionMaster = new ActionMaster ();
		BowlToEndFrame (actionMaster);

		Assert.AreEqual(reset, actionMaster.Bowl (10));
		Assert.AreEqual(reset, actionMaster.Bowl (10));
		Assert.AreEqual(endGame, actionMaster.Bowl (10));
	}

	[Test]
	public void T08Bowl10101LastFrame()
	{
		ActionMaster actionMaster = new ActionMaster ();
		BowlToEndFrame (actionMaster);

		Assert.AreEqual(reset, actionMaster.Bowl (10));
		Assert.AreEqual(reset, actionMaster.Bowl (10));
		Assert.AreEqual(endGame, actionMaster.Bowl (1));
	}

	[Test]
	public void T09Bowl1021LastFrame()
	{
		ActionMaster actionMaster = new ActionMaster ();
		BowlToEndFrame (actionMaster);

		Assert.AreEqual(reset, actionMaster.Bowl (10));
		Assert.AreEqual(tidy, actionMaster.Bowl (2));
		Assert.AreEqual(endGame, actionMaster.Bowl (1));
	}

	[Test]
	public void T10Bowl1001LastFrame()
	{
		ActionMaster actionMaster = new ActionMaster ();
		BowlToEndFrame (actionMaster);

		Assert.AreEqual(reset, actionMaster.Bowl (10));
		Assert.AreEqual(tidy, actionMaster.Bowl (0));
		Assert.AreEqual(endGame, actionMaster.Bowl (1));
	}

	[Test]
	public void T11Bowl010010()
	{
		ActionMaster actionMaster = new ActionMaster ();

		Assert.AreEqual(tidy, actionMaster.Bowl (0));
		Assert.AreEqual(endTurn, actionMaster.Bowl (10));
		Assert.AreEqual(tidy, actionMaster.Bowl (0));
		Assert.AreEqual(endTurn, actionMaster.Bowl (10));
	}

	[Test]
	public void T12BowlTurkeyLastFrame()
	{
		ActionMaster actionMaster = new ActionMaster ();

		BowlToEndFrame (actionMaster);

		Assert.AreEqual(reset, actionMaster.Bowl (10));
		Assert.AreEqual(reset, actionMaster.Bowl (10));
		Assert.AreEqual(endGame, actionMaster.Bowl (1));
	}

	private void BowlToEndFrame(ActionMaster actionMaster)
	{
		actionMaster.Bowl (3);
		actionMaster.Bowl (4);

		actionMaster.Bowl (3);
		actionMaster.Bowl (4);

		actionMaster.Bowl (3);
		actionMaster.Bowl (4);

		actionMaster.Bowl (3);
		actionMaster.Bowl (4);

		actionMaster.Bowl (3);
		actionMaster.Bowl (4);

		actionMaster.Bowl (3);
		actionMaster.Bowl (4);

		actionMaster.Bowl (3);
		actionMaster.Bowl (4);

		actionMaster.Bowl (3);
		actionMaster.Bowl (4);

		actionMaster.Bowl (3);
		actionMaster.Bowl (4);
	}
}