using System;
using System.Collections.Generic;
using System.Linq;
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
    [InlineData(1,2,playerName)]
    [InlineData(2,4,playerName,playerName2)]
    [InlineData(3,6,playerName,playerName2,playerName3)]
    [InlineData(4,8,playerName,playerName2,playerName3,playerName4)]
    [InlineData(5,10,playerName,playerName2,playerName3,playerName4,playerName5)]
    //[InlineData(6,playerName,playerName2,playerName3,playerName4,playerName5,"Shemp")]
    public void add_players(int howManyPlayer,int howManyLine,params string[] players)
    {
        var output = new List<string>();
        var subject = new Game(output.Add);
        foreach(var player in players)
        {
            subject.Add(player).ShouldBeTrue();
        }
        subject.HowManyPlayers().ShouldBe(howManyPlayer);
        output.Count.ShouldBe(howManyLine);
    }
    [Theory]
    [InlineData(playerName)]
    [InlineData(playerName,playerName2)]
    [InlineData(playerName,playerName2,playerName3)]
    [InlineData(playerName,playerName2,playerName3,playerName4)]
    [InlineData(playerName,playerName2,playerName3,playerName4,playerName5)]
    //[InlineData(6,playerName,playerName2,playerName3,playerName4,playerName5,"Shemp")]
    public void outputs_player_name_when_adding(params string[] players)
    {
        var output = new List<string>();
        var subject = new Game(output.Add);
        foreach(var player in players)
        {
            subject.Add(player);
            output.Any(x=>x.Contains(player)).ShouldBeTrue();
        }
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void roll(int dieRoll)
    {
        const int expectedMessageCount=9;
        var output = new List<string>();
        var subject = new Game(output.Add);
        subject.Add(playerName);
        subject.Add(playerName2);
        subject.Roll(dieRoll);
        output.Count.ShouldBe(expectedMessageCount);
        output[0].ShouldContain($"{playerName} was added");
        output[1].ShouldContain("They are player number 1");
        output[2].ShouldContain($"{playerName2} was added");
        output[3].ShouldContain("They are player number 2");
        output[4].ShouldContain($"{playerName} is the current player");
        output[5].ShouldContain($"They have rolled a {dieRoll}");
        output[6].ShouldContain($"playerName's new location is {dieRoll}");
        output[7].ShouldContain($"The category is");
        output[8].ShouldContain($"Question 0");
    }
}