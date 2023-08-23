using System;
using Trivia;
using Xunit;
using Shouldly;

public class Game_should
{
    [Fact]
    public void Game_Should_Start_With_No_Players()
    {
        Game game = new Game();
        game.HowManyPlayers().ShouldBe(0);
        game.IsPlayable().ShouldBe(false);
    }


}