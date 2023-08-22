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
}