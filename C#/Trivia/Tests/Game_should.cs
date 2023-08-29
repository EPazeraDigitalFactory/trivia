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
    [InlineData(1,"Science",1)]
    [InlineData(2,"Sports",2)]
    [InlineData(3,"Rock",3)]
    [InlineData(4,"Pop",4)]
    [InlineData(5,"Science",5)]
    [InlineData(6,"Sports",6)]
    [InlineData(7,"Rock",7)]
    [InlineData(8,"Pop",8)]
    [InlineData(9,"Science",9)]
    [InlineData(10,"Sports",10)]
    [InlineData(11,"Rock",11)]
    [InlineData(12,"Pop",0)]
    [InlineData(24,"Rock",12)]
    [InlineData(25,"Rock",13)]
    public void roll(int dieRoll, string expectedCategory, int expectedLocation)
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
        output[6].ShouldContain($"playerName's new location is {expectedLocation}");
        output[7].ShouldContain($"The category is {expectedCategory}");
        output[8].ShouldContain($"{expectedCategory} Question 0");
    }
    [Fact]
    public void allow_wrong_answers()
    {
        const int expectedMessageCount=11;
        var dieRoll=1;
        var expectedLocation=dieRoll;
        var expectedCategory="Science";

        var output = new List<string>();
        var subject = new Game(output.Add);
        subject.Add(playerName);
        subject.Add(playerName2);
        subject.Roll(dieRoll);
        subject.WrongAnswer().ShouldBe(true);
        output.Count.ShouldBe(expectedMessageCount);
        output[0].ShouldContain($"{playerName} was added");
        output[1].ShouldContain("They are player number 1");
        output[2].ShouldContain($"{playerName2} was added");
        output[3].ShouldContain("They are player number 2");
        output[4].ShouldContain($"{playerName} is the current player");
        output[5].ShouldContain($"They have rolled a {dieRoll}");
        output[6].ShouldContain($"playerName's new location is {expectedLocation}");
        output[7].ShouldContain($"The category is {expectedCategory}");
        output[8].ShouldContain($"{expectedCategory} Question 0");
        output[9].ShouldContain($"Question was incorrectly answered");
        output[10].ShouldContain($"{playerName} was sent to the penalty box");
   }
    [Fact]
    public void allow_geting_out_of_penalty_box()
    {
        const int expectedMessageCount=8;
        var dieRoll=1;
        var expectedLocation=dieRoll * 2;
        var expectedCategory="Sports";

        var output = new List<string>();
        var subject = new Game(output.Add);
        subject.Add(playerName);
        subject.Add(playerName2);
        subject.Roll(dieRoll);
        subject.WrongAnswer().ShouldBe(true);
        subject.Roll(dieRoll);
        subject.WrongAnswer().ShouldBe(true);
        output.Clear();
        subject.Roll(dieRoll);
        subject.WasCorrectlyAnswered().ShouldBe(true);
        output.Count.ShouldBe(expectedMessageCount);
        output[0].ShouldContain($"{playerName} is the current player");
        output[1].ShouldContain($"They have rolled a {dieRoll}");
        output[2].ShouldContain($"{playerName} is getting out of the penalty box");
        output[3].ShouldContain($"playerName's new location is {expectedLocation}");
        output[4].ShouldContain($"The category is {expectedCategory}");
        output[5].ShouldContain($"{expectedCategory} Question 0");
        output[6].ShouldContain($"Answer was correct!!!!");
        output[7].ShouldContain($"{playerName} now has 1 Gold Coins.");
   }}