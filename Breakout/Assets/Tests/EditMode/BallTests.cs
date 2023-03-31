using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BallTests
{
    public Ball ball = new Ball();

    [Test]
    public void BallSpeedTest()
    {
        Assert.AreEqual(10f, ball.speed);
    }
}
