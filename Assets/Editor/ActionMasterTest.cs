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
		List<int> rolls = new List<int> ();
		rolls.Add (10);
		Assert.AreEqual(endTurn, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T02Bowl8ReturnsTidy()
	{
		List<int> rolls = new List<int> ();
		rolls.Add (8);
		Assert.AreEqual(tidy, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T03SpareReturnsEndTurn()
	{
		List<int> rolls = new List<int> ();
		rolls.Add (8);
		Assert.AreEqual(tidy, ActionMaster.NextAction (rolls));

		rolls.Add (2);
		Assert.AreEqual(endTurn, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T04Bowl3And4ReturnsEndTurn()
	{
		List<int> rolls = new List<int> ();
		rolls.Add (3);
		Assert.AreEqual(tidy, ActionMaster.NextAction (rolls));
		rolls.Add (4);
		Assert.AreEqual(endTurn, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T05Bowl22LastFrame()
	{
		List<int> rolls = new List<int> ();
		rolls = BowlToEndFrame (rolls);

		rolls.Add (2);
		Assert.AreEqual(tidy, ActionMaster.NextAction (rolls));

		rolls.Add (2);
		Assert.AreEqual(endGame, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T06Bowl5510LastFrame()
	{
		List<int> rolls = new List<int> ();
		rolls = BowlToEndFrame (rolls);

		rolls.Add (5);
		Assert.AreEqual(tidy, ActionMaster.NextAction (rolls));

		rolls.Add (5);
		Assert.AreEqual(reset, ActionMaster.NextAction (rolls));

		rolls.Add (10);
		Assert.AreEqual(endGame, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T07Bowl101010LastFrame()
	{
		List<int> rolls = new List<int> ();
		rolls = BowlToEndFrame (rolls);

		rolls.Add (10);
		Assert.AreEqual(reset, ActionMaster.NextAction (rolls));

		rolls.Add (10);
		Assert.AreEqual(reset, ActionMaster.NextAction (rolls));

		rolls.Add (10);
		Assert.AreEqual(endGame, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T08Bowl10101LastFrame()
	{
		List<int> rolls = new List<int> ();
		rolls = BowlToEndFrame (rolls);

		rolls.Add (10);
		Assert.AreEqual(reset, ActionMaster.NextAction (rolls));

		rolls.Add (10);
		Assert.AreEqual(reset, ActionMaster.NextAction (rolls));

		rolls.Add (10);
		Assert.AreEqual(endGame, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T09Bowl1021LastFrame()
	{
		List<int> rolls = new List<int> ();
		rolls = BowlToEndFrame (rolls);

		rolls.Add (10);
		Assert.AreEqual(reset, ActionMaster.NextAction (rolls));

		rolls.Add (2);
		Assert.AreEqual(tidy, ActionMaster.NextAction (rolls));

		rolls.Add (1);
		Assert.AreEqual(endGame, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T10Bowl1001LastFrame()
	{
		List<int> rolls = new List<int> ();
		rolls = BowlToEndFrame (rolls);

		rolls.Add (10);
		Assert.AreEqual(reset, ActionMaster.NextAction (rolls));

		rolls.Add (0);
		Assert.AreEqual(tidy, ActionMaster.NextAction (rolls));

		rolls.Add (1);
		Assert.AreEqual(endGame, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T11Bowl010010()
	{
		List<int> rolls = new List<int> ();

		rolls.Add (0);
		Assert.AreEqual(tidy, ActionMaster.NextAction (rolls));

		rolls.Add (10);
		Assert.AreEqual(endTurn, ActionMaster.NextAction (rolls));

		rolls.Add (0);
		Assert.AreEqual(tidy, ActionMaster.NextAction (rolls));

		rolls.Add (10);
		Assert.AreEqual(endTurn, ActionMaster.NextAction (rolls));
	}

	[Test]
	public void T12BowlTurkeyLastFrame()
	{
		List<int> rolls = new List<int> ();
		rolls = BowlToEndFrame (rolls);

		rolls.Add (10);
		Assert.AreEqual(reset, ActionMaster.NextAction (rolls));

		rolls.Add (10);
		Assert.AreEqual(reset, ActionMaster.NextAction (rolls));

		rolls.Add (1);
		Assert.AreEqual(endGame, ActionMaster.NextAction (rolls));
	}

	private List<int> BowlToEndFrame(List<int> rolls)
	{
		rolls.Add (3);
		rolls.Add (4);

		rolls.Add (3);
		rolls.Add (4);

		rolls.Add (3);
		rolls.Add (4);

		rolls.Add (3);
		rolls.Add (4);

		rolls.Add (3);
		rolls.Add (4);

		rolls.Add (3);
		rolls.Add (4);

		rolls.Add (3);
		rolls.Add (4);

		rolls.Add (3);
		rolls.Add (4);

		rolls.Add (3);
		rolls.Add (4);

		return rolls;
	}
}