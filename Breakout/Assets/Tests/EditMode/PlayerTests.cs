using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests
{
    public Player player = new Player();

    [Test]
    public void PlayerTestRight()
    {
        Assert.AreEqual(new Vector2(1, 0), Vector2.right);
    }

    [Test]
    public void PlayerTestLeft()
    {
        Assert.AreEqual(new Vector2(-1, 0), Vector2.left);
    }
}
