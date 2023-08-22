using System;
using Shouldly;
using Trivia;
using Xunit;

public class Game_should
{
    const string playerName = "playerName";
    const string playerName2 = "playerName2";
    const string playerName3 = "playerName3";
    const string playerName4 = "playerName4";
    const string playerName5 = "playerName5";
    [Theory]
    [InlineData(1,playerName)]
    [InlineData(2,playerName,playerName2)]
    [InlineData(3,playerName,playerName2,playerName3)]
    [InlineData(4,playerName,playerName2,playerName3,playerName4)]
    [InlineData(5,playerName,playerName2,playerName3,playerName4,playerName5)]
    //[InlineData(6,playerName,playerName2,playerName3,playerName4,playerName5,"Shemp")]
    public void add_players(int howMany,params string[] players)
    {
        var subject = new Game();
        foreach(var player in players)
        {
            subject.Add(player);
        }
        subject.HowManyPlayers().ShouldBe(howMany);
    }
}