using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Linq;

[TestFixture]
public class ScoreMasterTest {
	[SetUp]
	public void Setup() {
		//rolls = new int[];
	}

	[Test]
	public void PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Roll1 () {
		int[] rolls = {1};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (0, scores.Count);
	}

	[Test]
	public void T02Roll11 () {
		int[] rolls = {1, 1};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (2, scores[scores.Count - 1]);
	}

	[Test]
	public void T03Roll54321 () {
		int[] rolls = {5, 4, 3, 2, 1};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (14, scores[scores.Count - 1]);
	}

	[Test]
	public void T04RollX11 () {
		int[] rolls = {10, 1, 1};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (14, scores[scores.Count - 1]);
	}

	[Test]
	public void T05RollXX11 () {
		int[] rolls = {10, 10, 1, 1};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (35, scores[scores.Count - 1]);
	}

	[Test]
	public void T06RollXXX () {
		int[] rolls = {10, 10, 10};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (30, scores[scores.Count - 1]);
	}

	[Test]
	public void T07Roll911 () {
		int[] rolls = {9, 1, 1};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (11, scores[scores.Count - 1]);
	}

	[Test]
	public void T08Roll9119XX54 () {
		int[] rolls = {9, 1,  1, 9,  10,  10,  5, 4};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (84, scores[scores.Count - 1]);
	}

	[Test]
	public void T09Roll1128 () {
		int[] rolls = {1, 1, 2, 8};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (2, scores[scores.Count - 1]);
	}

	[Test]
	public void T10Perfect () {
		int[] rolls = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (300, scores[scores.Count - 1]);
	}

	[Test]
	public void T11AlmostPerfect () {
		int[] rolls = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 5};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (295, scores[scores.Count - 1]);
	}

	[Test]
	public void T12LastFrame54 () {
		int[] rolls = {10, 10, 10, 10, 10, 10, 10, 10, 10, 5, 4};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (263, scores[scores.Count - 1]);
	}

	[Test]
	public void T13LastFrameX42 () {
		int[] rolls = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 4, 2};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (280, scores[scores.Count - 1]);
	}

	[Test]
	public void T14MiscScores () {
		int[] rolls = {4, 5,  10,  4, 6,  3, 1,  10,  10,  8, 0,  9, 1,  10,  6, 0};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (142, scores[scores.Count - 1]);
	}

	[Test]
	public void T15MiscScoresSpare () {
		int[] rolls = {4, 5,  10,  4, 6,  3, 1,  10,  10,  8, 0,  9, 1,  10,  6, 4, 2};

		List<int> scores = ScoreMaster.scoreCumulative(rolls.ToList());

		Assert.AreEqual (152, scores[scores.Count - 1]);
	}
}