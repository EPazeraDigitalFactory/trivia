using System;
using Shouldly;
using Trivia;
using Xunit;

public class Game_should
{
    [Fact]
    public void add_player_to_game()
    {
        const string playerName = "playerName";
        var subject = new Game();
        subject.Add(playerName);
        subject.HowManyPlayers().ShouldBe(1);
    }
    [Fact]
    public void add_two_players()
    {
        const string playerName = "playerName";
        const string playerName2 = "playerName2";
        var players = new string[]{playerName,playerName2};
        var subject = new Game();
        foreach(var player in players)
        {
            subject.Add(player);
        }
        subject.HowManyPlayers().ShouldBe(2);
    }
}